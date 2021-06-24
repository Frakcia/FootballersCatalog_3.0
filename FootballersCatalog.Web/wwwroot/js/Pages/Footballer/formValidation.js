class FormValidation {
    constructor() {}

    createFormValidation(formName) {
        $(formName).validate({
            rules: {
                middleName: {
                    required: true,
                    minlength: 1,
                    maxlength: 64
                },
                lastName: {
                    required: true,
                    minlength: 1,
                    maxlength: 64
                },
                firstName: {
                    required: true,
                    minlength: 1,
                    maxlength: 64
                },
                team: {
                    required: true,
                    minlength: 1,
                    maxlength: 64
                },
                birthDate: {
                    required: true,
                    minlength: 1,
                    maxlength: 64
                }
            },
            errorPlacement: function (label, element) {
                label.css('color', 'red');
                label.css('font-weight', 'bold');
                label.insertAfter(element);
            }
        });
        changeValidationErrorMessages();
    }

    validateForm(formName) {
        trimInputs();
        return validateDate() && $(formName).valid();
    }

    validateTeamName(element, teamsNames) {
        if ($(element).val().trim().length === 0) {
            addErrorToElement(element, "Поле должно быть заполнено");
            return false;
        }
        else if (teamsNames.includes($(element).val())) {
            addErrorToElement(element, "Команда с таким названием уже существует");
            return false;
        }

        return true;
    }
}

function removeErrors(element) {
    if ($(element).hasClass('unvalid-input')) {
        $(element).removeClass('unvalid-input');
        $(element).parent().find('.validation-error').remove();
    }
}

$('[name="new-team-field"]').on('input', function () {
    removeErrors(this);
});

$('[name="birthDate"]').on('click', function () {
    removeErrors(this);
});

function changeValidationErrorMessages() {
    jQuery.extend(jQuery.validator.messages, {
        required: "Поле должно быть заполнено",
        number: "Введите число",
        maxlength: "Превышено допустимое количество символов"
    });
}

function trimInputs() {
    $('input[type="text"]').each(function () {
        let trimmedValue = $(this).val().trim();
        $(this).val(trimmedValue);
    });
}

function validateDate() {
    let dateValue = $('[name="birthDate"]').val();
    let [day, month, year] = dateValue.split('.');
    let dateObj = new Date();
    let currentYear = dateObj.getFullYear();
    let currentMonth = dateObj.getMonth() + 1;
    let currentDay = dateObj.getDate();

    if (currentYear - year > 5 && currentYear - year < 100) {
        return true;
    }
    else if (currentYear - year === 5) {
        if (monthDif < 0 || (monthDif === 0 && day - currentDay < 0)) {        
            return true;
        }
    }
    else if (currentYear - year === 100) {
        let monthDif = currentMonth - month;
        if (monthDif > 0 || (monthDif === 0 && day - currentDay > 0)) {
            return true;
        }
    }

    addErrorToElement($('[name="birthDate"]'), 'Возраст не должен превышать 100 лет и быть меньше 5 лет');
    return false;
}

function addErrorToElement(element, message) {
    let parent = $(element).parent();
    if (parent.children('.validation-error').length === 0) {
        $(element).addClass('unvalid-input');
        parent.append(`<label class="validation-error">${message}</label`);
    }
}

function scrollToWrongElement(message) {
    let anchor = $(message);

    for (let i = 0; i < anchor.length; i++) {
        if (anchor[i].style.display != "none") {
            $('html, body').animate({
                scrollTop: $(anchor[i]).offset().top - 100
            }, 400);
            break;
        }
    }
}