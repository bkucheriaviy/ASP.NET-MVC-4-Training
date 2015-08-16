function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}

function getData() {
    $('.error').hide();
    $.ajax({
        type: "GET",
        url: "api/reservation",
        success: onSuccess
    });
}

function onSuccess(data) {
    var table = $('#tableBody');
    table.empty();
    fillTable(table, data);
    selectFistItemInTable();
    selectView("summary");
}

function fillTable(table, data) {
    for (var i = 0; i < data.length; i++) {
        table.append('<tr><td><input id="id" name="id" type="radio"' + 'value="' + data[i].Id + '"/></td>'
                                                   + '<td>' + data[i].ClientName + '</td>'
                                                   + '<td>' + data[i].Location + '</td>'
        );
    }
}

function selectFistItemInTable() {
    $('input:radio')[0].checked = 'checked';
}

$(document).ready(function () {
    getData();
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked');

        switch (e.target.id) {
        case 'refresh':
            {
                getData();
                break;
            }
        case "delete":
            {
                $.ajax({
                    type: "DELETE",
                    url: "api/reservation/" + selectedRadio.attr('value'),
                    success: function() {
                        selectedRadio.closest('tr').remove();
                        selectFistItemInTable();
                    }               
                });
                break;
            }
        case "add":
            {
                selectView("add");
                break;

            }
        case "edit":
            {
                $.ajax({
                    type: "GET",
                    url: "api/reservation/" + selectedRadio.attr('value'),
                    success: function(data) {
                        $('#editId').val(data.Id);
                        $('#editClientName').val(data.ClientName);
                        $('#editLocation').val(data.Location);
                    }
                });
                selectView("edit");
                break;
            }
            case "editSubmit":
                {
                    $.ajax({
                        type: "PUT",
                        url: "api/reservation/",
                        data: $("#editForm").serialize(),
                        success: function(result) {
                            if (result) {
                                var cells = selectedRadio.closest('tr').children();
                                cells[1].innerText = $('#editClientName').val();
                                cells[2].innerText = $('#editLocation').val();
                            }
                        }
                        
                    });
                    break;
                }
        }
    });
});