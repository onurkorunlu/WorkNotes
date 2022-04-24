// Http Begin
function httpGet(url, data, success, failure) {

    $.ajax({
        type: "GET",
        url: url,
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
        url: url,
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
