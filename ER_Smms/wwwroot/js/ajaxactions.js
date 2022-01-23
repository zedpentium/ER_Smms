function getAllPeople() {
    $.get("/Ajax/AllPeopleList", function (data) {
        $("#peopleviewlist").html(data);
    });
    document.getElementById("jsmessage").textContent = "List of All People fetched.";
}

function getPersonByID() {
    var idNr = document.getElementById('IdInput').value;
    $.post("/Ajax/FindPersonById", {Id: idNr}, function (data) {
        $("#peopleviewlist").html(data);
    })
        .done(function () {
            document.getElementById("jsmessage").textContent = "One Person fetched by ID.";
        })
        .fail(function () {
            document.getElementById("jsmessage").textContent = "FAILED to find Person. (Does not exist).";
        });

}

function deletePersonById() {
    var idNr = document.getElementById('IdInput').value;
    $.post("/Ajax/DeletePersonById", { Id: idNr }, function (data) {
        $("#peopleviewlist").html(data);
    })
        .done(function () {
            document.getElementById("jsmessage").textContent = "Person is now Deleted.";
        })
        .fail(function () {
            document.getElementById("jsmessage").textContent = "FAILED to Delete Person. (Does not exist).";
        })
}


function displayMessage(msg) {
    document.getElementById(jsmessage).textContent = msg;
}

/*
function displayError(error) {
    document.getElementById("error").innerHTML = JSON.stringify(error);
}
*/
