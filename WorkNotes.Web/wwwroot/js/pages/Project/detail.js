document.addEventListener('DOMContentLoaded', initPage(), false);

function initPage() {
    setTimeout(function () {
        initTargetDate();
        initCode();
        initStatus();
    }, 500)
};

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

function addNewCheckin() {
    $.magnificPopup.open({
        removalDelay: 500,
        items: {
            src: '#addCheckinModalForm'
        },
        callbacks: {
            beforeOpen: function (e) {
                var Animation = 'mfp-sign';
                this.st.mainClass = Animation;
            }
        },
        midClick: true
    });
};

function addNewNote() {
    $.magnificPopup.open({
        removalDelay: 500,
        items: {
            src: '#addNoteModalForm'
        },
        callbacks: {
            beforeOpen: function (e) {
                var Animation = 'mfp-sign';
                this.st.mainClass = Animation;
            }
        },
        midClick: true
    });
};

function addNewDefinition() {
    $.magnificPopup.open({
        removalDelay: 500,
        items: {
            src: '#addDefinitionModalForm'
        },
        callbacks: {
            beforeOpen: function (e) {
                var Animation = 'mfp-sign';
                this.st.mainClass = Animation;
            }
        },
        midClick: true
    });
};

function textAreaAdjust(o) {
    o.style.height = "1px";
    o.style.height = (20 + o.scrollHeight) + "px";
}

function deleteConfirm(id, code) {
    confirmJs('Proje Siliniyor', code + ' kodlu proje silinecek onaylıyor musunuz ?', function () {
        window.location.replace("/Project/Delete?id=" + id);
    });
}

$("#form").submit(function (eventObj) {
    $("<input />").attr("type", "hidden")
        .attr("name", "TargetDate")
        .attr("id", "TargetDate")
        .attr("value", $('#TargetDatePicker').data('datepicker').getFormattedDate('yyyy-mm-dd'))
        .appendTo("#form");
    return true;
});

