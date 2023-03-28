// File#: _1_form-validator
// Usage: codyhouse.co/license
(function () {
    var FormValidator = function (opts) {
        this.options = Util.extend(FormValidator.defaults, opts);
        this.element = this.options.element;
        this.input = [];
        this.textarea = [];
        this.select = [];
        this.errorFields = [];
        this.errorFieldListeners = [];
        initFormValidator(this);
    };

    //public functions
    FormValidator.prototype.validate = function (cb) {
        validateForm(this);
        if (cb) cb(this.errorFields);
    };

    // private methods
    function initFormValidator(formValidator) {
        formValidator.input = formValidator.element.querySelectorAll('input');
        formValidator.textarea = formValidator.element.querySelectorAll('textarea');
        formValidator.select = formValidator.element.querySelectorAll('select');
    };

    function validateForm(formValidator) {
        // reset input with errors
        formValidator.errorFields = [];
        // remove change/input events from fields with error
        resetEventListeners(formValidator);

        // loop through fields and push to errorFields if there are errors
        for (var i = 0; i < formValidator.input.length; i++) {
            validateField(formValidator, formValidator.input[i]);
        }

        for (var i = 0; i < formValidator.textarea.length; i++) {
            validateField(formValidator, formValidator.textarea[i]);
        }

        for (var i = 0; i < formValidator.select.length; i++) {
            validateField(formValidator, formValidator.select[i]);
        }

        // show errors if any was found
        for (var i = 0; i < formValidator.errorFields.length; i++) {
            showError(formValidator, formValidator.errorFields[i]);
        }

        // move focus to first field with error
        if (formValidator.errorFields.length > 0) formValidator.errorFields[0].focus();
    };

    function validateField(formValidator, field) {
        if (formValidator.options.useNet5DefaultValidations) {
            var validationErrors = getNet5ValidationErrors(field);
            if (validationErrors.length > 0) {
                var wrapper = field.closest('.js-form-validate__input-wrapper');
                if (wrapper) {
                    var errorContainer = wrapper.querySelector('.form-validate__error-msg');
                    if (errorContainer) {
                        var firstErrorMessage = validationErrors[0];
                        errorContainer.innerHTML = firstErrorMessage;
                    }
                }
                formValidator.errorFields.push(field);
            }
        } else {
            if (!field.checkValidity()) {
                formValidator.errorFields.push(field);
                return;
            }
            // check for custom functions
            var customValidate = field.getAttribute('data-validate');
            if (customValidate && formValidator.options.customValidate[customValidate]) {
                formValidator.options.customValidate[customValidate](field, function (result) {
                    if (!result) formValidator.errorFields.push(field);
                });
            }
        }
    };

    function showError(formValidator, field) {
        // add error classes
        toggleErrorClasses(formValidator, field, true);

        // add event listener
        var index = formValidator.errorFieldListeners.length;
        formValidator.errorFieldListeners[index] = function () {
            toggleErrorClasses(formValidator, field, false);
            field.removeEventListener('change', formValidator.errorFieldListeners[index]);
            field.removeEventListener('input', formValidator.errorFieldListeners[index]);
        };
        field.addEventListener('change', formValidator.errorFieldListeners[index]);
        field.addEventListener('input', formValidator.errorFieldListeners[index]);
    };

    function toggleErrorClasses(formValidator, field, bool) {
        bool ? Util.addClass(field, formValidator.options.inputErrorClass) : Util.removeClass(field, formValidator.options.inputErrorClass);
        if (formValidator.options.inputWrapperErrorClass) {
            var wrapper = field.closest('.js-form-validate__input-wrapper');
            if (wrapper) {
                bool ? Util.addClass(wrapper, formValidator.options.inputWrapperErrorClass) : Util.removeClass(wrapper, formValidator.options.inputWrapperErrorClass);
            }
        }
    };

    function resetEventListeners(formValidator) {
        for (var i = 0; i < formValidator.errorFields.length; i++) {
            toggleErrorClasses(formValidator, formValidator.errorFields[i], false);
            formValidator.errorFields[i].removeEventListener('change', formValidator.errorFieldListeners[i]);
            formValidator.errorFields[i].removeEventListener('input', formValidator.errorFieldListeners[i]);
        }

        formValidator.errorFields = [];
        formValidator.errorFieldListeners = [];
    };

    function getNet5ValidationErrors(field) {
        console.log("Field", field)
        console.log("Field value: ", field.value)
        var validationArray = [];
        var dataset = field.dataset;
        if (dataset.valRequired) {
            var isValid = validateRequired(field.value);
            validationArray.push({ message: dataset.valRequired, isValid });
        }
        if (dataset.valEmail) {
            var isValid = validateEmail(field.value);
            validationArray.push({ message: dataset.valEmail, isValid });
        }
        if (dataset.valEnforcetrue) {
            var isValid = validateEnforcetrue(field);
            validationArray.push({ message: dataset.valEnforcetrue, isValid });
        }
        return validationArray
            .filter(v => !v.isValid)
            .map(v => v.message);
    }

    function validateRequired(value) {
        return value ? true : false;
    }

    function validateEmail(value) {
        return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(value);
    }

    function validateEnforcetrue(field) {
        return field.checked;
    }

    FormValidator.defaults = {
        element: '',
        inputErrorClass: 'form-control--error',
        inputWrapperErrorClass: 'form-validate__input-wrapper--error',
        customValidate: {},
        useNet5DefaultValidations: false
    };
    window.FormValidator = FormValidator;
}());