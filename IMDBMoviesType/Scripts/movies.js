// Made By abhisheikh parihar 
$(document).ready(function () {
    var descalp = false;
    var descrat = false;
    var descyear = false;


    $("#sort_alp").click(function () {     // fires when sort alphabatically link is pressed 
        sortUnorderedList("movie", descalp);
        descalp = !descalp;
    });
    $("#sort_rating").click(function () { // fires when sort TopRated link is pressed 
       sortUnorderedListrating("movie", descrat);
        descrat = !descrat;
    });
    $("#sort_year").click(function () { // fires when sort Latest link is pressed 
        sortUnorderedListyear("movie", descyear);
        descyear = !descyear;
    });
   
});


function details(id) {    // Method made for making Ajax call to  MovieDetailByName controller with param id  
    var element = this;
    $.ajax({
        url: "/Home/MovieDetailByName",
        type: "POST",
        data: JSON.stringify({ 'id': id }),
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            debugger;
            binddata(data);  // When ajax return data method call used for bindng movie details 
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
}

function binddata(data) { // method to bind data for movie details
    debugger
    var str ='<div id="coming"><div class="head"><h3></h3><p class="text-right"></p></div><div class="content">'
    str +='<h4>' + data.title + '</h4><a href="#"><img src="'+ data.poster + '" alt="coming soon" /></a><p>'+ data.plot +'</p><div class="cl">&nbsp;</div><div> <h3>Actors : '
    var actors = data.actors;
    try {
        
        var actor = actors.split(',');      
        for(var i=0; i< actor.length; i++) {
            str += '<a href="/home/MovieSearch/?Director=&Actor=' + actor[i] + '&Year=&Genre=">' + actor[i] + '</a>'
        }
    } catch (e) {
    }
		str +='<br /></h3></div><div class="cl">&nbsp;</div><div> <h3>Director :'
		str += '<a href="/home/MovieSearch/?Director=' + data.director + '&Actor=&Year=&Genre=">' + data.director + '</a><br /></h3></div>'
		str +='<div class="cl">&nbsp;</div><div> <h3>Genre : '
                     var Genres = data.genre;
                     var genre = Genres.split(',');
                     for(var i=0; i< genre.length; i++) {
                         str += '<a href="/home/MovieSearch/?Director=&Actor=&Year=&Genre=' + genre[i] + '">' + genre[i] + '</a>'
                     }
                      str +='<br /></h3></div><div class="cl">&nbsp;</div>'
               
                      str +='<div> <h3>Released Date :'+ data.released+' <br /></h3></div><div class="cl">&nbsp;</div> <div> <h3>Writer : '+ data.writer +'<br /></h3></div>'
                      str += '</div><div class="cl">&nbsp;</div></div>'
                      $("#details").html(str);
                      $("#movielist").hide();
}
// Sorting Methods using .Sort property of array
function sortUnorderedListyear(ul, sortDescending) {
    debugger;
    $('.' + ul).sort(function (a, b) {
        return sortDescending ? a.attributes["year"].nodeValue.localeCompare(b.attributes["year"].nodeValue) : b.attributes["year"].nodeValue.localeCompare(a.attributes["year"].nodeValue);
    }).appendTo('#movielist');
}
    function sortUnorderedList(ul, sortDescending) {
        $('.' + ul).sort(function (a, b) {
            return sortDescending ? a.title.localeCompare(b.title) : b.title.localeCompare(a.title);
        }).appendTo('#movielist');
    }

    function sortUnorderedListrating(ul, sortDescending) {
        debugger;
        $('.' + ul).sort(function (a, b) {
            return sortDescending ? a.attributes["rating"].nodeValue.localeCompare(b.attributes["rating"].nodeValue) : b.attributes["rating"].nodeValue.localeCompare(a.attributes["rating"].nodeValue);
        }).appendTo('#movielist');
    }
   