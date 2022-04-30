document.addEventListener('DOMContentLoaded', addDeployPackageInit(), false);

function addDeployPackageInit() {
    setTimeout(function () {

    }, 500)
};


function addNewDeployment(id) {
    $.magnificPopup.open({
        removalDelay: 500,
        items: {
            src: '#addDeploymentModalForm-' + id
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