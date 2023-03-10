//#region dates Modal
const exampleModal = document.getElementById("exampleModal");
//exampleModal.addEventListener("show.bs.modal", (event) => {
//  // Button that triggered the modal
//  const date = document.querySelector("#dateRange");
//  // Extract info from data-bs-* attributes
//  const recipient = date.getAttribute("data-bs-whatever");
//  // If necessary, you could initiate an AJAX request here
//  // and then do the updating in a callback.
//  // Update the modal's content.
//  const modalTitle = exampleModal.querySelector(".modal-title");
//  const modalBodyInput = exampleModal.querySelector(".modal-body input");
//  // modalTitle.textContent = `Date ${recipient}`;
//  // modalBodyInput.value = recipient;
//});

// format currency
const formatter = new Intl.NumberFormat("en-US", {
  style: "currency",
  currency: "EGP",
  minimumFractionDigits: 2,
});
//catch elements
const save = document.querySelector("#saveRange");
const checkIn = document.querySelector("#result_from");
const checkOut = document.querySelector("#result_to");
const days = document.querySelector("#noDays");
//add event listiners
save.addEventListener("click", (event) => {
  if(checkIn.value != "" && checkOut.value != "")
  {
    updateRange();
    calcuateDays();
    calculatePrice();
    checkIn.classList.remove("is-invalid");
    checkOut.classList.remove("is-invalid");
    save.setAttribute( "data-bs-dismiss","modal");
  }
  else
  {
    checkIn.classList.add("is-invalid");
    checkOut.classList.add("is-invalid");
  }
  save.click();
});
//functions for the event listiner
function updateRange() {
  const cancelationDate = document.querySelector("#cancelationDate");
  const date = document.querySelector("#dateRange");
  const checkInMon = checkIn.value.substr(0, 3);
  const checkInDay = checkIn.value.substr(5, 2);
  const checkOutMon = checkOut.value.substr(0, 3);
  const checkOutDay = checkOut.value.substr(5, 2);
  date.innerHTML = checkInMon.concat(
    " ",
    checkInDay,
    " - ",
    checkOutMon,
    " ",
    checkOutDay
  );
  cancelationDate.innerHTML = checkInMon.concat(" ", checkInDay);
}
function calcuateDays() {
  // no of days betwwen check in and checkout
  // finding difference between 2 dates.
  let start_Date = new Date(checkIn.value);
  let end_Date = new Date(checkOut.value);
  let difference = end_Date.getDate() - start_Date.getDate();
  days.innerHTML = difference.toString();
}
function calculatePrice() {
  let price = document.querySelector("#price").innerHTML;
  let priceTotal = document.querySelector("#priceTotal");
  let finalPrice = document.querySelector("#finalTotalPrice");
  priceTotal.innerHTML = formatter.format(
    (parseInt(price) * parseInt(days.innerHTML)).toString()
  );
  finalPrice.innerHTML = priceTotal.innerHTML;
}
//#endregion
//#region guests modal
let count = 0;
function Counertfunc() {
  count++;
  if (count < 17) {
    let span = document.querySelector(".counter");
    span.innerHTML = count;
  } else {
    let btn1 = document.querySelector("#btn1");
    btn1.disable = true;
  }
};
function CounertfuncDown() {
  if (count > 0) {
    count--;
    let span = document.querySelector(".counter");
    span.innerHTML = count;
  } else {
    let btn2 = document.querySelector("#btn2");
    btn2.disable = true;
  }
};
//get refrences
let saveGuests = document.querySelector('#saveGuests');
//update number of guests
saveGuests.addEventListener('click',event=>{
let modalGuests = document.querySelector('#modalGuests');
let guests = document.querySelector('#noOfGuests');
  guests.innerHTML= modalGuests.innerHTML;
});
//#endregion
//#region validation
// Get a reference to the form element
const form = document.querySelector("#payment-form");
const nameField = form.querySelector('input[name="name"]');
const cardField = form.querySelector('input[name="card"]');
const expiryField = form.querySelector('input[name="expiry"]');
const cvvField = form.querySelector('input[name="billingAddress"]');
const streetField = form.querySelector('input[name="streetAddress"]');
const cityField = form.querySelector('input[name="city"]');
const stateField = form.querySelector('input[name="state"]');
const zipField = form.querySelector('input[name="zipCode"]');

