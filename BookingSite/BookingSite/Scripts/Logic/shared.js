$(document).ready(function () {
    checkForPendingStudents();
});

function checkForPendingStudents() {
    if (!$("body").is("#approve-student")) {
        $.ajax({
            type: "GET",
            url: "/approvestudent/count",
            dataType: "text",
            contentType: "text/plain",
            success: function (data) {
                console.log(data);
                helper(data);
            },
            error: function (xhr, error, thrown) {
                console.log(xhr.toString() + "\n" + error + " " + thrown);
                var err = eval("(" + xhr.responseText + ")");
                console.log(err.Message);
            }
        });
    }
}

function helper(studentCount) {
    console.log(studentCount);
    if (studentCount > 0)
        popup();
}

function popup() {
    var body = $("body");
    body.append("<div class='popup' href=''>"
        + "<a class='close'>"
        + "<img src='/Content/images/Actions-window-close-icon.png' alt='information_icon'>"
        + "</a>"
        + "<div class='wrapper'>"
        + "<p>"
        + "<img src='/Content/images/Info-icon 64x64.png' />"
        + "<a href='/approvestudent'>Der er nye studerende!</a>"
        + "</p>"
        + "</div>"
        + "</div>");

    $(".popup").slideDown(400).css("display", "inline-block");

    $(".popup .close").click(function () {
        console.log("fading");
        $(".popup").fadeOut(400);
    });
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