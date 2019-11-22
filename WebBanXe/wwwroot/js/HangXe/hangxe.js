var hangxe = hangxe || {};

hangxe.drawDataTable = function() {
    dataTableOption = $("#hangxeView").DataTable({
        "processing": false, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)  
        "orderMulti": false, // for disable multiple column at once  
        "ajax": {
            "url": "/HangXes/Gets",
            "type": "POST",
            "datatype": "json"
        },

        "columns": [
            //{
            //    "data": "hangXeId",
            //    "name": "HangXeId",
            //    "autoWidth": true,
            //    "title": "HangXe ID",
            //    "searchable": true,
            //    "orderable": true
            //},
            {
                "data": "tenHangXe",
                "name": "TenHangXe",
                "autoWidth": true,
                "title": "Ten Hang Xe ",
                "searchable": true,
                "orderable": true
            },
            {
                "data": "img",
                "name": "IMG",
                "autoWidth": true,
                "title": "Anh",
                "searchable": true,
                "orderable": true,
                "render": function(data) {

                    return '<img src="' + data + '" style="width:50px;height:50px;" alt="anh"/>';

                    //return "<video>"+
                    //    "<source  type='video/mp4' src='" + data + "' >" +
                    //"</video>"

                }
            },

            {
                "data": "hangXeId",
                "render": function(data, type, full, meta) {
                    return "<a href='javascript:void(0);' onclick='hangxe.showEditModal(" + data + ")'><i class='fas fa-edit'></i></a>" + ' ' + "<a href='javascript:void(0);' onclick='hangxe.showConfirmDeleteModal(" + data + ")' ><i class='fas fa-trash-alt'></i></a>";
                },
                "title": "Actions",
                "orderable": false
            }
        ]

    });
};

hangxe.showImg = (imagebase64) => {
    if (imagebase64 == "") {
        $('#hienAnh').show();
        $('#Img').hide();
    } else {
        $('#hienAnh').hide();
        $('img[id="Img"]').attr('src', imagebase64);
        $('#Img').show();

    }
};


hangxe.showModel = function() {
    hangxe.resetForm();
    var img = "";
    hangxe.showImg(img);
    $('#addEditHangXe').find(".modal-title").text("Thêm Hang Xe");
    $('#addEditHangXe').modal('show')
};

hangxe.save = function() {
    var objEmployee = {};

    var EmployeeID = $("#HangXeId").val();
    if (EmployeeID == "") {
        objEmployee["HangXeId"] = 0;
    } else {
        objEmployee["HangXeId"] = EmployeeID;
    }
    objEmployee["TenHangXe"] = $("#TenHangXe").val();

    objEmployee["IMG"] = imagebase64;

    console.log(objEmployee["IMG"]);
    //objEmployee["SkillId"] = $("#Skill").val();
    //objEmployee["YearsExperience"] = $("#YearsExperience").val();

    $.ajax({
        url: "HangXes/Save",
        type: 'POST',
        data: JSON.stringify(objEmployee),
        contentType: 'application/json',
        datatype: 'json',
        success: function(data) {
            if (data.status === 1) {
                hangxe.reloadDataTable();
                $('#addEditHangXe').modal('hide');
                hangxe.resetForm();
                //window.location.href = "/Home/Index";

            }
        }
    });
};

var imagebase64 = "";
hangxe.encodeImageFileAsURL = function (element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function() {
        imagebase64 = reader.result;
        if (imagebase64 != "") {
            hangxe.showImg(imagebase64);
         
        }
    }  
    reader.readAsDataURL(file);  
};


hangxe.reloadDataTable = function() {
    dataTableOption.ajax.reload(null, false);
}


hangxe.showConfirmDeleteModal = function (id) {
    bootbox.confirm({
        message: "Bạn muốn xóa hang xe nay không?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                hangxe.Delete(id);
            }
        }
    });
};

hangxe.Delete = (id) => {
    $.ajax({
        url: 'HangXes/Delete/' + id,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json',
        success: function(data) {
            //console.log(data);
            if (data.status === 1) {
                hangxe.reloadDataTable();
                //$('#addEditHangXe').modal('hide');
                //hangxe.resetForm();
                //window.location.href = "/Home/Index";
                //employee.reloadDataTable();
                //employee.resetForm();
                //user.drawDataTable();
            }
        }
    });
};
hangxe.resetForm = function () {
    $('#Img').val('');
    $('#TenHangXe').val('');
    $('#HangXeId').val('');
    $('#TenHangXe').val('');
    $('#IMGFile').val('');
    //$('#YearsExperience').val('');
    //$('#DongXe').prop('selectedIndex', 0);
    //$('#Sex').prop('selectedIndex', 0);
    //employee.initSkill();
};

hangxe.showEditModal = function(id) {
    $.ajax({
        url: 'HangXes/Edit/' + id,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json',
        success: function(data) {
            console.log(data);
            if (data.status === 1) {
                console.log(data.code);
                var response = data.response;
                console.log(response);
                $("#HangXeId").val(response.hangXeId);
                $("#TenHangXe").val(response.tenHangXe);
                //$("#Img").val(response.img);
                var img = response.img;
                hangxe.showImg(img);
                //$('img[id="Img"]').attr('src', img );
                
                //$('img[id="anhchon"]').onloadend(function () {
                //    $(this).attr('src', 'response.img');
                //})
                //$("#SkillId").val(response.SkillId);
                //$("#YearsExperience").val(response.yearsExperience);
                //$("#Skill").prop('selectedIndex', response.skillID);           
                $('#addEditHangXe').find(".modal-title").text("Sửa Hang Xe");
                $('#addEditHangXe').modal('show');


            }
        }
    });
};

hangxe.initClass = () => {
    $.ajax({
        url: 'HangXes/GetDongXe',
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log(data);
            if (data.status === 1) {
                var response = data.response;
                $.each(response, function (index, value) {
                    $('#DongXe').append(
                        "<option value=' + value.dongXeId + '>" + value.tenDongXe + "</option>"
                    );
                });
            }
        }

    });
}

hangxe.initSex = () => {
    $('#Sex').append(
        "<option value='1'>Nam</option><option value='0'>Nu</option>"
    );
}

hangxe.init = function() {
    //employee.initSkill();
    hangxe.resetForm();
    hangxe.drawDataTable();
    hangxe.initClass();
    hangxe.initSex();
};

$(document).ready(function() {
    hangxe.init();
});

//$(document).ready(function() {
//    //$("#employeeView").DataTable();
//    dataTableOption = $("#hangxeView").DataTable({
//        "processing": false, // for show progress bar  
//        "serverSide": true, // for process server side  
//        "filter": true, // this is for disable filter (search box)  
//        "orderMulti": false,
//    });
//});
//$(document).ready(function () {
//    hangxe.showModel();
//});

//render: function (data, type, row) {
//    return '<img src= ' +  + ' width="150px" height="150px">';
//},