//  String.format
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
function getTree() {
    // Some logic to retrieve, or generate tree structure

        var data = [
		{
		    text: "Prefix",
		    dataType: "string",
		    targetObject: "\"Contact\".\"Prefix\"",
		    sourceInput: "#ContactPrefix"
		},
		{
		    text: "First name",
		    dataType: "string",
		    targetObject: "\"Contact\".\"FirstName\"",
		    //sourceInput: "#ContactFirstName"
		    sourceInput: "#ContactFirstName"
		},
		{
		    text: "Last name",
		    dataType: "string",
		    targetObject: "\"Contact\".\"LastName\"",
		    //sourceInput: "#ContactLastName"
		    sourceInput: "#ContactLastName"
		},
		{
		    text: "Suffix",
		    dataType: "string",
		    targetObject: "\"Contact\".\"Suffix\"",
			sourceInput: "#ContactSuffix"
		},
		{
		    text: "Gender",
		    dataType: "comboGender", //  Drop-down list 1
		    targetObject: "\"Contact\".\"Gender\"",
			sourceInput: "#ContactGender"
		},
		{
		    text: "Birthdate",
		    dataType: "date",
		    targetObject: "\"Contact\".\"Birthdate\"",
			sourceInput: "#ContactBirthdate"
		},
		{
		    text: "Position and company",
		    dataType: "string",
		    targetObject: "\"Contact\".\"PositionAndCompany\"",
			sourceInput: "#ContactPositionAndCompany"
		},
		{
		    text: "Nickname",
		    dataType: "string",
		    targetObject: "\"Contact\".\"NickName\"",
			sourceInput: "#ContactNickName"
		},
		{
		    text: "Notes",
		    dataType: "string",
		    targetObject: "\"Contact\".\"Notes\"",
			sourceInput: "#ContactNotes"
		},
		{
		    text: "History with the center",
		    dataType: "string",
		    targetObject: "\"Contact\".\"HistoryWithTheCenter",
			sourceInput: "#ContactHistoryWithTheCenter"
		},
		{
		    text: "Food allergies",
		    dataType: "string",
		    targetObject: "\"Contact\".\"FoodAllergies\"",
			sourceInput: "#ContactFoodAllergies"
		},
		{
		    text: "Addresses",
		    dataType: "table",
            tableKey: ".\"ContactId\"",
		    targetObject: "\"ContactAddress\"",
			sourceInput: "#ContactAddress",
		    nodes: [
				{
				    text: "Street",
				    dataType: "string",
				    targetObject: "\"ContactAddress\".\"Street\"",
					sourceInput: "#ContactAddressStreet"
		        },
				{
				    text: "POBOX",
				    dataType: "string",
				    targetObject: "\"ContactAddress\".\"POBOX\"",
					sourceInput: "#ContactAddressPOBOX"
				},
				{
				    text: "Neighborhood",
				    dataType: "string",
				    targetObject: "\"ContactAddress\".\"Neighborhood\"",
					sourceInput: "#ContactAddressNeighborhood"
				},
				{
				    text: "City",
				    dataType: "string",
				    targetObject: "\"ContactAddress\".\"City\"",
					sourceInput: "#ContactAddressCity"
				},
				{
				    text: "Province",
				    dataType: "string",
				    targetObject: "\"ContactAddress\".\"Province\"",
					sourceInput: "#ContactAddressProvince"
				},
				{
				    text: "Postal code",
				    dataType: "string",
				    targetObject: "\"ContactAddress\".\"PostalCode\"",
					sourceInput: "#ContactAddressPostalCode"
				},
				{
				    text: "Country",
				    dataType: "comboCountry",
				    targetObject: "\"ContactAddress\".\"Country\"",
					sourceInput: "#ContactAddressCountry"
				}
		    ]
		},
		{
		    text: "Phones",
		    dataType: "table",
		    tableKey: ".\"ContactId\"",
            targetObject: "\"ContactPhone\"",
		    nodes: [
				{
				    text: "Number",
				    dataType: "string:numbers",
				    targetObject: "\"ContactPhone\".\"Number\"",
					sourceInput: "#ContactPhoneNumber"
				},
				{
				    text: "Description",
				    dataType: "string",
				    targetObject: "\"ContactPhone\".\"Description\"",
					sourceInput: "#ContactPhoneDescription"
				}
		    ]
		},
		{
		    text: "Emails",
		    dataType: "table",
		    tableKey: ".\"ContactId\"",
		    targetObject: "\"ContactEmail\"",
		    nodes: [
				{
				    text: "Email",
				    dataType: "string:email",
				    targetObject: "\"ContactEmail\".\"Email\"",
					sourceInput: "#ContactEmailEmail"
				},
				{
				    text: "Description",
				    dataType: "string",
				    targetObject: "\"ContactEmail\".\"Description\"",
					sourceInput: "#ContactEmailDescription"
				}
		    ]
		},
		{
		    text: "Websites",
		    dataType: "table",
		    tableKey: ".\"ContactId\"",
		    targetObject: "\"ContactWebsite\"",
		    nodes: [
				{
				    text: "Website",
				    dataType: "string:website",
				    targetObject: "\"ContactWebsite\".\"WebSite\"",
					sourceInput: "#ContactWebsiteWebSite"
				},
				{
				    text: "Description",
				    dataType: "string",
				    targetObject: "\"ContactWebsite\".\"Description\"",
					sourceInput: "#ContactWebsiteDescription"
				}
		    ]
		},
		{
		    text: "Identification",
		    dataType: "table",
		    tableKey: ".\"Id\"",
		    targetObject: "\"ContactIdentification\"",
		    nodes: [
				{
				    text: "Id or passport",
				    dataType: "string",
				    targetObject: "\"ContactIdentification\".\"IdOrPassport\"",
					sourceInput: "#ContactIdentificationIdOrPassport"
				},
				{
				    text: "Id or passport issue date",
				    dataType: "date",
				    targetObject: "\"ContactIdentification\".\"IdOrPassportIssueDate\"",
					sourceInput: "#ContactIdentificationIdOrPassportIssueDate"
				},
				{
				    text: "Id or passport expiry date",
				    dataType: "date",
				    targetObject: "\"ContactIdentification\".\"IdOrPassportExpiryDate\"",
					sourceInput: "#ContactIdentificationIdOrPassportExpiryDate"
				},
				{
				    text: "Fiscal Id",
				    dataType: "string",
				    targetObject: "\"ContactIdentification\".\"FiscalId\"",
					sourceInput: "#ContactIdentificationFiscalId"
				},
				{
				    text: "Born in country",
				    dataType: "comboCountry",
				    targetObject: "\"ContactIdentification\".\"BornInCountry\"",
					sourceInput: "#ContactIdentificationBornInCountry"
				},
				{
				    text: "Spoken languages",
				    dataType: "comboSpokenLanguages",
				    targetObject: "\"ContactIdentification\".\"SpokenLanguages\"",
					sourceInput: "#ContactIdentificationSpokenLanguages"
				}
		    ]
		},
		{
		    text: "Donor Info",
		    dataType: "table",
		    tableKey: ".\"Id\"",
		    targetObject: "\"ContactDonorInfo\"",
		    nodes: [
				{
				    text: "Donor religious situation",
				    dataType: "ComboReligiousSituation",
				    targetObject: "\"ContactDonorInfo\".\"DonorReligiousSituationId\"",
					sourceInput: "#ContactDonorInfoDonorReligiousSituationId"
				},
				{
				    text: "Donor type",
				    dataType: "comboDonorType",
				    targetObject: "\"ContactDonorInfo\".\"DonorTypeId\"",
					sourceInput: "#ContactDonorInfoDonorTypeId"
				},
				{
				    text: "Donor contexts",
				    dataType: "comboDonorContexts",
				    targetObject: "\"ContactDonorInfo\".\"DonorContexts\"",
					sourceInput: "#ContactDonorInfoDonorContexts"
				},
				{
				    text: "Donor interests",
				    dataType: "comboDonorInterests",
				    targetObject: "\"ContactDonorInfo\".\"DonorInterests\"",
					sourceInput: "#ContactDonorInfoDonorInterests"
				}
		    ]
		},
		{
		    text: "HealthInfo",
		    dataType: "table",
		    tableKey: ".\"Id\"",
		    targetObject: "\"ContactHealthInfo\"",
		    nodes: [
				{
				    text: "Emergency contact 1 name",
				    dataType: "string",
				    targetObject: "\"ContactHealthInfo\".\"EmergencyContact1Name\"",
					sourceInput: "#ContactHealthInfoEmergencyContact1Name"
				},
				{
				    text: "Emergency contact1 relationship",
				    dataType: "comboContactRelationship",
				    targetObject: "\"ContactHealthInfo\".\"EmergencyContact1Id\"",
					sourceInput: "#ContactHealthInfoEmergencyContact1Id"
				},
				{
				    text: "Emergency contact 2 name",
				    dataType: "string",
				    targetObject: "\"ContactHealthInfo\".\"EmergencyContact2Name\"",
					sourceInput: "#ContactHealthInfoEmergencyContact2Name"
				},
				{
				    text: "Emergency contact2 relationship",
				    dataType: "comboContactRelationship",
				    targetObject: "\"ContactHealthInfo\".\"EmergencyContact2RelationshipId\"",
					sourceInput: "#ContactHealthInfoEmergencyContact2RelationshipId"
				},
				{
				    text: "Health insurance provider",
				    dataType: "string",
				    targetObject: "\"ContactHealthInfo\".\"HealthInsuranceProvider\"",
					sourceInput: "#ContactHealthInfoHealthInsuranceProvider"
				},
				{
				    text: "Health insurance policy nr",
				    dataType: "string",
				    targetObject: "\"ContactHealthInfo\".\"HealthInsurancePolicyNr\"",
					sourceInput: "#ContactHealthInfoHealthInsurancePolicyNr"
				},
				{
				    text: "Allergies to medications",
				    dataType: "string",
				    targetObject: "\"ContactHealthInfo\".\"AllergiesToMedications\"",
					sourceInput: "#ContactHealthInfoAllergiesToMedications"
				},
				{
				    text: "Details to inform emergency services",
				    dataType: "string",
				    targetObject: "\"ContactHealthInfo\".\"DetailsToInformEmergencyServices\"",
					sourceInput: "#ContactHealthInfoDetailsToInformEmergencyServices"
				}//,
				//{
				//    text: "PrescribedMedicationInLast4MonthsAndReasons"
				//},
				//{
				//    text: "PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years"
				//{
				//},
				//    text: "MedicalConditionsToConsiderInEventOfEmergency"
				//},
				//{
				//    text: "RestrictivePhysicalProblems"
				//}
		    ]
		}
    ];
    return data;
}

