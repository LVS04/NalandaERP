var varContactsSearch = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('ContactName'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: {
        url: varBloodHoundRemote + '?wildcard=%QUERY',
        wildcard: '%QUERY',
        filter: function (response) {
            $('#countContact').html(pad(response.length, 3));
            if (response.length > 0) {
                $('#countContact').click(function (event) {
                    window.location = varContactList + '/?wildcard=' + $('#searchContact').val();
                });
                $('#countContact').css('cursor', 'pointer');
                $('#countContact').addClass('label-primary');
                $('#countContact').removeClass('label-default');
            }
            else {
                $('#countContact').click(false);
                $('#countContact').css('cursor', 'auto');
                $('#countContact').removeClass('label-primary');
                $('#countContact').addClass('label-default');
            }

            return response;
        }
    }
});

$('#searchContact.typeahead').typeahead(null, {
    name: 'lookupcontact',
    displayKey: 'ContactName',
    source: varContactsSearch
}).bind('typeahead:select', function (event, data) {
    window.location = '/Contact/Index/' + data.Id;
});
