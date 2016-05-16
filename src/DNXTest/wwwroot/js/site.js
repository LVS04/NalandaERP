//  Fill full name field - start
//  ----------------------------
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

$('.combobox').combobox();



//  Contacts tabs activation - start
//  --------------------------------
$('#myTabs a').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})



//  Scroll to buttons inside - start
//  ---------------------------------------------------
$.fn.scrollTo = function (elem, speed) {
    $(this).animate({
        scrollTop: $(this).scrollTop() - $(this).offset().top + $(elem).offset().top
    }, speed == undefined ? 'slow' : speed);
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
//  --------------------------------------------------
$("#btnWorkPrefs").click(function () {
    $("#divVolunteering").scrollTo("#divWorkPrefs");
});

$("#btnMotivation").click(function () {
    $("#divVolunteering").scrollTo("#divMotivation");
});

$("#btnWhen").click(function () {
    $("#divVolunteering").scrollTo("#divWhen");
});
//  --------------------------------------------------
$("#btnEmergency").click(function () {
    $("#divHealth").scrollTo("#divEmergency");
});

$("#btnHistory").click(function () {
    $("#divHealth").scrollTo("#divHistory");
});



//  Fields focus scroll - start
//  ---------------------------
(function ($) {
    $.fn.offsetRelative = function (top) {
        var $this = $(this);
        var $parent = $this.offsetParent();
        var offset = $this.position();
        if (!top) return offset; // Didn't pass a 'top' element
        else if ($parent.get(0).tagName == "BODY") return offset; // Reached top of document
        else if ($(top, $parent).length) return offset; // Parent element contains the 'top' element we want the offset to be relative to
        else if ($parent[0] == $(top)[0]) return offset; // Reached the 'top' element we want the offset to be relative to
        else { // Get parent's relative offset
            var parent_offset = $parent.offsetRelative(top);
            offset.top += parent_offset.top;
            offset.left += parent_offset.left;
            return offset;
        }
    };
}(jQuery));



//  Form cleaning - start
//  ---------------------
function fadeOutWipeContent(element) {
    $(element).fadeOut(1000, function () {
        ($(this)).children().remove();
    });
}

function clearForm() {

    //  Remove all dynamically added content to reset form
    fadeOutWipeContent("#divNewAddress");
    fadeOutWipeContent("#divNewPhone");
    fadeOutWipeContent("#divNewEmail");
    fadeOutWipeContent("#divNewWebsite");
    fadeOutWipeContent("#divNewIM");
    fadeOutWipeContent("#divNewInternetCallId");

    //  Cleanup all 
    $(':input').not('input[type="number"], :button, :submit, :reset, :checkbox, :radio').val('');
    $(':checkbox, :radio').prop('checked', false);
    $('input[type="date"]').val('0001-01-01');
    $('input[type="number"]').val('0');
    $('input[name="Birthdate"]').val('');
    $('#btnSave').val('Create');
    $('.selectpicker').selectpicker('deselectAll');

    $("#divMain").scrollTo("#divGeneral");

    //https://github.com/danielfarrell/bootstrap-combobox/issues/168
    //this.$('select').data('combobox').refresh();
    //$('.combobox').data('combobox').clearTarget();
    //$('#element').data('combobox').clearElement();
}



//  New contact click, form cleaning - start 
//  ----------------------------------------
$("#btnNew").click(function () {
    //$('#formContact').trigger("reset");
    clearForm();
    //$('#myTabs a[href="#Main"]').tab('show')
    oddBackground = true;
});



//  Dynamic one-to-many elements
//  ----------------------------
$(".removeDiv").click(function () {
    ($(this)).parent().parent().parent().parent().parent().fadeOut(1000, function () {
        ($(this)).remove();
    });
})

var oddBackground = true;

var varContacts = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('ContactName'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: varBloodHoundPrefetch
});

$('.emergencyContact .typeahead').typeahead(null, {
    name: 'lookupcontact',
    displayKey: 'ContactName',
    source: varContacts
}).bind('typeahead:select', function (event, data) {
    $('.emergencyContact .contactId').val(data.Id);
});

$('.selectpicker').selectpicker({
    size: 4
}).on('changed.bs.select', function (e) {
    var teste = $(this).parent().parent().find('.selectedIds');
    var valor = $(this).parent().children('.selectpicker').selectpicker('val');
    teste.val(valor);
});

function ControlEventUnbindings() {
    $('.typeahead').typeahead('destroy');
    $('input[type="text"], input[type="number"], textarea').unbind('focus');
    $(".removeDiv").unbind('click');
}

function BindScrollFocus(hostingDiv) {
    $(hostingDiv + ' input[type="text"], input[type="number"], textarea').focus(function () {

        var center = $(hostingDiv).height() / 2;
        var top = $(this).offsetRelative(hostingDiv).top + $(hostingDiv).scrollTop() - $(hostingDiv).position().top;

        $(hostingDiv).animate({ scrollTop: (top - center) }, 500);
    });
}

function OtherEventBindings() {

    $('.country .typeahead').typeahead({
        hint: false,
        highlight: true,
        minLength: 1
    },
    {
        name: 'arrCountries',
        source: substringMatcher(arrCountries)
    });

    $(".removeDiv").click(function () {
        ($(this)).parent().parent().parent().parent().parent().fadeOut(1000, function () {
            ($(this)).remove();
        });
    })

}

function ControlsEventBindings() {
    BindScrollFocus("#divMain");
    BindScrollFocus("#divVolunteering");
    BindScrollFocus("#divHealth");
    OtherEventBindings();
}

