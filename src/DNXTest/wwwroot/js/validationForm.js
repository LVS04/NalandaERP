


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

jQuery.validator.addMethod("isValidCountry", function (value) {

    var in_array = $.inArray(value, arrCountries);

    if (in_array == -1) {
        return false;
    }
    else {
        return true;
    }
}, "Please select a valid country name.");

$('#formContact').validate({
    rules: {
        FirstName: {
            required: true,
            maxlength: 100
        },
        LastName: {
            maxlength: 100,
            required: true
        },
        Gender: {
            required: true
        },
        Birthdate: {
            required: true
        },
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
            email: true
        },
        'Emails[][Description]': {
            required: true
        },
        'Phones[][Number]': {
            required: true,
            digits: true
        },
        'Phones[][Description]': {
            required: true
        },
        'Websites[][Website]': {
            url: true
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
    }
});


$('#formContact').submit(function () {

    var form = $("#formContact");
    form.validate();

    if (form.valid()) {

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
                //contentType: "application/json; charset=utf-8",
                error: function (response) {
                    alert(response.responseText);
                },
                success: function (response) {
                    alert(response.responseText);
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
                //contentType: "application/json; charset=utf-8",
                error: function (response) {
                    alert(response.responseText);
                },
                success: function (response) {
                    alert(response.responseText);
                    /*clearForm();*/
                }
            });
        }
        return false;
    }
    return false;
});

/*
        var test = $('#formContact').serializeObject();
        //alert(JSONForm);
        
        
        $.each(test, function (key, value) {
            if (key == 'Addresses')
            {
                $.each(value, function (addressKey, addressValue) {
                    alert(addressKey + ": " + addressValue);
                });
            }
        });
        */