// Add an event listener for the form's submit event
form.addEventListener("submit", function (event) {
  // Prevent the default form submission behavior
  event.preventDefault();
  // Define a regular expression to match a valid credit card number
  const creditCardRegex = /^[0-9]{16}$/;
  // Define a variable to keep track of whether the form is valid
  let isFormValid = true;
  // Check each required field to see if it is empty
  if (nameField.value === "") {
    isFormValid = false;
    nameField.classList.add("is-invalid");
  } else {
    nameField.classList.remove("is-invalid");
  }

  if (cardField.value === "") {
    isFormValid = false;
    cardField.classList.add("is-invalid");
  } else if (!creditCardRegex.test(cardField.value)) {
    isFormValid = false;
    cardField.classList.add("is-invalid");
    cardField.setCustomValidity("Please enter a valid credit card number");
  } else {
    cardField.classList.remove("is-invalid");
    cardField.setCustomValidity("");
  }

  if (expiryField.value === "") {
    isFormValid = false;
    expiryField.classList.add("is-invalid");
  } else {
    expiryField.classList.remove("is-invalid");
  }

  if (cvvField.value === "") {
    isFormValid = false;
    cvvField.classList.add("is-invalid");
  } else {
    cvvField.classList.remove("is-invalid");
  }

  if (streetField.value === "") {
    isFormValid = false;
    streetField.classList.add("is-invalid");
  } else {
    streetField.classList.remove("is-invalid");
  }

  if (cityField.value === "") {
    isFormValid = false;
    cityField.classList.add("is-invalid");
  } else {
    cityField.classList.remove("is-invalid");
  }

  if (stateField.value === "") {
    isFormValid = false;
    stateField.classList.add("is-invalid");
  } else {
    stateField.classList.remove("is-invalid");
  }

  if (zipField.value === "") {
    isFormValid = false;
    zipField.classList.add("is-invalid");
  } else {
    zipField.classList.remove("is-invalid");
  }

  // If the form is valid, submit it
  if (isFormValid) {
    form.submit();
  }
});
//#endregion
//#region  add payment event listeners
nameField.addEventListener("blur", validateName);
cardField.addEventListener("blur", validateCardNumber);
expiryField.addEventListener("blur", validateExpiry);
cvvField.addEventListener("blur", validateCVV);
streetField.addEventListener("blur", validateStreetAddress);
cityField.addEventListener("blur", validateCity);
stateField.addEventListener("blur", validateState);
zipField.addEventListener("blur", validateZipCode);
//#endregion
//#region  Payment Validation Functions
function validateName() {
  const name = nameField.value.trim();

  if (name === "") {
    nameField.classList.add("is-invalid");
  } else {
    nameField.classList.remove("is-invalid");
  }
};
function validateCardNumber() {
  const cardNumber = cardField.value.trim();
  const creditCardRegex = /^[0-9]{16}$/;
  if (cardNumber === "" || !creditCardRegex.test(cardNumber)) {
    cardField.classList.add("is-invalid");
  } else {
    cardField.classList.remove("is-invalid");
  }
};
function validateExpiry() {
  const expiry = expiryField.value.trim();
  const expiryRegex = /^(0[1-9]|1[0-2])\/([0-9]{2})$/;
  if (expiry === "" || !expiryRegex.test(expiry)) {
    expiryField.classList.add("is-invalid");
  } else {
    expiryField.classList.remove("is-invalid");
  }
};
function validateCVV() {
  const cvv = cvvField.value.trim();
  const cvvRegex = /^[0-9]{3,4}$/;
  if (cvv === "" || !cvvRegex.test(cvv)) {
    cvvField.classList.add("is-invalid");
  } else {
    cvvField.classList.remove("is-invalid");
  }
};
function validateStreetAddress() {
  const streetAddress = streetField.value.trim();

  if (streetAddress === "") {
    streetField.classList.add("is-invalid");
  } else {
    streetField.classList.remove("is-invalid");
  }
};
function validateCity() {
  const city = cityField.value.trim();

  if (city === "") {
    cityField.classList.add("is-invalid");
  } else {
    cityField.classList.remove("is-invalid");
  }
};
function validateState() {
  const state = stateField.value.trim();

  if (state === "") {
    stateField.classList.add("is-invalid");
  } else {
    stateField.classList.remove("is-invalid");
  }
};
function validateZipCode() {
  const zipCode = zipField.value.trim();

  if (zipCode === "") {
    zipField.classList.add("is-invalid");
  } else {
    zipField.classList.remove("is-invalid");
  }
};
//#endregion
