

function SearchCities(searchText) {

    if (searchText == null || searchText.length < 3) {
        return;
    }

    $.ajax({
        type: "GET",
        url: "/Weather/CityList",
        data: "searchText=" + searchText,
        dataType: "text",
        success: function (response) {
            $('#CityList').html(response);
        },
        failure: function (response) {
            console.log(response.responseText);
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });




}


function SaveCityData(cityName) {

    var options = document.getElementById("CityList").options;

    var cityData = {
        "ID": "",
        "lon": 0,
        "lat": 0
    };

    for (var i = 0; i < options.length; i++) {
        if (options[i].innerHTML == cityName) {
            cityData.ID = options[i].getAttribute("data-value");
            cityData.lon = options[i].getAttribute("data-lon");
            cityData.lat = options[i].getAttribute("data-lat");
            break;
        }

    }

    var formElement = document.getElementById("City");
    formElement.value = cityData.ID;
    formElement.setAttribute("data-lon", cityData.lon);
    formElement.setAttribute("data-lat", cityData.lat);
}


function GetWeather() {

    var formData = {
        "city": document.getElementById("City").value,
        "lon": document.getElementById("City").getAttribute("data-lon"),
        "lat": document.getElementById("City").getAttribute("data-lat"),
        "unit": document.getElementById("Unit").value,
        "lang": document.getElementById("Language").value,
        "apikey": document.getElementById("APIkey").value
    };

    $.ajax({
        type: "POST",
        url: "/Weather/GetWeatherData",
        //data: JSON.stringify(formData),
        data: formData,
        dataType: "text",
        success: function (response) {
            $('#WeatherData').html(response);
        },
        failure: function (response) {
            console.log(response.responseText);
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });

}

