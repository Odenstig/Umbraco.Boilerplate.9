# Umbraco 9 Boilerplate

The starter kit for Umbraco based sites. Current Umbraco version is v9.x.

## Documentation

### HTML / CSS / Javascript
This project makes use of the [Codyhouse Framework](https://codyhouse.co). It is setup with compiling scss files and javascript files for both development and production. 

For optimal use of the framework make yourself adapt by studying their [documentation](https://codyhouse.co/ds/docs/framework). There is plenty of utility classes to easily create the desired outcome. 

**Quick links**
- [CSS Utility](https://codyhouse.co/ds/docs/framework/utilities)
- [JS Utility](https://codyhouse.co/ds/docs/framework/js-utilities)
- [Grid Layouts](https://codyhouse.co/ds/docs/framework/grid-layout)
- [Breakpoints](https://codyhouse.co/ds/docs/framework/breakpoints)
- [Forms](https://codyhouse.co/ds/docs/framework/forms)
- [Components](https://codyhouse.co/ds/components)

**Do not implement jQuery if not absolutely necessary. You can come far with plain vanilla JS.**

## Getting started
1. Press **Use this template** to start a new repository
2. Rename everything
	* Search and replace "Boilerplate." with a fitting project name
	* Rename the sdf file (`db/Umbraco.sdf`) if you have not already. Use the project name.
3. Create a copy of the database file and move into `ProjectName.Web/umbraco/data` folder.
4. Update the proxy URL in ProjectName.Web/gulpfile.js located in the browserSync task with the port number of the web project.
5. Login to `/umbraco` using the Boilerplate credentials in LastPass
6. Change the admin password for site. Save the credentials in LastPass.
7. Change the URL in robots.txt
8. Make a nice default image for the `og:image` property located in the `ProjectName.Web/Views/Components/MetaTags/Default.cshtml`. The default image is located here `ProjectName.Web/src/img/default-social-share.jpg`. Recommended size is 1200 x 630 pixels.
9. Favicons: Make an icon of ex the logo (260 x 260). Generate all icons in the site root using [realfavicongenerator](http://realfavicongenerator.net/). Save them in `ProjectName.Web/src/img` directory. HTML for icons etc for this goes in `ProjectName.Web/Views/Partials/_Favicons.cshtml` file.

## Moving to Production
1. Setup the favicons, manifest etc according to best practices.
2. Compile CSS & Javascript according to our documentation.

## Developing

### CSS / Javascript
This project makes use of the [Codyhouse Framework](https://codyhouse.co). It is setup with compiling scss files and javascript files for both development and production. 

For optimal use of the framework make yourself adapt by studying their [documentation](https://codyhouse.co/ds/docs/framework). There is plenty of utility classes to easily create the desired outcome. 

### Compiling

#### For development
open a terminal -> navigate to the `Boilerplate.Web` directory and then run the following commands
```
npm install
npm run start
```
The development files are stored in a non-minified and a minified version inside of `src/css` and `src/js`. 

##### For production
```
npm run build
```
The production files takes the development files, purges the css of any css that is not used in any of the Views files, minifies them and moves them to the `wwwroot` folder.

### Updating base styles
Within the `src/css/custom-style` directory lies files for adjusting global styles based on the brand. While you can edit these files yourself it is recommended to use the [Global Editor](https://codyhouse.co/ds/globals) available at the codyhouse website and then exporting everything. 

### Creating your own styles or js functionality
All the scss/js files are located in `src/` directory. If you are creating your own "component" add a new file to the `scr/css/components` directory. Each file are and should be prefixed with a number based on their depedency. If your component depends a on a different component then that must be loaded in the correct order. Depedency first and your component later, that can be achieved with the number prefixes. If your component does not depend on any other component then you can prefix it with `_1_`. 

## Regular problems
- Using `rebuild` in VS will cause the compiler to complain about missing files in `App_Plugins` folder. Just ignore these messages because they will disappear as soon as you `build/start` the project. 
