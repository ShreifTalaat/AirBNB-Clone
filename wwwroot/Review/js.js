var text_max = 100;
var counter = document.getElementById('count_message');
var textarea = document.getElementById('text');
counter.innerHTML = '0/' + text_max;
textarea.addEventListener('keyup', function () {
    var text_length = textarea.value.length;
    var text_remaining = text_max - text_length;
    counter.innerHTML = text_length + '/' + text_max;
    if (textarea.value.trim() != '') {
        document.getElementById("titlecheck").removeAttribute("disabled");
    } else
        document.getElementById("titlecheck").setAttribute("disabled", true);
})


function setStarValue() {
    // Get the value of the selected star
    const stars = document.querySelector('input[name="star"]:checked').value;
    // Set the value of the hidden input field to the selected star value
    document.getElementById("stars").value = stars;
}