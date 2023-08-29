$(document).ready(function() {
   
    //Send an AJAX request to retrieve CV data from the specified URL: API Endpoint
    $.ajax({
        url: "https://localhost:7146/WeatherForecast"
    }).then(function(data) {
   
        //Loops through the received data and populate the corresponding elements in the HTML
        for (i = 0; i < data.length; i++) {

            //Append the CV title to elements with the ID "cv"
            $('#cv').append('<div class="center"><h1 class="pt-4">' + data[i].date + '</h1></div>');
            
            //Append cv description element with the ID "cv" to the Cv image path
            $('#cv').append('<h4 class="center">' + data[i].temperatureC + '</h4>');
            
            //Append cv image element with the ID "cv" to the Cv image path
            $('#cv').append('<img class="resize" src="' + data[i].temperatureF + '">');
            
            //Append PDF link with button element with the ID "cv" to the CV PDF link
            $('#cv').append('<br><a target="_blank" href="' + data[i].summary + '"><button class="button m-lg-4">Download CV</button></a>');
        }
    });
});