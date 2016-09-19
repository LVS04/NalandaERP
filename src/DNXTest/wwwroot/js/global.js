arrCountries = ["Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium ", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", " Central African Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Democratic Republic of the Congo", "Cook Islands", "Costa Rica", "Ivory Coast", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Great", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Holy See", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea", "Korea", "Kosovo", "Kosovo", "Kuwait", "Kyrgyzstan", "Lao", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestinian territories", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn Island", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion Island", "Romania", "Russian Federation", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Tibet", "Timor-Leste", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Ugandax", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City State", "Venezuela", "Vietnam", "Virgin Islands (British)", "Virgin Islands (U.S.)", "Wallis and Futuna Islands", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"];

var substringMatcher = function (strs) {
    return function findMatches(q, cb) {
        var matches, substringRegex;

        // an array that will be populated with substring matches
        matches = [];

        // regex used to determine if a string contains the substring `q`
        substrRegex = new RegExp(q, 'i');

        // iterate through the pool of strings and for any string that
        // contains the substring `q`, add it to the `matches` array
        $.each(strs, function (i, str) {
            if (substrRegex.test(str)) {
                matches.push(str);
            }
        });

        cb(matches);
    };
};


//  Form cleaning - start
//  ---------------------
function fadeOutWipeContent(element) {
    $(element).fadeOut(500, function () {
        ($(this)).remove();
    });
}

function fadeOutWipeChildren(element) {
    $(element).fadeOut(500, function () {
        ($(this)).children().remove();
    });
}


function pad(number, length) {
    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }
    return str;
}


//  String.format
//  -------------
if (!String.format) {
    String.format = function (format) {
        var args = Array.prototype.slice.call(arguments, 1);
        return format.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : match
            ;
        });
    };
}


//  Quick search setup and controls
//  -------------------------------
var varContactsSearch = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('ContactName'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: {
        url: varBloodHoundRemote + '?wildcard=%QUERY',
        wildcard: '%QUERY',        
        filter: function (response) {
            $('#countContact').html(pad(response.total, 6));
            if (response.total > 0) {
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

            return response.rows;
        }
    },
    limit: 10,
});

$('#searchContact.typeahead').typeahead(null, {
    name: 'lookupcontact',
    displayKey: 'ContactName',
    source: varContactsSearch
}).bind('typeahead:select', function (event, data) {
    window.location = '/Contact/Index/' + data.Id;
});

$(document).on('keyup', '#searchContact', function (ev) {
    
    if ($('#searchContact').val().trim().length == 0) {
        $('#countContact').text('000000');
        $('#countContact').removeClass('label-primary');
        $('#countContact').addClass('label-default');
    }
});


//  Advanced search setup and controls
//  ----------------------------------
var milisecondsDelayResponse = 1000;
var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();

var tables = '', tableKeys = '', tablesKeysArray = '', fields = '', valuesArray = '', columns = '', columsArray = '', operators = '', operatorsArray = '', query = '';

function fillSearchDetails(href) {
    $('#search-details').fadeOut(500);
    $.ajax({
        type: "GET",
        url: href,
        data: null,
        success: function (e) {
            var hrefArray = href.split('/');
            $('#search-details').empty();
            $('#search-details').append('<a href="' + editContactLink.substring(0, editContactLink.length - 1) + hrefArray[5] + '" class=\"btn btn-success margin15\">Edit Contact</a>');
            //console.log(e);
            //console.log('--------------------------------------------------------------------------------------------------------------------------');
            //$(e).find('textarea').each(function () {
            //    $(this).css("display","block");
            //});
            //console.log(e);
            $(e).appendTo('#search-details');
            //                        $('#search-details').;
            //                    $('#search-details.tab-pane.fade.in.active').removeClass('in active');
            //                    $('#search-details.tab-pane.fade').addClass('in active');
            $('#divName').hide();
            $('#contact-fields :input').prop('disabled', true);
            $('#contact-fields .btn-add-dyn').hide();
            $('#contact-fields :input.scroller').show();
            $('#contact-fields :input.scroller').prop('disabled', false);
            //                  $('#search-details.tab-pane.fade.in.active').removeClass('in active');
            ////                    $('#search-details #Main.tab.fade').addClass('in active');
            //                   console.log($('#search-details').html());
            //                    $('#search-details').show();

            $('#search-details').fadeIn(500);
            $('body, html').scrollTo('#formContact');
        }
    });
}

