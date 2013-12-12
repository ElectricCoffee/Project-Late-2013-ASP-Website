$(document).ready(function () {
    console.log("ready!");
    checkForPendingStudents();

    $(".popup .close").click(function () {
        console.log("fading");
        $(".popup").fadeOut(400);
    });
});

function checkForPendingStudents() {
    $.ajax({
        type: "GET",
        url: "http://localhost:14781/api/student/count",
        data: "approved=false",
        dataType: "text",
        contentType: "text/plain",
        error: function (xhr, error, thrown) {
            console.log(xhr.toString() + "\n" + error + " " + thrown);
            var err = eval("(" + xhr.responseText + ")");
            console.log(err.Message);
        }
    }).done(function (msg) {
        console.log("output " + msg.d);
    });
}

function helper(studentCount) {
    console.log(studentCount);
    if (studentCount > 0)
        popup();
}

function popup() {
    $("body").html("<div class='popup'>"
        + "<a class='close' href='#'>"
        + "<img src='~/Content/images/Actions-window-close-icon.png' alt='information_icon'>"
        + "</a>"
        + "<p>"
        + "<img src='~/Content/images/Info-icon 64x64.png' />"
        + "<a href='/approvestudent'>Der er nye studerende!</a>"
        + "</p>"
        + "</div>");

    $(".popup").slideDown(400).css("display", "inline-block");
}

function find(func) {
    var table = $("table tr");
    //console.log(table.text());
    table.each(function (index) {
        if (index != 0) {
            var row = $(this);
            var checkbox = row.find('td input');
            var checked = checkbox.is(":checked");
            if (checked) {
                func(row);
            }
        }
    });
}

function checkAllBoxes() {
    if ($(".master-checkbox").is(":checked")) {
        $(".slave-checkbox").prop("checked", true);
    }
    else {
        $(".slave-checkbox").prop("checked", false);
    }
}