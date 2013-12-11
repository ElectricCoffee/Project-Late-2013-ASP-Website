$(document).ready(function () { 
    $("#btn-approve").click(function() {
        approveAction();
    });
});

function approveAction() {
    var id = 0xDEAD;
    find(function(row) {
        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });
    window.location.href = "/approvestudent/approve/" + id;
}