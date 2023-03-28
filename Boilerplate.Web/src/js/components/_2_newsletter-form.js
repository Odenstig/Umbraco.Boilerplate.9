import axios from 'axios';

(function () {
    var forms = document.getElementsByClassName('newsletter-form');
    if (forms.length > 0) {
        for (const form of forms) {
            const formValidate = new FormValidator({
                element: form,
                useNet5DefaultValidations: true, 
            });

            form.addEventListener('submit', function (event) {
                event.preventDefault();
                formValidate.validate(function (errorFields) {
                  
                    if (errorFields.length === 0) {

                        const errorMessage = Util.getChildrenByClassName(event.target, 'newsletter-form__error')[0];
                        const successMessage = Util.getChildrenByClassName(event.target, 'newsletter-form__success')[0];
                        const loader = Util.getChildrenByClassName(event.target, 'newsletter-form__loader')[0];

                        Util.removeClass(loader, 'hide');
                        Util.addClass(successMessage, 'hide');
                        Util.addClass(errorMessage, 'hide');

                        const formData = new FormData(event.target);
                        const token = event.target.querySelector('input[name="__RequestVerificationToken"]').value;

                        axios.post('/umbraco/surface/newslettersurface/register', formData, {
                            headers: {
                                'Content-Type': 'application/x-www-form-urlencoded',
                                'RequestVerificationToken': token
                            }
                        })
                            .then(res => {
                                Util.addClass(loader, 'hide')
                                Util.removeClass(successMessage, 'hide');
                            })
                            .catch(err => {
                                Util.addClass(loader, 'hide')
                                Util.removeClass(errorMessage, 'hide');
                            });
                    }
                });
            });
        }
    }
}());