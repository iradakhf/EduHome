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

    $("#ButtonBlog").click((e) => {
        e.preventDefault();
        let searchInp = $("#InputBlog").val();
        fetch("/blog/search/" + "?text=" + searchInp)
            .then(response => {
                return response.text()
            })
            .then(data => {
                $("#ListBlog").html(data);
            })
    })

    $("#InputBlog").keyup(function () {

        let inputVal = $(this).val();
        if (inputVal.length <= 0) {
            $("#ListBlog").html("")
        }
    })
    $("#ButtonEvent").click((e) => {
        e.preventDefault();
        let searchInp = $("#InputEvent").val();
        fetch("/event/search/" + "?text=" + searchInp)
            .then(response => {
                return response.text()
            })
            .then(data => {
                $("#ListEvent").html(data);
            })
    })

    $("#InputEvent").keyup(function () {

        let inputVal = $(this).val();
        if (inputVal.length <= 0) {
            $("#ListEvent").html("")
        }
    })
    $("#ButtonCourse").click((e) => {
        e.preventDefault();
        let searchInp = $("#InputCourse").val();
        fetch("/event/search/" + "?text=" + searchInp)
            .then(response => {
                return response.text()
            })
            .then(data => {
                $("#ListCourse").html(data);
            })
    })

    $("#InputCourse").keyup(function () {

        let inputVal = $(this).val();
        if (inputVal.length <= 0) {
            $("#ListCourse").html("")
        }
    })


   
    })