function getTree() {
    var oddBackground = true;
    $.ajax({
        type: "POST",
        url: varAdvancedSearchGetTree,
        data: '007',
        success: function (e) {
             
            var $searchTree = $('#searchTree').treeview({
                data: e.gettadata,
                showIcon: false,
                showCheckbox: true,
                onNodeChecked: function (event, node) {
                    if (node.dataType === 'table') {
                        tables = tables + ' ' + node.targetObject + ',';
                        tableKeys = tableKeys + ' \'' + node.targetObject + node.tableKey + '\',';
                    }
                    else {
                        if (node.dataType.includes('string')) {
                            $('#searchControls').append(String.format('<div id="div{0}" {2}><label class="" for="">{1} contains</label><div class="dyn-form-group"><div class=""><input class="form-control text-box single-line zemail detailedSearch" autocomplete="off" id="{0}" name="{0}" type="text" value="" onkeyup="delay(function(){buildQuery()}, milisecondsDelayResponse);"></div></div></div>', node.sourceInput.replace("#", ""), node.text, (oddBackground) ? "class='oddBackground'" : "")).hide().fadeIn(1000);


                            if (node.dataType.includes('numbers')) {

                                //  Accept numbers only on the field
                                $(node.sourceInput).keydown(function (e) {
                                    // Allow: backspace, delete, tab, escape, enter and .
                                    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                                        // Allow: Ctrl+A, Command+A
                                        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                                        // Allow: home, end, left, right, down, up
                                        (e.keyCode >= 35 && e.keyCode <= 40)) {
                                        // let it happen, don't do anything
                                        return;
                                    }
                                    // Ensure that it is a number and stop the keypress
                                    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                                        e.preventDefault();
                                    }
                                });
                            }

                            fields = fields + " $('" + node.sourceInput + "').val(),";
                            columns = columns + ' \'' + node.targetObject + '\',';
                            operators = operators + '\"' + node.sourceInput + '# LIKE \'%{0}%\' \",';
                            //console.debug(colums.length);
                            //oddBackground = !oddBackground;

                        }
                        else if (node.dataType === 'date') {
                            $('#searchControls').append(String.format('<div id="div{0}" {2}><label>{1} ( YYYY-MM-DD )</label><div class="dyn-form-group"><div class=""><div class="divControl"><select class="form-control selectpicker" id="selectpicker{0}"><option value="=" >Equal to </option><option value=">=" >After date</option><option value="<=" >Before date</option><option value="BETWEEN" >Between dates</option></select></div><div class="divControl paddingTop10"><div class="input-group" id="datetimepicker1{0}"><input class="form-control" /><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span></div></div><div class="divControl" id="divDateTo{0}"><label>AND</label><div class="input-group" id="datetimepicker2{0}"><input class="form-control" /><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span></div></div></div></div></div>', node.sourceInput.replace("#", ""), node.text, (oddBackground) ? "class='oddBackground'" : "")).hide().fadeIn(1000);

                            operators = operators + '"' + node.sourceInput + '#= ",';

                            $('#divDateTo' + node.sourceInput.replace("#", "")).hide();

                            $('#datetimepicker1' + node.sourceInput.replace("#", "")).datetimepicker({
                                format: 'YYYY-MM-DD',
                                defaultDate: new Date()
                            }).on('dp.change', function (ev) {

                                $('#datetimepicker2' + node.sourceInput.replace("#", "")).data("DateTimePicker").minDate(ev.date);
                                datesChange(node);
                            });

                            $('#datetimepicker2' + node.sourceInput.replace("#", "")).datetimepicker({
                                format: 'YYYY-MM-DD',
                                defaultDate: new Date()
                            }).on('dp.change', function (ev) {

                                $('#datetimepicker1' + node.sourceInput.replace("#", "")).data("DateTimePicker").maxDate(ev.date);
                                datesChange(node);
                            });


                            $('#selectpicker' + node.sourceInput.replace("#", "")).selectpicker({
                                size: 5
                            }).on('changed.bs.select', function (e) {

                                resetOperator(node);

                                var valuee = $(this).parent().children('.selectpicker').selectpicker('val');

                                operators = operators + '"' + node.sourceInput + '#' + valuee + ' ",';

                                if (valuee === 'BETWEEN') {
                                    $('#divDateTo' + node.sourceInput.replace("#", "")).show(1000);
                                }
                                else
                                    $('#divDateTo' + node.sourceInput.replace("#", "")).hide(1000);

                                datesChange(node);
                            });

                            datesChange(node);
                           // oddBackground = !oddBackground;
                        }
                        else if (node.dataType === 'comboCountry') {
                            $('#searchControls').append(String.format('<div id="div{0}" {2}><label class="" for="">{1} is equal to</label><div class="dyn-form-group"><div class="country"><input type="text" class="typeahead tt-input form-control text-box single-line isCountry" autocomplete="off" id="{0}"></div></div></div>', node.sourceInput.replace("#", ""), node.text, (oddBackground) ? "class='oddBackground'" : "")).hide().fadeIn(1000);

                            $(node.sourceInput + '.typeahead').typeahead({
                                hint: false,
                                highlight: true,
                                minLength: 1
                            },
                            {
                                name: 'arrCountries',
                                source: substringMatcher(arrCountries)
                            });

                            $(node.sourceInput + '.typeahead').on('typeahead:selected', function (e, datum) {
                                buildQuery();
                            });

                            fields = fields + " $('" + node.sourceInput + "').val(),";
                            columns = columns + ' \'' + node.targetObject + '\',';
                            operators = operators + '\"' + node.sourceInput + '# LIKE \'%{0}%\' \",';
                           // oddBackground = !oddBackground;
                        }
                        else if (node.dataType === 'comboSpokenLanguages') {
                            $('#searchControls').append(String.format('<div id="div{0}" {2}><label>{1}</label><div class="dyn-form-group"><div class=""><div class="divControl"><select class="form-control selectpicker" id="selectpicker{0}"><option value="1" >French</option><option value="2" >English</option><option value="3" >Spanish</option><option value="4" >Tibetan</option></select><input type="text" class="hide selectedIds" autocomplete="off" id="hidden{0}" value=""></div></div></div></div></div></div>', node.sourceInput.replace("#", ""), node.text, (oddBackground) ? "class='oddBackground'" : "")).hide().fadeIn(1000);

                            $('#selectpicker' + node.sourceInput.replace("#", "")).selectpicker({
                                size: 5
                            }).on('changed.bs.select', function (e) {
                                var teste = $('#hidden' + node.sourceInput.replace("#", ""));
                                    var valor = $(this).parent().children('.selectpicker').selectpicker('val');
                                    teste.val(valor);
                                    //alert(valor);
                                buildQuery();

                            });
                            
                            fields = fields + " $('#hidden" + node.sourceInput.replace("#", "") + "').val(),";
                            //fields = fields + " $('" + node.sourceInput + "').val(),";
                            //$(node.sourceInput).parent().children('.selectpicker').selectpicker('val');
                            columns = columns + ' \'' + node.targetObject + '\',';
                            operators = operators + '\"' + node.sourceInput + '# LIKE \'%{0}%\' \",';
                            //oddBackground = !oddBackground;

                        }
                        else if (node.dataType === 'ComboReligiousSituation') {

                        }
                        else if (node.dataType === 'comboDonorType') {

                        }
                        else if (node.dataType === 'comboDonorContexts') {

                        }
                        else if (node.dataType === 'comboDonorInterests') {

                        }
                        else if (node.dataType === 'comboContactRelationship') {

                        }

                        $(node.sourceInput).focus();
                    }
                    columnsCount = eval('[' + columns.substr(0, columns.length - 1) + '];');
                    oddBackground = (columnsCount.length % 2) == 0;
                },
                onNodeUnchecked: function (event, node) {
                    if (node.dataType === 'table') {

                        tables = tables.replace(' ' + node.targetObject + ',', '');

                        tableKeys = tableKeys.replace(' \'' + node.targetObject + node.tableKey + '\',', '');

                        //  Uncheck subnodes of fields from the table
                        $.each(node.nodes, function (index, value) {
                            $('#searchTree').treeview('uncheckNode', [value.nodeId, { silent: false }]);
                        });
                    }
                    else {
                        if (node.dataType === 'string') {

                        }
                        else if (node.dataType === 'comboCountry') {
                            $('.typeahead').typeahead('destroy');
                        }
                        else if (node.dataType === 'comboSpokenLanguages') {

                        }
                        else if (node.dataType === 'date') {

                            resetDatesVars(node);
                            //resetOperator(node);

                            $('#datetimepicker1' + node.sourceInput.replace("#", "")).data("DateTimePicker").destroy();
                            $('#datetimepicker2' + node.sourceInput.replace("#", "")).data("DateTimePicker").destroy();

                            $('#selectpicker' + node.sourceInput.replace("#", "")).selectpicker('destroy');

                        }
                        else if (node.dataType === 'ComboReligiousSituation') {

                        }
                        else if (node.dataType === 'comboDonorType') {

                        }
                        else if (node.dataType === 'comboDonorContexts') {

                        }
                        else if (node.dataType === 'comboDonorInterests') {

                        }
                        else if (node.dataType === 'comboContactRelationship') {

                        }

                        fields = fields.replace(" $('" + node.sourceInput + "').val(),", '');
                        columns = columns.replace(' \'' + node.targetObject + '\',', '');
                        fadeOutWipeContent(String.format("#div{0}", node.sourceInput.replace("#", "")));
                        resetOperator(node);
                    }
                    columnsCount = eval('[' + columns.substr(0, columns.length - 1) + '];');
                    oddBackground = (columnsCount.length % 2) == 0;
                    buildQuery();
                },
                onNodeExpanded: function (event, data) {
                    $('#searchTree').treeview('checkNode', [data.nodeId, { silent: false }]);
                },
                onNodeCollapsed: function (event, data) {
                    $('#searchTree').treeview('uncheckNode', [data.nodeId, { silent: false }]);
                }
            });

            $searchTree.treeview('collapseAll', { silent: true });
        }
    });
}

