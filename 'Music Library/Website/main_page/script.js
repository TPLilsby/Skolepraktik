
//Artist GET function 
$(document).ready(function() {

    $.ajax({
        url: "https://localhost:7225/GetArtist"
    }).then(function(data) {

        for (i = 0; i < data.length; i++) {
            $('#artist').append('<div class="container artist-resize"> <div class="row pt-4 pb-4 pe-4"> <div class="col-8"><a href="' + data[i].link +'" target="_blank"><img class ="" src="' + data[i].imagePath + '" alt=""><h1 class="text-light">' + data[i].name + '</h1> </a> </div> </div> </div>')
            
        }
    });
});

//Request POST function
$(document).submit(function(event) {

    //Retrieve form data
    var FormData = {
        ArtistName: $("#artistName").val(),
        SongName: $("#songName").val(),
        Email: $("#email").val()
    };

    // //Send form data via AJAX POST request
    $.ajax({

        //POST
        type: "POST",

        //API Endpoint
        url: "https://localhost:7225/RequstSong",

        //Convert formData to JSON
        data: JSON.stringify(FormData),

        //Specific JSON
        contentType: "application/json; charset=utf-8",

    }).done(function(data) {
        //Sucess callback function
        console.log(data);

    }).fail(function(data) {
        //Error callback function
        console.log(data);
    })
});


//Weather Forecast GET function for testing
$(document).ready(function() {

    $.ajax({
        url: "https://localhost:7225/WeatherForecast"
    }).then(function(data) {

        for (i = 0; i < data.length; i++) {

            $('#test').append('<h1 class="text-light">' + data[i].date + '</h1>');
            $('#test').append('<h2 class="text-light">' + data[i].temperatureC + '</h2>');
            $('#test').append('<h3 class="text-light">' + data[i].temperatureF + '</h3>');
            $('#test').append('<h4 class="text-light">' + data[i].summary + '</h4>');
            
        }
    });
});
