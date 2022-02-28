// Fetch cities depending on selected country
$("#CountryId").change(function () {
   
    var CountryId = $("#CountryId").val();

    $.ajax({
        //base address/controller/Action
        url: '/People/GetCityList',
        dataType: "json",
        type: 'GET',
        data: {
            //Passing Input parameter
            CountryId: CountryId
        },
        success: function (result) {
            console.log("reached!" + CountryId);
            console.log(result);

            $("#CityId").empty();

            $.each(result, function (i, val) {
                var obj = result[Object.keys(result)[i]];
                $("#CityId").append("<option value='" + obj[Object.keys(obj)[0]] + "'>" + obj[Object.keys(obj)[1]] + "</option>")
            });

        },
        error: function () {
            console.log("error");
        }
    });

});


//Fetch list
function fetchData() {
    $.get("Test/Fetch", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);

        $("#personList").html(data);
    });
}

//Create new person
function createNew(e) {

    var Name = $("#crName").val();
    var PhoneNumber = $("#crPhone").val();
    var City = $("#crCity").val();

    console.log(Name, PhoneNumber, City);

    $.ajax({
        type: 'POST',
        url: 'Test/Create',
        data: { 'Name': Name, 'PhoneNumber': PhoneNumber, 'City': City },
        success:
            function (response) {
                console.log('Data received...' + "\n" + response);
                $("#personList").append(response);
                $("#testDiv").attr('class', 'alert alert-success');
                $("#testDiv").html("<strong>Success!</strong> Added person to list");
            },
        error:
            function (response) {
                console.log('Error: ' + response);
                $("#testDiv").attr('class', 'alert alert-danger');
                $("#testDiv").html("<strong>Error!</strong> Could not add person to list.");

            }
    });


}

//Delete by ID
function del() {
    var id = $("#newSearch").val();
    console.log("Data received: " + id);
    var card = document.getElementById("card-" + id);

    $.ajax({
        type: "POST",
        url: "Test/Delete",
        data: { 'id': id },
        success: function (response) {
            card.remove();
            $("#testDiv").attr('class', 'alert alert-success');
            $("#testDiv").html("<strong>Success!</strong> Deleted person with ID" + id);
        },
        statusCode: {
            404: function () {
                console.log("Could not find person with ID " + id);
            },
            200: function () {
                console.log("Successfully deleted person with ID " + id);
            }
        },
        error: function (response) {
            console.log('Error: ' + response);
            $("#testDiv").attr('class', 'alert alert-danger');
            $("#testDiv").html("<strong>Error!</strong> Could not delete person with ID " + id);
        }
    });


}

//Find person by ID
function search() {

    var id = $("#newSearch").val();
    console.log("received ID: " + id);

    $.ajax({
        type: "POST",
        url: "Test/Details",
        data: { 'id': id },
        success: function (response) {
            console.log("Found card with id " + id);
            console.log(response);
            $("#personList").html(response);
        },
        error: function (response) {
            console.log('Error: ' + response);
            $("#personList").html("No match found");
        }
    });

}