function buildQuery(e) {

    valuesArray = eval('[' + fields.substr(0, fields.length - 1) + '];');
    columnsArray = eval('[' + columns.substr(0, columns.length - 1) + '];');
    tablesKeysArray = eval('[' + tableKeys.substr(0, tableKeys.length - 1) + ']');
    operatorsArray = eval('[' + operators.substr(0, operators.length - 1) + ']');

    var index = 0;
    query = 'SELECT "Contact"."Id" FROM "Contact",' + tables.trim();

    query = query.substr(0, query.length - 1) + " WHERE ";

    if (tablesKeysArray.length > 0) {
        for (index = 0; index < tablesKeysArray.length; index++) {
            query = query + String.format("\"Contact\".\"Id\" = {0} and ", tablesKeysArray[index]);
        }
    }

    if (valuesArray.length > 0) {
        for (index = 0; index < valuesArray.length; index++) {
            var operator = operatorsArray[index]
            if (operatorsArray[index].substr(0, 1) === "#")
            {
                var regularExpressionStr = '#.+#'
                var regExp = new RegExp(regularExpressionStr, "gmi");
                operator = operatorsArray[index].replace(regExp, '');

                if (operator.indexOf('LIKE') == -1)
                {
                    query = query + String.format('{0} {1}{2} and ', columnsArray[index], operator, valuesArray[index]);
                }
                else
                {
                    var fieldAndOperator = String.format('{0} {1} and ', columnsArray[index], operator);
                    query = query + String.format(fieldAndOperator, valuesArray[index]);
                }
            }
        }
        query = query.substr(0, query.length - 5);
    }

    console.log(query);
    console.log(operators);

    //  Send query to get the advanced search rezzzultzzz
    if(valuesArray.length > 0)
    {
        $('#search-results').fadeOut(500);
        $.ajax({
            type: "POST",
            url: varAdvancedSearchQuery,
            data: {
                values: valuesArray,
                columns: columns.substr(0, columns.length - 1),
                tableKeys: tableKeys.substr(0, tableKeys.length - 1),
                operators: JSON.stringify( operators.substr(0, operators.length - 1)),
                tables: tables,
                query: query
            },  
            success: function (e) {
                
                $('#search-results').hide();
                $('#search-results').html(e.results);
                fadeOutWipeChildren('#search-details');

                $("[data-toggle=\"bootgrid\"]").bootgrid({
                    rowCount: [5, 10, 15, -1],
                    navigation: 3, 
                    templates: {
                        search: ""
                    },
                    formatters: {
                        "link": function (column, row) {
                            var l = "<a href='" + hrefContactDetail + "/" + row.Id + "' onclick='fillSearchDetails(this.href);return false;'>detail</a>";
                            return l;
                        }
                    }
                });

                //  kickstart the JIT of the contacts page to shorten first time usage...
                $.ajax({
                    type: "GET",
                    url: hrefContactDetail + '/00000000-0000-0000-0000-000000000000',
                    data: null,
                    success: function (e) {
                    }
                });

                $('#search-results').fadeIn(1000);
            }
        });
    }
};

