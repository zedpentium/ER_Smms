function showSelectedBoat(boatid) {
    $.post("/Admin/CustomerBoatInfoPartial", { id: boatid.value }, function (data) {
        $("#boatinfomanage").html(data);
    })
        .done(function () {
            //document.getElementById("jsmessage").textContent = "One Person fetched by ID.";
        })
        .fail(function () {
            //document.getElementById("jsmessage").textContent = "FAILED to find Person. (Does not exist).";
        });


    $.post("/Admin/CustomerBoatWinterspotPartial", { id: boatid.value }, function (data) {
        $("#winterspotboatinfomanage").html(data);
    })
        .done(function () {
            //document.getElementById("jsmessage").textContent = "One Person fetched by ID.";
        })
        .fail(function () {
            //document.getElementById("jsmessage").textContent = "FAILED to find Person. (Does not exist).";
        });
}


function editCustomer_PartialView(userName) {
    $.post("/Identity/EditCustomer_Partial", { id: userName }, function (data) {
        $("#downbelow_partialviews").html(data);
    })
        .done(function () {
            //document.getElementById("jsmessage").textContent = "One Person fetched by ID.";
            //document.getElementById("editcustomer_partial").innerHTML = "Kundändringar Klart!";
        })
        .fail(function () {
            //document.getElementById("jsmessage").textContent = "FAILED to find Person. (Does not exist).";
            
        });
}


function createWinterstoreSpot_PartialView(userName) {
    $.post("/Admin/CreateWinterstoreSpot_Partial", { id: userName }, function (data) {
        $("#downbelow_partialviews").html(data);
    })
        .done(function () {
            //document.getElementById("jsmessage").textContent = "One Person fetched by ID.";
            //document.getElementById("editcustomer_partial").innerHTML = "Kundändringar Klart!";
        })
        .fail(function () {
            //document.getElementById("jsmessage").textContent = "FAILED to find Person. (Does not exist).";

        });
}
