jQuery.validator.addMethod('passwordstrength', function (value, element) {
    if (!value) {
        return true; // Don't validate empty values
    }

    return this.optional(element) || /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$&])[A-Za-z\d@#$&]{8,}$/.test(value);
}, 'Password must contain at least one uppercase letter, one lowercase letter, one number, one special character(@,#,$,&) and be at least 8 characters long.');

jQuery.validator.unobtrusive.adapters.add('passwordstrength', function (options) {
    options.rules['passwordstrength'] = {};
    options.message['passwordstrength'] = options.message;
});