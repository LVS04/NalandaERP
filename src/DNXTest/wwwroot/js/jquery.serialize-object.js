/**
 * jQuery serializeObject
 * @copyright 2014, macek <paulmacek@gmail.com>
 * @link https://github.com/macek/jquery-serialize-object
 * @license BSD
 * @version 2.5.0
 */
(function(root, factory) {

  // AMD
  if (typeof define === "function" && define.amd) {
    define(["exports", "jquery"], function(exports, $) {
      return factory(exports, $);
    });
  }

  // CommonJS
  else if (typeof exports !== "undefined") {
    var $ = require("jquery");
    factory(exports, $);
  }

  // Browser
  else {
    factory(root, (root.jQuery || root.Zepto || root.ender || root.$));
  }

}(this, function(exports, $) {

  var patterns = {
    validate: /^[a-z_][a-z0-9_]*(?:\[(?:\d*|[a-z0-9_]+)\])*$/i,
    key:      /[a-z0-9_]+|(?=\[\])/gi,
    push:     /^$/,
    fixed:    /^\d+$/,
    named:    /^[a-z0-9_]+$/i
  };

  function FormSerializer(helper, $form) {

    // private variables
    var data     = {},
        pushes   = {};

    // private API
    function build(base, key, value) {
      base[key] = value;
      return base;
    }

    function makeObject(root, value) {

      var keys = root.match(patterns.key), k;

      // nest, nest, ..., nest
      while ((k = keys.pop()) !== undefined) {
        // foo[]
        if (patterns.push.test(k)) {
          var idx = incrementPush(root.replace(/\[\]$/, ''));
          value = build([], idx, value);
        }

        // foo[n]
        else if (patterns.fixed.test(k)) {
          value = build([], k, value);
        }

        // foo; foo[bar]
        else if (patterns.named.test(k)) {
          value = build({}, k, value);
        }
      }

      return value;
    }

    function incrementPush(key) {
      if (pushes[key] === undefined) {
        pushes[key] = 0;
      }
      return pushes[key]++;
    }

    function encode(pair) {
      switch ($('[name="' + pair.name + '"]', $form).attr("type")) {
        case "checkbox":
          return pair.value === "on" ? true : pair.value;
        default:
          return pair.value;
      }
    }

    function addPair(pair) {
      if (!patterns.validate.test(pair.name)) return this;
      var obj = makeObject(pair.name, encode(pair));
      data = helper.extend(true, data, obj);
      return this;
    }

    function addPairs(pairs) {
      if (!helper.isArray(pairs)) {
        throw new Error("formSerializer.addPairs expects an Array");
      }
      for (var i=0, len=pairs.length; i<len; i++) {
        this.addPair(pairs[i]);
      }
      return this;
    }

    function serialize() {
      return data;
    }

    function serializeJSON() {
      return JSON.stringify(serialize());
    }

    // public API
    this.addPair = addPair;
    this.addPairs = addPairs;
    this.serialize = serialize;
    this.serializeJSON = serializeJSON;
  }

  FormSerializer.patterns = patterns;

  FormSerializer.serializeObject = function serializeObject() {
    return new FormSerializer($, this).
      addPairs(this.serializeArray()).
      serialize();
  };

  FormSerializer.serializeJSON = function serializeJSON() {
    return new FormSerializer($, this).
      addPairs(this.serializeArray()).
      serializeJSON();
  };

  if (typeof $.fn !== "undefined") {
    $.fn.serializeObject = FormSerializer.serializeObject;
    $.fn.serializeJSON   = FormSerializer.serializeJSON;
  }

  exports.FormSerializer = FormSerializer;

  return FormSerializer;
}));




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
        }/*,
        'Addresses[][Country]': {
            required: true
        }*/,
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
            url:true
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
                    clearForm();
                }
            });
        }
        return false;
    } 
    return false;
});

