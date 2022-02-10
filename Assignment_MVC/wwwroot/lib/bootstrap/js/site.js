
document.getElementById("jsonBtn").onclick = (
    function () {
        var dataRequest = { personId: 1, Name: "Gösta", PhoneNumber: 1446, City: "Stockholm" };

        $.ajax({
            data: { model: JSON.stringify(dataRequest) },
            type: 'POST',
            url: '/Test/Index',
            success: function (output) {
                console.log("Hello from json call!");
            }
        })
    }
)


