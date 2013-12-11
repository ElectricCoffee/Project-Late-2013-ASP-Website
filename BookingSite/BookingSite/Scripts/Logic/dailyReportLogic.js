$(document).ready(function () {
    $("#btn-finish").click(function () {
        finishAction();
    });
});

function finishAction() {
    var id = 0;
    find(function (row) {
        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });
    window.location.href = "/dailyrepport/finish/" + id;
}