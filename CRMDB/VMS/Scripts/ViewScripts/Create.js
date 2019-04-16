function submitWith() {
    var chDays = document.getElementsByName("SelectedDays");
    var chDays1 = Array.prototype.slice.call(chDays).some(x => x.checked);
    if (!chDays1) {
        document.getElementById("Avail-error").innerHTML = "Please select a day.";
    } else {
        document.getElementById("Avail-error").innerHTML = "";
    }
    var chCats = document.getElementsByName("SelectedCategories");
    var chCats1 = Array.prototype.slice.call(chCats).some(x => x.checked);
    if (!chCats1) {
        document.getElementById("Cats-error").innerHTML = "Please select a category.";
    } else {
        document.getElementById("Cats-error").innerHTML = "";
    }
    return chDays1 && chCats1;
}