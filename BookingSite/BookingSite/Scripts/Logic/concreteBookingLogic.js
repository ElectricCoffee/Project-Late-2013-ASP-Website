$(document).ready(function () {
    deleteOnClick(); // load the deleteOnClick function
});

function deleteAction() {
    var id;
    find(function(row) { // find the checked checkbox
        id = row.children().eq(1).text(); // set the id to be the second element's text (first element is the checkbox)
    });
    console.log("ID: " + id); // log the found ID
    $.ajax({
        type: "DELETE",
        url: "/Booking/DeleteBooking",
        data: JSON.stringify({id: id}),
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    });
}

function deleteOnClick() {
    var btn = $("#btn-delete"); // define the button as a <??? id="btn-delete">

    btn.click(function (e) {
        var dialogResult = confirm("Er du sikker på du vil slette de(n) valgte booking(er)?");

        if (dialogResult == true)
            deleteAction();
        else
            e.preventDefault();
    });
}