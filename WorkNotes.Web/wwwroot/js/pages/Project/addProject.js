document.addEventListener('DOMContentLoaded', initPage(), false);


function initPage() {
    setTimeout(function () {
        initTargetDate();
        initCode();
        initStatus();
    }, 500);
}

function initTargetDate() {
    $('#TargetDatePicker').datepicker({
        format: 'dd MM yyyy',
        language: 'tr-TR',
        startDate: new Date()
    });
    if (currentDate != undefined && currentDate != '') {
        var timestamp = Date.parse(currentDate);
        var dateObject = new Date(timestamp);
        $("#TargetDatePicker").datepicker("update", dateObject);
    }
}
function initCode() {

    httpGet('/Project/GetCodes', null,
        function (res) {
            $('.typeahead').typeahead({
                hint: true,
                highlight: true,
                minLength: 1
            },
                {
                    name: 'states',
                    displayKey: 'value',
                    source: substringMatcher(res)
                });
        },
        function (err) {
            console.log(err);
        },
    )
}

function initStatus() {
    if ($('#Status').val() == undefined || $('#Status').val() == '') {
        $('#Status').val('1')
    }
}

function substringMatcher(strs) {
    return function findMatches(q, cb) {
        var matches, substrRegex;

        matches = [];

        // check if string contain "q"
        substrRegex = new RegExp(q, 'i');

        // if "q" - add to matches []
        $.each(strs, function (i, str) {
            if (substrRegex.test(str)) {
                matches.push({
                    value: str
                });
            }
        });

        cb(matches);
    };
};

$("#form").submit(function (eventObj) {
    $("<input />").attr("type", "hidden")
        .attr("name", "TargetDate")
        .attr("id", "TargetDate")
        .attr("value", $('#TargetDatePicker').data('datepicker').getFormattedDate('yyyy-mm-dd'))
        .appendTo("#form");
    return true;
})