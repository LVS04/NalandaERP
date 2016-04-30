// Contact page start 


//  Fill full name field 
function SetFullName() {
    var fullName = $("#Prefix").val().trim() + ' ' + $("#FirstName").val().trim() + ' ' + $("#LastName").val().trim() + ' ' + $("#Suffix").val().trim();
    if (fullName.trim().length == 0) {
        $("#divName").addClass('invisible');
    }
    else {
        $("#divName").removeClass('invisible');
    }
    $("#ContactName").val(fullName.trim().toUpperCase());
}
$("#Prefix").change(function () {
    SetFullName();
});
$("#FirstName").keyup(function () {
    SetFullName();
});
$("#LastName").keyup(function () {
    SetFullName();
});
$("#Suffix").keyup(function () {
    SetFullName();
});

SetFullName();



//$('#btnCreate').click(function (e) {
//    e.preventDefault()
//    $('#formContact').serializeObject();
    
//})

$('#myTabs a').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})

//  Scroll to...
$.fn.scrollTo = function (elem, speed) {
    $(this).animate({
        scrollTop: $(this).scrollTop() - $(this).offset().top + $(elem).offset().top
    }, speed == undefined ? 1000 : speed);
    return this;
};
$("#btnGeneral").click(function () {
    $("#divMain").scrollTo("#divGeneral");
});
$("#btnNotes").click(function () {
    $("#divMain").scrollTo("#divNotes");
});
$("#btnAddresses").click(function () {
    $("#divMain").scrollTo("#divAddresses");
});
$("#btnEcontact").click(function () {
    $("#divMain").scrollTo("#divEcontact");
});

function fadeOutRemove( element )
{
    $(element).fadeOut(1000, function () {
        ($(this)).remove();
    });
}

function clearForm() {
    //  Remove all dynamically added content to reset form
    fadeOutRemove("#divNewAddress");
    fadeOutRemove("#divNewPhone");
    fadeOutRemove("#divNewEmail");
    fadeOutRemove("#divNewWebsite");
    fadeOutRemove("#divNewIM");
    fadeOutRemove("#divNewInternetCallId");

    //  Cleanup all 
    $(':input').not(':button, :submit, :reset, :checkbox, :radio').val('');
    $(':checkbox, :radio').prop('checked', false);


}

$("#btnNew").click(function () {
    //$('#formContact').trigger("reset");
    clearForm();
    $('#Main').tab('show');
    $("#divMain").scrollTo("#divGeneral");
    oddBackground = true;
    $("#btnSave").val('Create');
});



//  Dynamic one-to-many elements
//  ----------------------------

$(".removeDiv").click(function () {
    ($(this)).parent().parent().parent().parent().parent().fadeOut(1000, function () {
        ($(this)).remove();
    });
})

var oddBackground = true;
$("#btnAddAddress").click(function () {
    if (!oddBackground) {
        $("#divNewAddress").append('<div class="divAddress"><div class="row container  paddingTop10"><div class="col-sm-6 "><div class="form-group"><label class="" for="Street">Street</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Street must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Street]" type="text" value=""></div></div><div class="form-group"><label class="" for="POBOX">POBOX</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field POBOX must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][POBOX]" type="text" value=""></div></div><div class="form-group"><label class="" for="Neighborhood">Neighborhood</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Neighborhood must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Neighborhood]" type="text" value=""></div></div></div><div class="col-sm-6 "><div class="form-group"><label class="" for="City">City</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field City must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][City]" type="text" value=""></div></div><div class="form-group"><label class="" for="Province">Province</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Province must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Province]" type="text" value=""></div></div><div class="form-group"><label class="" for="PostalCode">Postal Code</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field PostalCode must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][PostalCode]" type="text" value=""></div></div></div></div><div class="row container "><div class="paddingBottom15  col-sm-6"><div class="form-group"><label class="" for="Contry">Country</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Country must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Country]" type="text" value=""></div></div></div><div class="paddingBottom15  col-sm-6"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove address" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    }
    else
    {
        $("#divNewAddress").append('<div class="divAddress"><div class="row container oddBackground paddingTop10"><div class="col-sm-6 oddBackground"><div class="form-group"><label class="" for="Street">Street</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Street must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Street]" type="text" value=""></div></div><div class="form-group"><label class="" for="POBOX">POBOX</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field POBOX must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][POBOX]" type="text" value=""></div></div><div class="form-group"><label class="" for="Neighborhood">Neighborhood</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Neighborhood must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Neighborhood]" type="text" value=""></div></div></div><div class="col-sm-6 oddBackground"><div class="form-group"><label class="" for="City">City</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field City must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][City]" type="text" value=""></div></div><div class="form-group"><label class="" for="Province">Province</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Province must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Province]" type="text" value=""></div></div><div class="form-group"><label class="" for="PostalCode">Postal Code</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field PostalCode must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][PostalCode]" type="text" value=""></div></div></div></div><div class="row container oddBackground"><div class="paddingBottom15 oddBackground col-sm-6"><div class="form-group"><label class="" for="Contry">Country</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Country must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Country]" type="text" value=""></div></div></div><div class="paddingBottom15 oddBackground col-sm-6"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove address" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);

    }
    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })
    oddBackground = !oddBackground;
});

$("#btnAddPhone").click(function () {
    $("#divNewPhone").append('<div class="divPhone"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">Phone Nr</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Number must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Phones[][Number]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Phones[][Description]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove phone" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })
});

$("#btnAddEmail").click(function () {
    $("#divNewEmail").append('<div class="divEmail"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">E-Mail</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Email must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Emails[][Email]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Emails[][Description]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove e-mail" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })
});
$("#btnAddWebsite").click(function () {
    $("#divNewWebsite").append('<div class="divWebsite"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">Website</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Website must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Websites[][Website]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Websites[][Description]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove website" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })
});
$("#btnAddIM").click(function () {
    $("#divNewIM").append('<div class="divIM"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">Instant Messaging</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field InstantMessaging must be a string with a maximum length of 50." data-val-length-max="50" id="" name="IMs[][InstantMessaging]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Instant Messaging Contact</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field IMContact must be a string with a maximum length of 50." data-val-length-max="50" id="" name="IMs[][IMContact]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove IM" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })
});
$("#btnAddInternetCallId").click(function () {
    $("#divNewInternetCallId").append('<div class="divInternetCalls"><div class="row container oddBackground paddingTop10"><div class=" col-sm-4 oddBackground paddingBottom25"><div class="form-group"><label class="" for="Number">Internet Call Id</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field InternetCallId must be a string with a maximum length of 50." data-val-length-max="50" id="" name="InternetCallIds[][InternetCallId]" type="text" value=""></div></div></div><div class=" col-sm-4 oddBackground paddingBottom25"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="InternetCallIds[][Description]" type="text" value=""></div></div></div><div class=" col-sm-4 oddBackground paddingBottom25"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove Internet call id" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })
});

// Contact page end

