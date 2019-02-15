$(document).ready(function () {
    function ajaxLikeDislike(event) {
        $.ajax({
            type: "GET",
            url: event.data.URL,
            data: { postId: $(this).attr("postId") },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });
    }

    function errorFunc() {
        alert('error');
    }
    function successFunc(data, status) {
        var id = "#pid-" + data.id
        var likeDiv = $(id);
        var likeCount = parseInt(likeDiv.text());
        likeDiv.text(likeCount + data.likeOperation);
    }

    $(".like").click({ URL: "/RecentPosts/Like" }, ajaxLikeDislike);
    $(".dislike").click({ URL: "/RecentPosts/Dislike" }, ajaxLikeDislike);
});