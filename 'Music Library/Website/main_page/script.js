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