var tables = '';
var tableKeys = '';
var tablesKeysArray = '';
//var fields = "[$('#FirstName').val(), $('#LastName').val()];";
var fields = '';
var valuesArray = '';
var columns = '';
var columsArray = '';
var operators = '';
var operatorsArray = '';
var query = '';

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
            query = query + String.format('"Contact"."Id" = {0} and ', tablesKeysArray[index]);
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

                query = query + String.format('{0} {1}{2} and ', columnsArray[index], operator, valuesArray[index]);
            }
            else
            {
                var fieldAndOperator = String.format('{0} {1} and ',columnsArray[index], operator);
                query = query + String.format(fieldAndOperator, valuesArray[index]);
            }
                
        }
        query = query.substr(0, query.length - 5);
    }
    console.log(query);
};

function betweenCommas(date) {
    return "'" + date + "'";
}

function resetDatesVars(node) {

    var regularExpressionFields = 'betweenCommas\\(\\$\\("#datetimepicker1' + node.sourceInput.replace("#", "") + ' :input"\\)\\.val\\(\\)\\)[  \+ " AND " \+ betweenCommas\\(\\$\\("#datetimepicker2' + node.sourceInput.replace("#", "") + ' :input"\\)\\.val\\(\\)\\)]*,';

    var regExFields = new RegExp(regularExpressionFields, "gmi");
    fields = fields.replace(regExFields, '');

    columns = columns.replace(' \'' + node.targetObject + '\',', '');
}

