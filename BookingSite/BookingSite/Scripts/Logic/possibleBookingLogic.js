﻿$(document).ready(function () {
    resetFormOnClick();
});

function resetFormOnClick() {
    var checkbox = $("input[type=checkbox]");

    checkbox.click(function (e) {
        if (!checkbox.is(":checked")) {
            $(".input_id").val("");
            $(".input_subject").val("");
            $(".input_date").val("");
            $(".input_start_time").val("");
            $(".input_end_time").val("");
            $("#submit-btn").val("Opret");
            $("#field-heading").text("Opret Vejledningsperiode");
        }
    });
}

function delayAction() {
    var id;
    find(function (row) { id = row.children().eq(1).text(); });
    var form = $(".fields .delay");
    form.attr("action", form.attr("action") + id);
}

function detailAction() {
    var id;
    find(function (row) { id = row.children().eq(1).text(); });
    console.log("ID: " + id);
    window.location.href = "/possiblebooking/details?id=" + id;
}

function editAction() {
    var id, subject, date, startTime, endTime;

    find(function (row) {
        id = row.children().eq(1).text();
        console.log(id);

        subject = row.children().eq(2).text();
        console.log(subject);

        date = row.children().eq(3).children().eq(0).attr("datetime");
        console.log(date);

        startTime = row.children().eq(4).text();
        console.log(startTime);

        endTime = row.children().eq(5).text();
        console.log(endTime);
    });

    var formatDate = date.split("/"); // split on /
    formatDate.reverse(); // reverse it
    date = formatDate[0] + '-' + formatDate[1] + '-' + formatDate[2]; // put it back together with - in between

    $(".input_id").val(id);
    $(".input_subject").val(subject);
    $(".input_date").val(date);
    $(".input_start_time").val(startTime);
    $(".input_end_time").val(endTime);
    $("#submit-btn").val("Redigér");
    $("#field-heading").text("Redigér Vejledningsperiode");
}