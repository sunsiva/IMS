$(document).ready(function () {

    $('#rdoIsDrawYes').click(function () {
        $('#fls_upload').hasClass('hide') ? $('#fls_upload').removeClass('hide') && $('#fls_upload').addClass('show') : "";
    });

    $('#rdoIsDrawNo').click(function () {
        $('#fls_upload').hasClass('hide') ? "" : $('#fls_upload').removeClass('show') && $('#fls_upload').addClass('hide');
    });

    $('.date-picker').datetimepicker({
        format: 'MM/DD/YYYY'
    });

    $("#btnRFQSave").click(function () {
        if ($("#rdoIsDrawYes").is(":Checked") && $("#file").val()=="") {
            $("#errMsgDocUpload").text("Please select a file to upload.");
            return false;
        } else
        if ($("#file").val() != "" && fileSizeExceed()) {
            $("#errMsgDocUpload").text("Please upload a file which is less than 350KB.");
            return false;
        } else
        {
            $("#RFQForm").submit();
        }
    });

    window.fileSizeExceed = function () {
        var fileInput = $("#file")[0];
        var imgbytes = fileInput.files[0].size; //Size returned in bytes.
        var imgkbytes = Math.round(parseInt(imgbytes) / 1024);
        if (imgkbytes > 335) {
            return true;
        } else {
            return false;
        }
    };

    $('p input[type="button"]').click(function () {
        $('#myTable').append('<tr><td><input type="text" class="fname" /></td><br><br><td><input type="button"  class="glyphicon glyphicon-remove" value="Delete" /></td></tr>')
    });

    $('#myTable').on('click', 'input[type="button"]', function () {
        $(this).closest('tr').remove();
    })

    var rowCount = 1; 
    window.addMoreRows = function (frm) {
        rowCount++;
        var recRow = '<p id="rowCount' + rowCount + '"><tr><td><input name="" type="text" size="17%" maxlength="120" style="margin: 4px 5px 0 5px;"/></td><td><input name="" type="text" maxlength="120" style="margin: 4px 5px 0 5px;" /></td><td><input name="" type="text" maxlength="120" style="margin: 4px 10px 0 5px;"/></td></tr> <a href="javascript:void(0);" onclick="removeRow(' + rowCount + ');">Delete</a></p>';
        jQuery('#addedRows').append(recRow);
    };
    
    window.removeRow = function (removeNum) {
        jQuery('#rowCount' + removeNum).remove();
    };

    //$(function() { //Add, Save, Edit and Delete functions code
    //    //$(".btnEdit").bind("click", Edit);
    //    $(".btnDelete").bind("click", Delete);
    //    $("#btnAdd").bind("click", Add);
    //});

    ////BEGIN:
    //function Add() {
    //    $("#tblData tbody").append("<tr>" + "<td><input type='text'/></td>" + "<td><input type='text'/></td>" + "<td><input type='text'/></td>" +
    //        "<td><img src='images/disk.png' class='btnSave'><img src='images/delete.png' class='btnDelete'/></td>" + "</tr>");
    //    //$(".btnSave").bind("click", Save);
    //    $(".btnDelete").bind("click", Delete);
    //};

    //function Delete(){
    //    var par = $(this).parent().parent(); //tr
    //    par.remove();
    //};

});