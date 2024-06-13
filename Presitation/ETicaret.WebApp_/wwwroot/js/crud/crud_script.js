
//Remove
function remove(url, id) {

    $(".btn_delete").data("id", id);
    $(".btn_delete").data("url",url);
}

    $(".btn_delete").click(function () {
        $.ajax({

            type: "post",
            url: $(this).data("url") + "?id=" + $(this).data("id"),
            success: function () {

                loadData(_page);
                $("#exampleDeleteModal").modal("hide");

            },
            error: function () {
                alert("eroor!!!");
            }

        });
        });

//File
var _url;
var _id;
var _addurl;
var _removeurl;
function loadfiledata(url, id,addurl, removeurl) {
    _url = url;
    _id = id;
    _addurl = addurl;
    _removeurl = removeurl;

    $.ajax({
        type: "get",
        url: url+"?id=" + id,
        success: function (data) {


            $("#show-images").html('');
            $.each(data, function (index, item) {
              
                $('#show-images').append(`

                                 <div class="col-md-4">


                           <div class="card" style="width: 10rem;">
                                  <img src="${item.base64}" class="card-img-top" alt="...">
                          <div class="card-body">
                             <button  onclick="removefile('${item.id}','${item.fileId}','${removeurl}')" class="btn btn-danger imageRemove">Remove</button>
                          </div>
                        </div>
                                  </div>

                                     `);
            });
        },
        error: function () {
            alert("eroor!!!");
        }

    });

}

function removefile(id, fileid, url) {

    var Isdelete = confirm("do you deleted file?");
    if (Isdelete) {
        $.ajax({
            type: "get",
            url: url +"?id="+ id + "&fileid=" + fileid,
            success: function () {

                loadfiledata(_url, _id, _addurl, _removeurl);
            },
            error: function () { alert("error"); }

        });
    }
}

$(".addFiles").click(function () {


    if (confirm("elave olunsunmu")) {
        var fileInput = document.getElementById('formFile2');
        var id = _id;
        var files = fileInput.files;
        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append('files[' + i + ']', files[i]);

        }
        console.log(formData);

        $.ajax({
            type: "post",
            url: _addurl +"?id=" + id,
            data: formData,
            contentType: false,
            processData: false,
            success: function () {
                loadfiledata(_url, _id, _addurl, _removeurl);
            },
            error: function () { alert("error!!"); }
        });
    }


});