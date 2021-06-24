class DatePicker {
    constructor() { }

    initDatePicker() {
        $('[name="birthDate"]').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD.MM.YYYY'
            }           
        });
    }
}

