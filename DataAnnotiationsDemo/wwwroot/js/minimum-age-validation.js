// minimum-age-validation.js
jQuery.validator.addMethod("minimumage", function (value, element, params) {
    if (!value) {
        return true; // Not validation emptiness here, required attribute should handle this
    }
    var dateOfBirth = new Date(value);
    var minimumAgeDate = new Date();
    minimumAgeDate.setFullYear(minimumAgeDate.getFullYear() - parseInt(params));

    return dateOfBirth <= minimumAgeDate;
}, function (params, element) {
    return $(element).data('val-minimumage');
});

jQuery.validator.unobtrusive.adapters.add("minimumage", ["minage"], function (options) {
    options.rules["minimumage"] = options.params.minage;
    options.messages["minimumage"] = options.message;
});