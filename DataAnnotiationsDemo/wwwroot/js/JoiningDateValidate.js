//Define a custom method for jQuery validation to check the "Date of Joining".
jQuery.validator.addMethod('ValidJoiningDate', function (value, element) {
    //Directly return true for empty values, which allows the field to be optional.
    if (!value) {
        return true;
    }

    // Compare input date with the current date, ignoring time of day.
    var inputDate = new Date(value);
    var today = new Date();
    today.setHours(0, 0, 0, 0); // Normalize today's date by removing time components.

    // Validate that the input date is not in the future.
    return inputDate <= today;
}, 'The joining date cannot be in the future.');  // Default error message.

// Integrate the custom method with jQuery unobtrusive validation.
jQuery.validator.unobtrusive.adapters.addBool('ValidJoiningDate');