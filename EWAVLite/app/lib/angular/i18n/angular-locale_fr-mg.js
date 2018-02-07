'use strict';
angular.module("ngLocale", [], ["$provide", function ($provide) {
    var PLURAL_CATEGORY = {
        ZERO: "zero",
        ONE: "one",
        TWO: "two",
        FEW: "few",
        MANY: "many",
        OTHER: "other"
    };
    $provide.value("$locale", {
        "DATETIME_FORMATS": {
            "AMPMS": [
                "AM",
                "PM"
            ],
            "DAY": [
                "dimanche",
                "lundi",
                "mardi",
                "mercredi",
                "jeudi",
                "vendredi",
                "samedi"
            ],
            "MONTH": [
                "janvier",
                "f\u00e9vrier",
                "mars",
                "avril",
                "mai",
                "juin",
                "juillet",
                "ao\u00fbt",
                "septembre",
                "octobre",
                "novembre",
                "d\u00e9cembre"
            ],
            "SHORTDAY": [
                "dim.",
                "lun.",
                "mar.",
                "mer.",
                "jeu.",
                "ven.",
                "sam."
            ],
            "SHORTMONTH": [
                "janv.",
                "f\u00e9vr.",
                "mars",
                "avr.",
                "mai",
                "juin",
                "juil.",
                "ao\u00fbt",
                "sept.",
                "oct.",
                "nov.",
                "d\u00e9c."
            ],
            "fullDate": "EEEE d MMMM y",
            "longDate": "d MMMM y",
            "medium": "d MMM y HH:mm:ss",
            "mediumDate": "d MMM y",
            "mediumTime": "HH:mm:ss",
            "short": "dd/MM/yy HH:mm",
            "shortDate": "dd/MM/yy",
            "shortTime": "HH:mm"
        },
        "NUMBER_FORMATS": {
            "CURRENCY_SYM": "\u20ac",
            "DECIMAL_SEP": ",",
            "GROUP_SEP": "\u00a0",
            "PATTERNS": [
                {
                    "gSize": 3,
                    "lgSize": 3,
                    "macFrac": 0,
                    "maxFrac": 3,
                    "minFrac": 0,
                    "minInt": 1,
                    "negPre": "-",
                    "negSuf": "",
                    "posPre": "",
                    "posSuf": ""
                },
                {
                    "gSize": 3,
                    "lgSize": 3,
                    "macFrac": 0,
                    "maxFrac": 2,
                    "minFrac": 2,
                    "minInt": 1,
                    "negPre": "(",
                    "negSuf": "\u00a0\u00a4)",
                    "posPre": "",
                    "posSuf": "\u00a0\u00a4"
                }
            ]
        },
        "id": "fr-mg",
        "pluralCat": function (n) {
            if (n >= 0 && n <= 2 && n != 2) {
                return PLURAL_CATEGORY.ONE;
            }
            return PLURAL_CATEGORY.OTHER;
        }
    });
}]);