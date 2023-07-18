$(document).ready(function () {
    //$('#Birthday').datetimepicker({
    //    //inline: false
    //});
    $('#form-update-info-personal').on('submit', function (e) {
        e.preventDefault();
        if (checkValid()) {
            
            var data = {
                CandidateId: $("#form-update-info-personal #CandidateId").val(),
                AccountId: $("#form-update-info-personal #AccountId").val(),
                FullName: $("#form-update-info-personal #FullName").val(),
                Gender: $("#form-update-info-personal #Gender:checked").val(),
                Birthday: $("#form-update-info-personal #Birthday").val(),
                Phone: $("#form-update-info-personal #Phone").val()
            };

            var xhr = new XMLHttpRequest();
            xhr.open("POST", "./candidate/UpdateInfoPersonal", true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    // Xử lý phản hồi từ server sau khi gửi dữ liệu thành công
                    console.log(response);
                    $("#profile-name #text-fullname").text(response.fullName);

                    var dateParts = response.birthday.split("T")[0].split("-");
                    var birthday = dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0];
                    $("#profile-name #text-birthday").text(birthday);
                    $("#profile-name #text-gender").text(response.gender);
                    $("#profile-name #text-phone").text(response.phone);
                    $('#modal-update-info-personal').modal('hide');
                    showMessage("Cập nhật thông tin cá nhân thành công");
                } else {
                    showMessage("Có lỗi sảy ra!", "error", "Thông báo", "glyphicon-remove", 3000);
                }
            };

            xhr.send(JSON.stringify(data));


        } else {
            console.log("nolooooo");
        }
        return false;
    });
    const checkValid = () => {
        let FullName = $('[data-valmsg-for="FullName"]').text();
        let Birthday = $('[data-valmsg-for="Birthday"]').text();
        let Phone = $('[data-valmsg-for="Phone"]').text();

        if (FullName == "" && Birthday == "" && Phone == "") {
            return true;
        } else {
            return false;
        }
    }  
    $("#change-avatar").on('click', () => {
        $("#avatar_file").trigger("click");
    });
    $("#avatar_file").on('change', function (){
        var fileInput = this;
        if (fileInput.files.length > 0) {
            var file = fileInput.files[0];

            var formData = new FormData();
            formData.append('avatar_file', file);

            var xhr = new XMLHttpRequest();
            xhr.open('POST', './candidate/UploadAvatar', true);
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var response = xhr.responseText;
                    if (response == "error") {
                        showMessage("Có lỗi sảy ra!", "error", "Thông báo", "glyphicon-remove", 3000);
                    } else if (response == "empty") {
                        showMessage("Không có file avatar!", "error", "Thông báo", "glyphicon-remove", 3000);
                    } else {
                        $(".avatar").css("background-image", `url("./images/avatar/${response}?v=${Math.floor(Math.random() * (99999 - 1 + 1)) + 1}")`);
                        showMessage("Đã cập nhật avatar thành công");
                    }
                }
            };
            xhr.send(formData);
        }
    });
    
});