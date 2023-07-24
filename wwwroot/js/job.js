$(document).ready(function () {
    hideAddFilter();
    getFilterJob("City");

    loadingJob(false);
    getRecruitments();
    function getRecruitments(filter = null, value1 = null, value2 = null, value3 = null) { 

        var xhr = new XMLHttpRequest();
        
        xhr.open("POST", "./Job/GetRecruitments", true);
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    let listJob = document.getElementById("list-job");
                    let featureJobPage = document.getElementById("feature-job-page");
                    let paginationJob = document.getElementById("pagination-job");
                    
                    if (response.length <= 0) {
                        let html = `<h4 class="text-center">Không tìm thấy công việc ở điều kiện này. Vui lòng thử lại</h4>`;
                        listJob.innerHTML = html;
                        featureJobPage.hidden = true;
                        loadingJob(true);
                        return;
                    }
                    featureJobPage.hidden = false;

                    let quantityJob = response.length;
                    let number = 3;
                    let paging = Math.ceil(quantityJob / number)
                    
                    listJob.innerHTML = "";

                    
                    for (let i = 0; i < paging; i++) {
                        let startIndex = i * number;
                        let endIndex = Math.min(startIndex + number, quantityJob);

                        let html = `<div class="item ${(i == 0) ? 'active' : ''}">`;

                        for (let j = startIndex; j < endIndex; j++) {
                            // Thêm các bản ghi vào HTML của mỗi trang ở đây
                            let item = response[j];
                            html += `
                                <div class="col-md-4 col-sm-6 feature-job job-ta">
                                    <div class="feature-job-item">
                                        <div class="cvo-flex">
                                            <a href="../Job/DefaultJob/${item.RecruitmentId}"
                                                target="_blank" tabindex="0">
                                                <div class="box-company-logo">
                                                    <div class="avatar">
                                                        <img src="../${item.Company.Avatar}"
                                                                alt="${item.Company.CompanyName}"
                                                                class="img-responsive">
                                                    </div>
                                                </div>
                                            </a>
                                            <div class="col-title cvo-flex-grow">
                                                <a href="../Job/DefaultJob/${item.RecruitmentId}"
                                                    target="_blank" data-toggle="tooltip" title=""
                                                    data-placement="top" data-container="body"
                                                    class="title text_ellipsis"
                                                    data-original-title="${item.RecruitmentTitle}"
                                                    tabindex="0">
                                                    <strong class="job_title">
                                                        ${item.RecruitmentTitle}
                                                    </strong>
                                                </a>
                                                <a href="../Company/Detail/${item.CompanyId}"
                                                    target="_blank" data-toggle="tooltip" title=""
                                                    data-placement="top" data-container="body"
                                                    class="text-silver company text_ellipsis company_name"
                                                    data-original-title="${item.Company.CompanyName}"
                                                    tabindex="0">
                                                    ${item.Company.CompanyName}
                                                </a>
                                            </div>
                                        </div>
                                        <div class="box-footer">
                                            <div class="col-job-info">
                                                <div class="salary">
                                                    <span class="text_ellipsis">${formatSalary(item.Salary)}</span>
                                                </div>
                                                <div data-html="true" data-toggle="tooltip" title=""
                                                        data-placement="top" data-container="body" class="address"
                                                        data-original-title="
                                                        <p style='text-align: left'>${item.City} - ${item.District}</p>">
                                                    <span class="text_ellipsis">${item.City} - ${item.District}</span>
                                                </div>
                                            </div>
                                            <div class="col-like">
                                                <button data-id="526118" class="btn-outline-hover save-job"
                                                        tabindex="0">
                                                    <i class="fa-regular fa-heart icon-first"></i>
                                                    <i class="fa-solid fa-heart icon-last"></i>
                                                </button>
                                            </div>
                                        </div>

                                    </div>

                                </div>`
                        }
                        html += `</div>`;
                        listJob.insertAdjacentHTML("beforeend", html);
                    
                    }
                    loadingJob(true);

                    //pagination
                    let html = `<span class="hight-light" id="current-job-page">1</span> / ${paging} trang`;
                    paginationJob.innerHTML = html;

                    //"beforebegin": Trước thẻ element.
                    //"afterbegin": Bên trong thẻ element, trước tất cả các thẻ con của nó.
                    //"beforeend": Bên trong thẻ element, sau tất cả các thẻ con của nó.
                    //"afterend": Sau thẻ element.
                    
                } else {
                    console.error("Request error:", xhr.status, xhr.statusText);
                    showMessage("Có lỗi sảy ra!", "error", "Thông báo", "glyphicon-remove", 3000);
                }
            }
        };
        var formData = new FormData();
        if (filter != null) {
            formData.append('filter', filter);
            formData.append('value1', value1);
            formData.append('value2', value2);
            formData.append('value3', value3);
        }
        xhr.send(formData);
    }
    $('#carousel-job').on('slide.bs.carousel', function onSlide(event) {
        let activeSlide = event.relatedTarget; // Lấy slide hiện tại
        let activeIndex = Array.from(activeSlide.parentElement.children).indexOf(activeSlide);
        updatePagination(activeIndex);
    })
    function updatePagination(activeIndex) {
        let currentJobPage = document.getElementById("current-job-page");
        currentJobPage.innerText = activeIndex + 1;
    }
    // Đăng ký sự kiện 'slid.bs.carousel' cho thẻ Carousel
    //let carouselJob = document.getElementById("carousel-job");
    //carouselJob.addEventListener("slide.bs.carousel", handleCarouselSlideJob);

    //// Hàm xử lý khi Carousel chuyển màn
    //function handleCarouselSlideJob(event) {
    //    let activeSlide = event.relatedTarget; // Lấy slide hiện tại
    //    let activeIndex = Array.from(activeSlide.parentElement.children).indexOf(activeSlide);

    //    // Cập nhật paginationJob dựa trên activeIndex (trang hiện tại)
    //   //updatePagination(activeIndex);
    //    console.log(activeIndex);
    //}
    let filterFeatureJob = document.getElementById("filter-feature-job");
    filterFeatureJob.addEventListener("change", function (e) {
        let filter = e.target.value;
        getFilterJob(filter);
    });

    let filterDistricts = document.getElementById("districts");
    let filterSalarys = document.getElementById("salaries");
    let filterExperiences = document.getElementById("experiences");
    let filterIndustryes = document.getElementById("industryes");
    const filterSalary = document.getElementById("salary-district")

    filterDistricts.addEventListener("change", function (e) {
        let result = filterSalary.value.split("-");
        let value2 = null;
        let value3 = null;
        if (result.length >= 1) {
            value2 = result[0].trim() || null;
        }
        if (result.length >= 2) {
            value3 = result[1].trim() || null;
        }
        if (value2 == null && value3 == null){
            getRecruitments("districts", e.target.value);
        } else {
            getRecruitments("districtsSalary", e.target.value, value2, value3);
        }
    });
    filterSalary.addEventListener("change", function(e) {
        let result= e.target.value.split("-");
        let value2 = null;
        let value3 = null;
        if (result.length >= 1) {
            value2 = result[0].trim() || null;
        }
        if (result.length >= 2) {
            value3 = result[1].trim() || null;
        }
        if (filterDistricts.value != '' ) {
            getRecruitments("districtsSalary", filterDistricts.value, value2, value3);
        } else {
            getRecruitments("salaries", value2, value3);
        }
        
    })
    filterSalarys.addEventListener("change", function (e) {
        let value = e.target.value;
        let result = value.split("-");
        getRecruitments("salaries", result[0], result[1]);
    });
    filterExperiences.addEventListener("change", function (e) {
        let value = e.target.value;
        let result = value.split("-");
        getRecruitments("experiences", result[0], result[1]);
    });
    filterIndustryes.addEventListener("change", function (e) {
        getRecruitments("industryes", e.target.value);
    });



    function getFilterJob(filter) {
        hideAddFilter();
        $(`#${filter}`).show();
    }
    function hideAddFilter() {
        $(`#City`).hide();
        $(`#Salary`).hide();
        $(`#Experience`).hide();
        $(`#Industry`).hide();
    }
    function loadingJob(status) {
        $(".loadingg").hide();
        $("#carousel-job").hide();
        if (status) {
            $("#carousel-job").show();
        } else {
            $(".loadingg").show();
        }
    }
    function formatSalary(salary) {
        if (isNaN(salary)) {
            return "0 triệu";
        }

        const million = 1000000;

        if (salary >= million) {
            const millionPart = Math.floor(salary / million);
            const thousandPart = Math.floor((salary % million) / 1000);
            const thousandString = thousandPart > 0 ? `,${thousandPart}` : "";
            return `${millionPart}${thousandString} triệu`;
        } else {
            const thousandPart = Math.floor(salary / 1000);
            const thousandString = thousandPart > 0 ? `,${thousandPart}` : "";
            return `${thousandString} nghìn`;
        }
    }

});