
$(document).ready(function () {
    SearchText();
    $("#searchBySubject").keyup(function () {
        var searchEntry = $('#searchBySubject').val();
        if (searchEntry.length>=2) {
            SearchText();
        }
       
    });
    $("#searchBySubject").focus(function() {
        var searchEntry = $('#searchBySubject').val();
        if (searchEntry.length >= 2) {
            SearchText();
        }
    });
});
function SearchText() {
    var url = '@Url.Action("SearchArticle", "Article")';
    $("#searchBySubject").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                //url: 'http://localhost:1096/api/UserArticles/mohiuddin/Search/'+$('#searchBySubject').val(),
                url: '/Article/SearchArticle',
                data: "{'searchTerm':'" + $('#searchBySubject').val() + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.length>0) {
                        response(data);
                       
                    } else {
                        alert("No Such Article");
                    }
                },
                error: function (result) {
                    console.log(result);
                }
            });
        }
    });  
}