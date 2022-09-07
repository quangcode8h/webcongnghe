var btnCart = document.getElementById("btnCart");
var colorValue = document.querySelectorAll(".color");
btnCart.onclick = function () {
    colorValue.forEach(myFunction);
    function myFunction(item) {
        if (item.checked == true) {
            document.getElementById("myForm").submit();
        }
    }
}