function betweenQuotes(date) {
    return "'" + date + "'";
}

function resetDatesVars(node) {

    var regularExpressionFields = 'betweenQuotes\\(\\$\\("#datetimepicker1' + node.sourceInput.replace("#", "") + ' :input"\\)\\.val\\(\\)\\)[  \+ " AND " \+ betweenQuotes\\(\\$\\("#datetimepicker2' + node.sourceInput.replace("#", "") + ' :input"\\)\\.val\\(\\)\\)]*,';

    var regExFields = new RegExp(regularExpressionFields, "gmi");
    fields = fields.replace(regExFields, '');

    columns = columns.replace(' \'' + node.targetObject + '\',', '');
}

function resetOperator(node) {

    var regularExpressionStr = '"' + node.sourceInput + '#[=|>=|<=|BETWEEN|\\sLIKE\\s\'%{0}%\']+\\s\",';
    console.log(regularExpressionStr);
    var regExp = new RegExp(regularExpressionStr, "gmi");
    operators = operators.replace(regExp, '');

}

function datesChange(node) {

    resetDatesVars(node);

    //  insert new controls
    columns = columns + ' \'' + node.targetObject + '\',';

    var chosenOperator = $('#selectpicker' + node.sourceInput.replace("#", "")).val();
    if (chosenOperator === 'BETWEEN') {

        fields = fields + 'betweenQuotes($("#datetimepicker1' + node.sourceInput.replace("#", "") + ' :input").val())  + \" AND \" + betweenQuotes($("#datetimepicker2' + node.sourceInput.replace("#", "") + ' :input").val()),';
    }
    else
    {
        fields = fields + 'betweenQuotes($("#datetimepicker1' + node.sourceInput.replace("#", "") + ' :input").val()),';
    }

    buildQuery();
}

getTree();

