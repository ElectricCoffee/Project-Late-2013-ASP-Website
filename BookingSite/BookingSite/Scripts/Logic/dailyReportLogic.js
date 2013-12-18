$(document).ready(function () {
    $("#btn-finish").click(function () {
        finishAction();
    });
    $("#btn-approve-booking").click(function () {
        approveBookingAction();
    });
    $("#btn-reject-booking").click(function () {
        rejectBookingAction();
    });
});

function finishAction() {
    var id = 0;
    find(function (row) {
        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });
    window.location.href = "/dailyreport/finish/" + id;
}

function approveBookingAction() {
    var id = 0;
    find(function (row) {
        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });
    window.location.href = "/dailyreport/approve/" + id;
}

function rejectBookingAction() {
    var id = 0;
    find(function (row) {

        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });

    window.location.href = "/dailyreport/reject/" + id;
}