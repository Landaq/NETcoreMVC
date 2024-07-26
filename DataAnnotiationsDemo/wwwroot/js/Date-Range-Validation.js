$.validator.addMethod('daterange', function (value, element, params) {
    var otherPropName = $(element).data('valDaterangeOther');
    var otherValue = $('#' + otherPropName).val();
    if (otherPropName && otherValue) {
        var thisDate = new Date(value);
        var otherDate = new Date(otherValue);
        if (otherPropName === 'FromDate') {
            return thisDate >= otherDate && thisDate <= Date.now();
        } else {
            return thisDate <= otherDate && thisDate <= Date.now();
        }
    }
    return true;
}, function (params, element) {
    return $(element).data('valDaterange');
});

$.validator.unobtrusive.adapters.add('daterange', [], function (options) {
    options.rules['daterange'] = true;
    options.messages['daterange'] = options.message;
})