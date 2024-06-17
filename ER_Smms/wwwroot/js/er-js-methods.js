function setElementInnerHtml(elemId, theHtml) {
    return document.getElementById(elemId).innerHTML = theHtml
}

 function isObjNull(objValue) {
    if (objValue != null) {
        var showText = objValue.toString();

        return showText.replace(".", ",");
    }
    else { return "info saknas"; }
}


/* ------- START - Magnifying script ------- */
function magnify(imgID, zoom) {
    var img, glass, w, h, bw;
    img = document.getElementById(imgID);

    /* Create magnifier glass: */
    glass = document.createElement("DIV");
    glass.setAttribute("class", "img-magnifier-glass");

    /* Insert magnifier glass: */
    img.parentElement.insertBefore(glass, img);

    /* Set background properties for the magnifier glass: */
    glass.style.backgroundImage = "url('" + img.src + "')";
    glass.style.backgroundRepeat = "no-repeat";
    glass.style.backgroundSize = (img.width * zoom) + "px " + (img.height * zoom) + "px";
    bw = 3;
    w = glass.offsetWidth - 200;
    h = glass.offsetHeight;

    /* Execute a function when someone moves the magnifier glass over the image: */
    glass.addEventListener("mousemove", moveMagnifier);
    img.addEventListener("mousemove", moveMagnifier);

    /*and also for touch screens:*/
    glass.addEventListener("touchmove", moveMagnifier);
    img.addEventListener("touchmove", moveMagnifier);
    function moveMagnifier(e) {
        var pos, x, y;
        /* Prevent any other actions that may occur when moving over the image */
        e.preventDefault();
        /* Get the cursor's x and y positions: */
        pos = getCursorPos(e);
        x = pos.x;
        y = pos.y;
        /* Prevent the magnifier glass from being positioned outside the image: */
        if (x > img.width - (w / zoom)) { x = img.width - (w / zoom); }
        if (x < w / zoom) { x = w / zoom; }
        if (y > img.height - (h / zoom)) { y = img.height - (h / zoom); }
        if (y < h / zoom) { y = h / zoom; }
        /* Set the position of the magnifier glass: */
        glass.style.left = (x - w) + "px";
        glass.style.top = (y - h) + "px";
        /* Display what the magnifier glass "sees": */
        glass.style.backgroundPosition = "-" + ((x * zoom) - w + bw) + "px -" + ((y * zoom) - h + bw) + "px";
    }

    function getCursorPos(e) {
        var a, x = 0, y = 0;
        e = e || window.event;
        /* Get the x and y positions of the image: */
        a = img.getBoundingClientRect();
        /* Calculate the cursor's x and y coordinates, relative to the image: */
        x = e.pageX - a.left;
        y = e.pageY - a.top;
        /* Consider any page scrolling: */
        x = x - window.pageXOffset;
        y = y - window.pageYOffset;
        return { x: x, y: y };
    }
}

function zoomOut() {
    var zooms = document.querySelectorAll(".img-magnifier-glass");
    for (var x = 0; x < zooms.length; x++) {
        zooms[x].parentNode.removeChild(zooms[x]);
    }
}



/* -------------- END - Magnifying -------- */


function setModalDraggableAndResizable() {
    $('.modal-content').resizable({
        //alsoResize: ".modal-dialog",
        minHeight: 300,
        minWidth: 300
    });
    $('.modal-dialog').draggable();
}


/* ToastNotify */
function setAndShowToast(vartype, vartitle, varmessage, vartimer) {
    cuteToast({
        type: vartype,
        title: vartitle,
        message: varmessage,
        timer: vartimer,
    });
}



/* ------  START -- CKEditor JSinterop  */
window.CKEditorInterop = (() => {
    const editors = {};

    return {
        init(id, dotNetReference) {
            ClassicEditor
                .create(document.getElementById(id))
                .then(editor => {
                    editors[id] = editor;
                    editor.model.document.on('change:data', () => {
                        let data = editor.getData();

                        const el = document.createElement('div');
                        el.innerHTML = data;
                        if (el.innerText.trim() == '')
                            data = null;

                        dotNetReference.invokeMethodAsync('EditorDataChanged', data);
                    });
                })
                .catch(error => console.error(error));
        },
        destroy(id) {
            editors[id].destroy()
                .then(() => delete editors[id])
                .catch(error => console.log(error));
        }
    };
})();

/* ------  END -- CKEditor JSinterop  */





//function hasBoatASpot(obj) {
//    let showInfo
//    if (obj != null) {
//        //console.log(obj)
//        if (obj.pier != null) {


//            var removeBoatslipButtonFromSelectedBoat = "
//                < input type = "button" class="btn btn-secondary btnWidthSeparate"
//            name = "btnBack" value = "Tillbaka"
//            onClick = "location.href='@Url.Action("RemoveBoatslipFromSelectedBoat", "Admin",
//            new { boatDataId = obj.id, boatslipId = item.paramValue2 }) '" />"

//            showInfo = obj.label + " - " + obj.pier.label
//        }
//        else if (obj.serviceType != null) { showInfo = obj.label + " - " + obj.serviceType.label }
//        else { showInfo = obj.label }



//        return showInfo
//    }
//    else {
//        showInfo = "Ingen"
//        return showInfo
//    }
//}

//function showApplySaveBoatslipButton() {
//    document.getElementById("saveselectedboatsliptoboat").hidden = false;

//    //var selectedBoatForForm = document.getElementById("SelectedBoatslipId");
//    document.getElementById("SelectedBoatFormId").value = document.getElementById("SelectedBoatslipId");

//    //var buttonElement = document.getElementById("saveselectedboatsliptoboat");

//    //buttonElement.style.display = "";
//}

//function getSelectedBoatId() {

//}

//function getSelected() {

//}