ControlsEventBindings();

$("#btnAddAddress").click(function () {

    ControlEventUnbindings();

    if (!oddBackground) {
        $("#divNewAddress").append('<div class="divAddress"><div class="row container  paddingTop10"><div class="col-sm-6 "><div class="form-group"><label class="" for="Street">Street</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Street must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Street]" type="text" value=""></div></div><div class="form-group"><label class="" for="POBOX">POBOX</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field POBOX must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][POBOX]" type="text" value=""></div></div><div class="form-group"><label class="" for="Neighborhood">Neighborhood</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Neighborhood must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Neighborhood]" type="text" value=""></div></div></div><div class="col-sm-6 "><div class="form-group"><label class="" for="City">City</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field City must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][City]" type="text" value=""></div></div><div class="form-group"><label class="" for="Province">Province</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Province must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Province]" type="text" value=""></div></div><div class="form-group"><label class="" for="PostalCode">Postal Code</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field PostalCode must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][PostalCode]" type="text" value=""></div></div></div></div><div class="row container "><div class="paddingBottom15  col-sm-6"><div class="form-group"><label class="" for="Contry">Country</label><div class="country"><input type="text" class="typeahead tt-input form-control text-box single-line isCountry" autocomplete="off" name="Addresses[][Country]" value=""></div></div></div><div class="paddingBottom15  col-sm-6"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove address" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    }
    else
    {
        $("#divNewAddress").append('<div class="divAddress"><div class="row container oddBackground paddingTop10"><div class="col-sm-6 oddBackground"><div class="form-group"><label class="" for="Street">Street</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Street must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Street]" type="text" value=""></div></div><div class="form-group"><label class="" for="POBOX">POBOX</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field POBOX must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][POBOX]" type="text" value=""></div></div><div class="form-group"><label class="" for="Neighborhood">Neighborhood</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Neighborhood must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Neighborhood]" type="text" value=""></div></div></div><div class="col-sm-6 oddBackground"><div class="form-group"><label class="" for="City">City</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field City must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][City]" type="text" value=""></div></div><div class="form-group"><label class="" for="Province">Province</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Province must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][Province]" type="text" value=""></div></div><div class="form-group"><label class="" for="PostalCode">Postal Code</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field PostalCode must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Addresses[][PostalCode]" type="text" value=""></div></div></div></div><div class="row container oddBackground"><div class="paddingBottom15 oddBackground col-sm-6"><div class="form-group"><label class="" for="Contry">Country</label><div class="country"><input type="text" class="typeahead tt-input form-control text-box single-line isCountry" autocomplete="off" name="Addresses[][Country]" value=""></div></div></div><div class="paddingBottom15 oddBackground col-sm-6"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove address" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);

    }

    oddBackground = !oddBackground;
    ControlsEventBindings();
});

$("#btnAddPhone").click(function () {

    ControlEventUnbindings();

    $("#divNewPhone").append('<div class="divPhone"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">Phone Nr</label><div class=""><input class="form-control text-box single-line" name="Phones[][Number]" type="text" value="" ></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" name="Phones[][Description]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove phone" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);

    ControlsEventBindings();
});

$("#btnAddEmail").click(function () {

    ControlEventUnbindings();

    $("#divNewEmail").append('<div class="divEmail"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">E-Mail</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Email must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Emails[][Email]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Emails[][Description]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove e-mail" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);

    ControlsEventBindings();
});

$("#btnAddWebsite").click(function () {

    ControlEventUnbindings();

    $("#divNewWebsite").append('<div class="divWebsite"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">Website</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Website must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Websites[][Website]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="Websites[][Description]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove website" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);

    ControlsEventBindings();
});

$("#btnAddIM").click(function () {

    ControlEventUnbindings();

    $("#divNewIM").append('<div class="divIM"><div class="row container oddBackground paddingTop10"><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Number">Instant Messaging</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field InstantMessaging must be a string with a maximum length of 50." data-val-length-max="50" id="" name="IMs[][InstantMessaging]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Description">Instant Messaging Contact</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field IMContact must be a string with a maximum length of 50." data-val-length-max="50" id="" name="IMs[][IMContact]" type="text" value=""></div></div></div><div class="col-sm-4 oddBackground"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove IM" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    
    ControlsEventBindings();
});

$("#btnAddInternetCallId").click(function () {

    ControlEventUnbindings();

    $("#divNewInternetCallId").append('<div class="divInternetCalls"><div class="row container oddBackground paddingTop10"><div class=" col-sm-4 oddBackground paddingBottom25"><div class="form-group"><label class="" for="Number">Internet Call Id</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field InternetCallId must be a string with a maximum length of 50." data-val-length-max="50" id="" name="InternetCallIds[][InternetCallId]" type="text" value=""></div></div></div><div class=" col-sm-4 oddBackground paddingBottom25"><div class="form-group"><label class="" for="Description">Description</label><div class=""><input class="form-control text-box single-line" data-val="true" data-val-length="The field Description must be a string with a maximum length of 50." data-val-length-max="50" id="" name="InternetCallIds[][Description]" type="text" value=""></div></div></div><div class=" col-sm-4 oddBackground paddingBottom25"><div class="form-group"><label class="" for="Contry">&nbsp;</label><div class=""><input type="button" value="Remove Internet call id" class="btn btn-default removeDiv"></div></div></div></div></div>').hide().fadeIn(1000);
    
    ControlsEventBindings();
});

// Contact page end

