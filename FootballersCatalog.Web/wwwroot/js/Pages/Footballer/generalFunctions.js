class GenralFunctions {
    constructor() { }

    getFootballerModel() {
        let footballer = {
            Id: $('[name="id"]').val(),
            LastName: $('[name="lastName"]').val(),
            FirstName: $('[name="firstName"]').val(),
            MiddleName: $('[name="middleName"]').val(),
            Gender: $('[name="gender"]').filter(function () {
                return $(this).prop('checked');
            }).val(),
            BirthDate: $('[name="birthDate"]').val(),
            SelectedTeam: getTeamObj(),
            SelectedCountry: getCountryObj()
        };

        return footballer;
    }
}

function getCountryObj() {
    let select = $('#countrySelect');

    let countryObj = {
        Id: select.val(),
        Name: ''
    };

    return countryObj;
}

function getTeamObj() {
    let select = $('#teamSelect');

    let teamObj = {
        Id: select.val(),
        Name: ''
    };

    return teamObj;
}