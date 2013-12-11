$(document).ready(function () { 
    $("#btn-approve").click(function() {
        approveAction();
    });
    $("#btn-reject").click(function() {
        rejectAction();
    });
});

function approveAction() {
    var id = 0;
    find(function(row) {
        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });
    window.location.href = "/approvestudent/approve/" + id;
}

function  rejectAction() {
    var id = 0;
    find(function(row) {

        id = row.children().eq(1).text();
        console.log("ID: " + id);
    });
    
    window.location.href = "/approvestudent/reject/" + id;
}