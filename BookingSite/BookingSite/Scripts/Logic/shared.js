function find(func) {
    var table = $("#table tr");
    console.log(table.text());
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