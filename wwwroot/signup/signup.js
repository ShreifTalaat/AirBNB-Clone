//Initialize the "intl-tel-input" library on the input field using JavaScript:
var input = document.querySelector("#phone");
window.intlTelInput(input, {
  initialCountry: "eg", 
  separateDialCode: true, //showing country code next to country flag
  utilsScript: "path/to/utils.js",
  dropdownContainer: false
});

//Comparing passwords
function checkPasswordMatch() {
    var password = document.querySelector("#password");
    var confirmPassword = document.querySelector("#confirm-password");
    if (password.value != confirmPassword.value) {
      confirmPassword.setCustomValidity("Passwords don't match");
    } else {
      confirmPassword.setCustomValidity("");
    }
  }

  var profileImageInput = document.getElementById("profile-image");
  var profileImagePreview = document.getElementById("preview-image");
profileImagePreview.style.display = "none";
File.prototype.convertToBase64 = function (callback) {

    var FR = new FileReader();
    FR.onload = function (e) {
        callback(e.target.result)
    };
    FR.readAsDataURL(this);
}
  profileImageInput.addEventListener("change", function() {
      var file = this.files[0];
      if (file) {
          var reader = new FileReader();
          reader.addEventListener("load", function() {
              profileImagePreview.src =reader.result;
          });
          reader.readAsDataURL(file);
          profileImagePreview.style.display="block";
      }

  });