function resetDatesOperators(node) {

    var regularExpressionStr = '"' + node.sourceInput + '#[=|>=|<=|BETWEEN]+\\s\",'
    var regExp = new RegExp(regularExpressionStr, "gmi");
    operators = operators.replace(regExp, '');
}

function datesChange(node) {

    resetDatesVars(node);

    //  insert new controls
    columns = columns + ' \'' + node.targetObject + '\',';

    var chosenOperator = $('#selectpicker' + node.sourceInput.replace("#", "")).val();
    if (chosenOperator === 'BETWEEN') {

        fields = fields + 'betweenCommas($("#datetimepicker1' + node.sourceInput.replace("#", "") + ' :input").val())  + \" AND \" + betweenCommas($("#datetimepicker2' + node.sourceInput.replace("#", "") + ' :input").val()),';
    }
    else
    {
        fields = fields + 'betweenCommas($("#datetimepicker1' + node.sourceInput.replace("#", "") + ' :input").val()),';
    }

    buildQuery();
}

var $searchTree = $('#searchTree').treeview({
    data: getTree(),
    showIcon: false,
    showCheckbox: true,
    onNodeChecked: function (event, node) {
        if (node.dataType === 'table'){
            tables = tables + ' ' + node.targetObject + ',';
            tableKeys = tableKeys + ' \'' + node.targetObject + node.tableKey + '\',';
        }
        else
        {
            if (node.dataType.includes('string')) {
                $('#searchControls').append(String.format('<div id="div{0}"><div class="form-group"><label class="" for="">{1} contains</label><div class=""><input class="form-control text-box single-line zemail detailedSearch" autocomplete="off" id="{0}" name="{0}" type="text" value="" onkeyup="buildQuery();"></div></div></div>', node.sourceInput.replace("#", ""), node.text)).hide().fadeIn(1000);


                if(node.dataType.includes('numbers'))
                {

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
                operators = operators + '\" LIKE \'%{0}%\'\",';

            }
            else if (node.dataType === 'date') {
                $('#searchControls').append(String.format('<div id="div{0}"><label>{1} ( YYYY-MM-DD )</label><div class="form-group"><div class=""><div class="divControl"><select class="form-control selectpicker" id="selectpicker{0}"><option value="=" >Equal to </option><option value=">=" >After date</option><option value="<=" >Before date</option><option value="BETWEEN" >Between dates</option></select></div><div class="divControl paddingTop10"><div class="input-group" id="datetimepicker1{0}"><input class="form-control" /><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span></div></div><div class="divControl" id="divDateTo{0}"><label>AND</label><div class="input-group" id="datetimepicker2{0}"><input class="form-control" /><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span></div></div></div></div></div>', node.sourceInput.replace("#", ""), node.text)).hide().fadeIn(1000);

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

                    resetDatesOperators(node);

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
            }
            else if (node.dataType === 'comboCountry') {
                $('#searchControls').append(String.format('<div id="div{0}"><div class="form-group"><label class="" for="Country">{1} is equal to</label><div class="country"><input type="text" class="typeahead tt-input form-control text-box single-line isCountry" autocomplete="off" id="{0}"></div></div></div>', node.sourceInput.replace("#", ""), node.text)).hide().fadeIn(1000);

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
                operators = operators + '\" LIKE \'%{0}%\'\",';
            }
            else if (node.dataType === 'comboSpokenLanguages') {

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
        else
        {
            if (node.dataType === 'string')
            {
                
            } 
            else if (node.dataType === 'comboCountry') {
                $('.typeahead').typeahead('destroy');
            }
            else if (node.dataType === 'comboSpokenLanguages') {

            }
            else if (node.dataType === 'date') {

                resetDatesVars(node);
                resetDatesOperators(node);

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
        }
        buildQuery();
    },
    onNodeExpanded: function(event, data) {
        $('#searchTree').treeview('checkNode', [data.nodeId, { silent: false }]);
    },
    onNodeCollapsed: function (event, data) {
        $('#searchTree').treeview('uncheckNode', [data.nodeId, { silent: false }]);
    }
});

$searchTree.treeview('collapseAll', { silent: true });
