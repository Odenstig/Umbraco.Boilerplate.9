var gulp = require('gulp');
const { sass } = require("@mr-hope/gulp-sass");
var sassGlob = require('gulp-sass-glob');
var browserSync = require('browser-sync').create();
var postcss = require('gulp-postcss');
var autoprefixer = require('autoprefixer');
var cssvariables = require('postcss-css-variables');
var calc = require('postcss-calc');
var rename = require('gulp-rename');
var purgecss = require('gulp-purgecss');
var purgecssFromHtml = require('purgecss-from-html');

// Gulp Rollup (used for compiling js)
var rollupStream = require('@rollup/stream');
var buffer = require('vinyl-buffer');
var source = require('vinyl-source-stream');
var multi = require('@rollup/plugin-multi-entry');
var resolve = require('@rollup/plugin-node-resolve').nodeResolve;
var commonjs = require('@rollup/plugin-commonjs');
var json = require('@rollup/plugin-json');
var terser = require('gulp-terser');
var babel = require('@rollup/plugin-babel').babel;

// js file paths
var utilJsPath = './src/js/util.js'; // util.js path from codyhouse framework
var componentsJsPath = './src/js/components/*.js'; // component js files
var scriptsJsPath = './wwwroot/scripts/js'; //folder for final scripts.js/scripts.min.js files

// css file paths
var cssFolder = './wwwroot/css'; // folder for final style.css/style-custom-prop-fallbac.css files
var scssFilesPath = 'src/css/**/*.scss'; // scss files to watch

// PurgeCSS
// Where to look for css selectors that are used. 
// Any selectors not used by files from these options will be discarded from the final css version
var PurgeCSSContent = [
    'Views/**/*.cshtml',
    scriptsJsPath + '/scripts.js'
]

// Gulp Sass options
// sass.compiler = require('sass');

function reload(done) {
    browserSync.reload();
    done();
}

/* Gulp watch task */
// This task is used to convert the scss to css and compress it. No fallback for IE is created  
gulp.task('sass', function () {
    return gulp.src(scssFilesPath)
        .pipe(sassGlob())
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(postcss([autoprefixer()]))
        .pipe(gulp.dest(cssFolder))
        .pipe(browserSync.reload({
            stream: true
        }));
});

// declare the cache variable outside of task scopes
let rollupCache;

gulp.task('scripts', () => {
    // Rollup configuration
    const options = {
        input: [
            utilJsPath,
            componentsJsPath
        ],
        output: {
            sourcemap: false, // disable sourcemaps
        },
        cache: rollupCache,
        plugins: [
            multi(), // allows use of multiple entry points for a bundle.
            json(), // Converts .json files to ES6 modules
            resolve({ preferBuiltins: true, mainFields: ['browser'] }), // locates modules using the Node resolution algorithm, for using third party modules in node_modules            
            commonjs(), // convert CommonJS modules to ES6, so they can be included in a Rollup bundle. Must come after babel().            
            babel({ babelHelpers: 'bundled' }), // transpile ES6/7 code            
        ],
    };
    return rollupStream(options)
        .on('bundle', function (bundle) {
            // Update cache data after every bundle is created
            cache = bundle;
        })
        .pipe(source('scripts.js'))
        .pipe(buffer())
        .pipe(gulp.dest(scriptsJsPath))
        .pipe(browserSync.reload({
            stream: true
        }));
});

// Old task for compoling script (keep only for reference)
// gulp.task('scripts', function () {
//     return gulp.src([utilJsPath + '/util.js', componentsJsPath])
//         .pipe(concat('scripts.js'))
//         .pipe(gulp.dest(scriptsJsPath))
//         .pipe(browserSync.reload({
//             stream: true
//         }))
//         .pipe(rename('scripts.min.js'))
//         .pipe(uglify())
//         .pipe(gulp.dest(scriptsJsPath))
//         .pipe(browserSync.reload({
//             stream: true
//         }));
// });

gulp.task('browserSync', gulp.series(function (done) {
    browserSync.init({
        notify: false,
        proxy: "http://localhost:6869/" // Update this to match the url which you are running the website on
    })
    done();
}));

gulp.task('watch', gulp.series(['browserSync', 'sass', 'scripts'], async function () {
    await moveAssets();
    gulp.watch('Views/*.cshtml', gulp.series(reload));
    gulp.watch('src/css/**/*.scss', gulp.series(['sass']));
    gulp.watch('src/js/util.js', gulp.series(['scripts']));
    gulp.watch(componentsJsPath, gulp.series(['scripts']));
}));


/* Gulp dist task */
// create a distribution folder for production
var rootFolder = 'wwwroot/';

gulp.task('dist', async function () {
    // remove unused classes from the style.css file with PurgeCSS and copy it to the dist folder
    /*  await purgeCSS();*/
    // minify the scripts.js file and copy it to the dist folder
    await minifyJs();
    // copy the style-fallback (IE support) to the dist folder
    await moveCSS();
    // copy any additional js files to the dist folder
    await moveJS();
    // copy all the assets inside main/assets/img folder to the dist folder
    await moveAssets();
});

function purgeCSS() {
    return new Promise(function (resolve, reject) {
        var stream = gulp
            .src(cssFolder + '/style.css')
            .pipe(purgecss({
                content: PurgeCSSContent,
                extractors: [
                    {
                        extractor: purgecssFromHtml,
                        extensions: ['html', 'cshtml']
                    }
                ],
                safelist: {
                    standard: ['is-hidden', 'is-visible'],
                    deep: [/class$/],
                    greedy: []
                },
                defaultExtractor: content => content.match(/[\w-/:%@]+(?<!:)/g) || []
            }))
            .pipe(gulp.dest(rootFolder + '/css'));

        stream.on('finish', function () {
            resolve();
        });
    });
};

function minifyJs() {
    return new Promise(function (resolve, reject) {
        var stream = gulp.src(scriptsJsPath + '/scripts.js')
            .pipe(terser({ sourceMap: false }))
            .pipe(gulp.dest(rootFolder + '/scripts/js'));

        stream.on('finish', function () {
            resolve();
        });
    });
};

function moveCSS() {
    return new Promise(function (resolve, reject) {
        var stream = gulp
            .src(cssFolder + '/style-fallback.css', { allowEmpty: true })
            .pipe(gulp.dest(rootFolder + 'css'));

        stream.on('finish', function () {
            resolve();
        });
    });
};

function moveJS() {
    return new Promise(function (resolve, reject) {

        const files = [
            scriptsJsPath + '/*.js',
            '!' + scriptsJsPath + '/util.js',
            '!' + scriptsJsPath + '/scripts.js',
            '!' + scriptsJsPath + '/scripts.min.js',
            '!' + scriptsJsPath + '/scripts.min.js.map'
        ]

        var stream = gulp
            .src(files, { allowEmpty: true })
            .pipe(gulp.dest(rootFolder + 'js'));

        stream.on('finish', function () {
            resolve();
        });
    });
};

function moveAssets() {
    return new Promise(function (resolve, reject) {
        var stream = gulp.src(['src/img/**'], { allowEmpty: true })
            .pipe(gulp.dest(rootFolder + 'img'));

        stream.on('finish', function () {
            resolve();
        });
    });
};

gulp.task('release', gulp.series(['sass', 'scripts', 'dist']));