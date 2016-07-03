//  JQuery validator to allow repeated names in forms with different IDs
//  --------------------------------------------------------------------
jQuery.validator.prototype.checkForm = function () {
    this.prepareForm();
    for (var i = 0, elements = (this.currentElements = this.elements()) ; elements[i]; i++) {
        if (this.findByName(elements[i].name).length != undefined && this.findByName(elements[i].name).length > 1) {
            for (var cnt = 0; cnt < this.findByName(elements[i].name).length; cnt++) {
                this.check(this.findByName(elements[i].name)[cnt]);
            }
        } else {
            this.check(elements[i]);
        }
    }
    return this.valid();
};



jQuery.validator.addMethod("isValidCountry", function (country) {

    //    var in_array = $.inArray(value, arrCountries);

    var matchString = country.toLowerCase();
    var in_array = null;

    $.each(arrCountries, function (index, value) {
        if (in_array == null && value.toLowerCase() === matchString) {
            in_array = index;
            return false;
        }
    });

    if (in_array == -1) {
        return false;
    }
    else {
        return true;
    }
}, "Please select a valid country name.");

function getDestinyEmail() {
    return varDestinyEmail + '/' + varGUID;
}

function InitValidator()
{
    $('#formContact').validate({
        ignore: [],
        rules: {
            FirstName: {
                required: true,
                maxlength: 100
            },
            LastName: {
                maxlength: 100,
                required: true
            },
            //Gender: {
            //    required: true
            //},
            //Birthdate: {
            //    required: true
            //},
            'Addresses[][Street]': {
                required: true
            },
            'Addresses[][City]': {
                required: true
            },
            'Addresses[][PostalCode]': {
                required: true
            },
            'Addresses[][Country]': {
                required: true,
                isValidCountry: true
            },
            'Emails[][Email]': {
                required: true,
                email: true,
                remote: {
                    url: getDestinyEmail(),
                    type: 'post',
                }

            },
            //'Emails[][Description]': {
            //    required: true
            //},
            'Phones[][Number]': {
                required: true,
                digits: true/*,
        minlength: 9*/
            },
            //'Phones[][Description]': {
            //    required: true
            //},
            'Websites[][Website]': {
                url: true
            }

        },
        messages: {
            email: {
                required: "Please Enter Email!",
                email: "This is not a valid email!",
                remote: "E-mail address already in use!"
            }
        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        invalidHandler: function(event, validator) {
        // 'this' refers to the form
            var errors = validator.numberOfInvalids();
            if (errors) {

                var message = errors == 1
                    ? 'You missed 1 field. It has been highlighted'
                    : 'You missed ' + errors + ' fields. They have been highlighted, please check all the tabs';


                $('#linkConfirm').hide();
                $('#ModalMessage').text(message);
                $('#ModalConfirm').modal('show');
            }
            else {
            }
        },
        submitHandler: function (form) {
            $('#btnSave').attr("disabled", true);
            var JSONForm = JSON.stringify($('#formContact').serializeObject());
            var varDestiny;

            if ($("#btnSave").val() == 'Save') {
                varDestiny = varDestinyU;
                $.ajax({
                    url: varDestiny,
                    type: "POST",
                    dataType: "json",
                    data: {
                        contactJSON: JSONForm,
                        id: varGUID
                    },
                    error: function (response) {
                        $('#linkConfirm').attr('href', '');
                        $('#ModalMessage').text(response.responseText);
                        $('#ModalConfirm').modal('show');

                        $('#btnSave').attr("disabled", false);
                    },
                    success: function (response) {
                        $('#linkConfirm').attr('href', '');
                        $('#ModalMessage').text(response.responseText);
                        $('#ModalConfirm').modal('show');
                        clearForm();
                    }
                });
            }
            else {
                varDestiny = varDestinyC;
                $.ajax({
                    url: varDestiny,
                    type: "POST",
                    dataType: "json",
                    data: {
                        contactJSON: JSONForm
                    },
                    error: function (response) {
                        $('#linkConfirm').attr('href', '');
                        $('#ModalMessage').text(response.responseText);
                        $('#ModalConfirm').modal('show');
                        $('#btnSave').attr("disabled", false);
                    },
                    success: function (response) {
                        $('#linkConfirm').attr('href', '');
                        $('#ModalMessage').text(response.responseText);
                        $('#ModalConfirm').modal('show');
                        clearForm();
                    }
                });
            }
            return false;
            //}
            //else// form is invalid
            //{
            //    alert("There is non-valid data in the form. Please check the different tabs.");
            //}
            return false;
        }
    });
}

InitValidator();


//$('#btnSave').click(function () {
    
    //$('#formContact').submit();

 //   var validated = $('#formContact').validate();

    //if (validated.valid()) {

    //    $('#btnSave').attr("disabled", true);
    //    var JSONForm = JSON.stringify($('#formContact').serializeObject());
    //    var varDestiny;

    //    if ($("#btnSave").val() == 'Save') {
    //        varDestiny = varDestinyU;
    //        $.ajax({
    //            url: varDestiny,
    //            type: "POST",
    //            dataType: "json",
    //            data: {
    //                contactJSON: JSONForm,
    //                id: varGUID
    //            },
    //            error: function (response) {
    //                alert(response.responseText);
    //                $('#btnSave').attr("disabled", false);
    //            },
    //            success: function (response) {
    //                alert(response.responseText);
    //                clearForm();
    //            }
    //        });
    //    }
    //    else {
    //        varDestiny = varDestinyC;
    //        $.ajax({
    //            url: varDestiny,
    //            type: "POST",
    //            dataType: "json",
    //            data: {
    //                contactJSON: JSONForm
    //            },
    //            error: function (response) {
    //                alert(response.responseText);
    //                $('#btnSave').attr("disabled", false);
    //            },
    //            success: function (response) {
    //                alert(response.responseText);
    //                clearForm();
    //            }
    //        });
    //    }
    //    return false;
    //}
    //else// form is invalid
    //{
    //    alert("There is non-valid data in the form. Please check the different tabs.");
    //}
    //return false;
//});
