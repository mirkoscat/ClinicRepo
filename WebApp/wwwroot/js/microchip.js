{
    var hasMicrochipCheckbox = document.getElementById("HasMicrochip");
    var showDiv = document.getElementById("showthings");

    hasMicrochipCheckbox.addEventListener("click", function () {
        if (hasMicrochipCheckbox.checked) {
            showDiv.style.display = "block";
        } else {
            showDiv.style.display = "none";
        }
    });
}