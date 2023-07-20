$(document).ready(function () {
    // Profile
    var birthday = new Date($("#text-birthday").text());
    var formattedBirthday = birthday.toLocaleDateString("en-GB");
    $("#text-birthday").text(formattedBirthday);
    $('#form-update-info-personal').on('submit', function (e) {
        e.preventDefault();
        if (checkValid()) {

            var data = {
                CandidateId: $("#form-update-info-personal #CandidateId").val(),
                AccountId: $("#form-update-info-personal #AccountId").val(),
                FullName: $("#form-update-info-personal #FullName").val(),
                Gender: $("#form-update-info-personal #Gender:checked").val(),
                Birthday: $("#form-update-info-personal #Birthday").val(),
                Phone: $("#form-update-info-personal #Phone").val(),
                Avatar: $("#form-update-info-personal #Avatar").val(),
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
    $("#avatar_file").on('change', function () {
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
                        $("#form-update-info-personal #Avatar").val(response);
                        showMessage("Cập nhật avatar thành công");
                    }
                }
            };
            xhr.send(formData);
        }
    });

    //Education
    GetEducation();
    function GetEducation() {
        Loading("education", false);

        let candidateId = $("#text-candidateId").val();
        console.log(candidateId);
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "./candidate/GetAllEducation?candidateId=" + candidateId, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                var response = JSON.parse(xhr.responseText);
                // Xử lý phản hồi từ server sau khi gửi dữ liệu thành công
                console.log(response);

                if (response != "") {
                    $("#education .style1").hide();
                    $("#education .style2").show();

                    let html = "";
                    response.forEach(function (item) {
                        console.log(item);
                        let date = (item.endMonth == 0 && item.endYear) ? "Hiện tại" : item.endMonth + "/" + item.endYear;
                        html += `
                        <li class="list-item">
                            <div class="item">
                                <img src="./images/profile-icon-svg/icon-education.svg" alt="${item.schoolName}" class="item-img"> 
                                <div class="item-content">
                                    <div class="item-title cur-poiter">${item.schoolName}</div> 
                                    <div class="item-sub-title">${item.major}</div> 
                                    <div class="item-date">
                                        <span>${item.startMonth}/${item.startYear} - ${date}</span>
                                    </div> 
                                    <div class="item-description">${item.description} </div>
                                </div>
                            </div> 
                            <div class="item-action">
                                <button name="updateEducation" data-education-id="${item.educationId}" data-school-name="${item.schoolName}" 
                                        data-major="${item.major}" data-start-month="${item.startMonth}" data-start-year="${item.startYear}"
                                        data-end-month="${item.endMonth}" data-end-year="${item.endYear}" data-description="${item.description}"
                                class="btn" style="min-width: 0">
                                    <i class="fa-solid fa-pencil" style="color: #00b14f;"></i>
                                </button>
                            </div>
                        </li>
                        `;
                    });
                    $("#education .list").html(html);
                    Loading("education", true);
                } else {
                    $("#education .style1").show();
                    $("#education .style2").hide();
                    Loading("education", true);
                }
            }
        };

        xhr.send();
    }
    $('#form-update-education').on('submit', function (e) {
        e.preventDefault();

        if (checkValidEducation()) {

            var data = {
                SchoolName: $("#form-update-education #SchoolName").val(),
                Major: $("#form-update-education #Major").val(),
                StartMonth: parseInt($("#form-update-education #StartMonth").val()),
                StartYear: parseInt($("#form-update-education #StartYear").val()),
                EndMonth: parseInt($("#form-update-education #EndMonth").val()),
                EndYear: parseInt($("#form-update-education #EndYear").val()),
                Description: $("#form-update-education #Description").val(),
                CandidateId: $("#form-update-education #CandidateId").val(),

            };
            console.log(data);

            var xhr = new XMLHttpRequest();
            xhr.open("POST", "./candidate/AddEdudation", true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    // Xử lý phản hồi từ server sau khi gửi dữ liệu thành công
                    console.log(response);
                    GetEducation();
                    showMessage("Thêm học vấn thành công");
                    $('#modal-update-education').modal('hide');
                    clearFormEducation();
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

    $('#education').on('click', 'button[name=updateEducation]', function () {
        $('#modal-update-education').modal('show');
        $("#form-update-education #SchoolName").val($(this).data("school-name"));
        $("#form-update-education #Major").val($(this).data("major"));
        $("#form-update-education #StartMonth").val($(this).data("start-month"));
        $("#form-update-education #StartYear").val($(this).data("start-year"));
        $("#form-update-education #EndMonth").val($(this).data("end-month"));
        $("#form-update-education #EndYear").val($(this).data("end-year"));
        $("#form-update-education #Description").val($(this).data("description"));

        $("#form-update-education .btn-red-outline").show();
    });

    const checkValidEducation = () => {
        var isValid = true;

        // Xóa thông báo lỗi cũ
        $("#modal-update-education .error-message").empty();

        // Kiểm tra từng trường và hiển thị thông báo lỗi nếu cần
        if ($("#modal-update-education #SchoolName").val() === "") {
            $("#schoolName-error").text("School Name is required");
            isValid = false;
        }
        if ($("#modal-update-education #Major").val() === "") {
            $("#major-error").text("Major is required");
            isValid = false;
        }
        if ($("modal-update-education #StartMonth").val() === "") {
            $("#startMonth-error").text("Start Month is required");
            isValid = false;
        }
        if ($("modal-update-education #StartYear").val() === "") {
            $("#startYear-error").text("Start Year is required");
            isValid = false;
        }

        return isValid;
    }
    function clearFormEducation() {
        $("#form-update-education #SchoolName").val("");
        $("#form-update-education #Major").val("");
        $("#form-update-education #StartMonth").val("");
        $("#form-update-education #StartYear").val("");
        $("#form-update-education #EndMonth").val("");
        $("#form-update-education #EndYear").val("");
        $("#form-update-education #Description").val("");
    }

    function Loading(personal, status) {
        if (!status) {
            $(`#${personal}_default`).show();
            $(`#${personal}`).hide();
        } else {
            $(`#${personal}_default`).hide();
            $(`#${personal}`).show();
        }
        
    }
});