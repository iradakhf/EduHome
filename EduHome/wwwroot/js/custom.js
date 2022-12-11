$(document).ready(() => {
    $(".InputForSearch").change((e) => {
        e.preventDefault();
        let searchInp = $(".InputForSearch").val();
        fetch("/course/search/" + "?text=" + searchInp)
            .then(response => {
                return response.text()
            })
            .then(data => {
                $("#searchResult").html(data);
            })
    })

    $("#searchBtn").click((e) => {
        e.preventDefault();
        let searchInp = $(".InputForSearch").val();
        fetch("/course/search/" + "?text=" + searchInp)
            .then(response => {
              return  response.text()
            })
            .then(data => {
                $("#searchResult").html(data);
            })
    })
    $(".InputForSearch").keyup(function () {

        let inputVal = $(this).val();
        if (inputVal.length <= 0) {
            $("#searchResult").html("")
        }
    })


    $("#BtnCourse").click((e) => {
        e.preventDefault();
        let searchInp = $("#InputCourse").val();
        fetch("/course/search/" + "?text=" + searchInp)
            .then(response => {
                return response.text()
            })
            .then(data => {
                $("#searchResultCourse").html(data);
            })
    })

    $("#InputCourse").keyup(function () {

        let inputVal = $(this).val();
        if (inputVal.length <= 0) {
            $("#searchResultCourse").html("")
        }
    })

  
    $(".buttonCourse").click((e) => {
        e.preventDefault();
        let searchInp = $(".inputCourse").val();
        fetch("/course/search/" + "?text=" + searchInp)
            .then(response => {
                return response.text()
            })
            .then(data => {
                $("#searchCourse").html(data);
            })
    })
    $(".inputCourse").keyup(function () {

        let inputVal = $(this).val();
        if (inputVal.length <= 0) {
            $("#searchCourse").html("")
        }
    })

    })