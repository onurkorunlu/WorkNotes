// Http Begin
function httpGet(url, data, success, failure) {

    $.ajax({
        type: "GET",
        url: '/WorkNotes' + url,
        data: data,
        success:
            function (result) {
                console.log(url + '>>')
                console.log(result);

                if (result.isSuccess) {
                    if (result.showNotification) {
                        displaySuccess(result.message);
                    }
                    if (success != null) {
                        success(result.data);
                    }
                }
                else {
                    if (result.showNotification) {
                        displayError(result.message);
                    }
                    if (failure != null) {
                        failure(result.data);
                    }
                }
            },
        error:
            function errorFunc(error) {
                if (error.status == '401') {
                    displayError('Authentication required.');
                }
                else if (failure != null) {
                    displayError("İşleminizi şuanda gerçekleştiremiyoruz.")
                }
            },
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded' // Note the appropriate header
        }
    });
}

function post(url, data, success, failure) {

    $.ajax({
        type: "POST",
        url: '/WorkNotes' + url,
        data: data,
        success: successFunc,
        error: errorFunc,
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded' // Note the appropriate header
        }
    });

    function successFunc(result) {
        console.log(url + '>>')
        console.log(result);
        if (result.data.isSuccess) {
            if (result.data.showNotification) {
                displaySuccess(result.data.message);
            }
            if (success != null) {
                success(result.data);
            }
        }
        else {
            if (result.data.showNotification) {
                displayError(result.data.message);
            }
            if (failure != null) {
                failure(result.data);
            }
        }
    }

    function errorFunc(error) {
        if (error.status == '401') {
            displayError('Authentication required.');
        }
        else if (failure != null) {
            displayError("İşleminizi şuanda gerçekleştiremiyoruz.")
        }
    };
}
// Http End

// Notification Begin
function displaySuccess(message) {
    Snackbar.show({
        text: message,
        pos: 'bottom-right',
        actionTextColor: '#fff',
        backgroundColor: '#8dbf42'
    });
}

function displayError(error) {
    if (Array.isArray(error)) {
        error.forEach(function (err) {
            Snackbar.show({
                text: err,
                pos: 'bottom-right',
                actionTextColor: '#fff',
                backgroundColor: '#e7515a'
            });
        });
    } else {
        Snackbar.show({
            text: error,
            pos: 'bottom-right',
            actionTextColor: '#fff',
            backgroundColor: '#e7515a'
        });
    }
}

function displayWarning(message) {
    Snackbar.show({
        text: message,
        pos: 'bottom-right',
        actionTextColor: '#fff',
        backgroundColor: '#e2a03f'
    });
}

function displayInfo(message) {
    Snackbar.show({
        text: message,
        pos: 'bottom-right',
        actionTextColor: '#fff',
        backgroundColor: '#2196f3'
    });
}
// Notification End

// ConfirmJS Begin
function confirmJs(title, content, confirmFunction) {
    $.confirm({
        title: title,
        content: content,
        buttons: {
            cancel: {
                text: 'İptal',
                btnClass: 'btn-default',
                keys: ['esc'],
            },
            confirm: {
                text: 'Evet',
                btnClass: 'btn-blue',
                keys: ['enter'],
                action: confirmFunction
            }
        }
    });
}

function alertJs(title, content) {
    $.alert({
        title: title,
        content: content
    });
}

function alertInputJs(title, labelTitle, inputPlaceHolder) {
    $.confirm({
        title: title,
        content: '' +
            '<form action="" class="formName">' +
            '<div class="form-group">' +
            '<label>' + labelTitle + '</label>' +
            '<input type="text" placeholder="' + inputPlaceHolder + '" class="alertInput form-control" required />' +
            '</div>' +
            '</form>',
        buttons: {
            formSubmit: {
                text: 'Submit',
                btnClass: 'btn-blue',
                action: function () {
                    var alertInputValue = this.$content.find('.alertInput').val();
                    if (!alertInputValue) {
                        $.alert('Lütfen giriş yapınız.');
                        return false;
                    }
                    alertInputJsSubmit(alertInputValue);
                }
            },
            cancel: function () {
                //close
            },
        },
        onContentReady: function () {
            // bind to events
            var jc = this;
            this.$content.find('form').on('submit', function (e) {
                // if the user submits the form by pressing enter in the field.
                e.preventDefault();
                jc.$$formSubmit.trigger('click'); // reference the button and click it
            });
        }
    });
}
// ConfirmJs End

// methods

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

function NewGuid() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}