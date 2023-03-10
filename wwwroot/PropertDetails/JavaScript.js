// Select increment and decrementbuttons on Search Bar
const incrementCountSearch = document.getElementById("increment-count-search");
const decrementCountSearch = document.getElementById("decrement-count-search");
const whoText = document.getElementById("whoText");
////Who DropDown
let guestsDropDown = document.getElementById("guestsDropDown");
let whoDiv = document.getElementById("whoDiv");


// Select increment and decrementbuttons
const incrementCount = document.getElementById("increment-count");
const decrementCount = document.getElementById("decrement-count");

// Select Number of guests
const numberOfGuests = parseInt(document.getElementById("NOGuests").innerText);
// Select guest Word
const guestWord = document.getElementById("guest-word");
const guestWordSearch = document.getElementById("guest-word-search");


// Select total count
const totalCount = document.getElementById("total-count");
const totalCountSearch = document.getElementById("total-count-search");
// Variable to track count
var count = 1;
var countSearch = 0;
// Display initial count value
totalCount.innerHTML = count;
totalCountSearch.innerHTML = countSearch;
//pass guest to payment
function GeustNum() {
    let guest = document.getElementById("guests");
    guest.value = totalCount.innerText;

}
// Function to increment count
function handleIncrement() {
    if (count < numberOfGuests) {
        count++;
        totalCount.innerText = count;
        guestWord.innerText = "guests";
        console.log(count);
    }
};

// Function to decrement count
function  handleDecrement() {
    if (count >= 2) {
        count--;
        if (count == 1) {
            guestWord.innerText = "guest"
        }
        totalCount.innerText = count;
    }
};


// Add click event to buttons
/*incrementCount.addEventListener("click", handleIncrement);
decrementCount.addEventListener("click", handleDecrement);*/

//Map
//weather


        /////////////////////////////////////////////////////////////////////////////////////
// Initialize and add the map
//function initMap() {
//    map = new atlas.Map('map', {
//        center: [29.906334322129908, 31.19323103089259],
//        zoom: 8,
//        view: 'Auto',
//        authOptions: {
//            authType: 'subscriptionKey',
//            subscriptionKey: 'q2XSYj3iqbbuE6Vohdah_dzaPinj1cCtSMUdl9GnJFs',
//            getToken: function (resolve, reject, map) {
//                var tokenServiceUrl = "https://samples.azuremaps.com/api/GetAzureMapsToken";
//                fetch(tokenServiceUrl).then(r => r.text()).then(token => resolve(token));
//            }
//        }
//    });
//}
//window.initMap = initMap;

///Small Search Bar
let smallSearchBar = document.getElementById("smallSearchBar");
let largeSearchBar = document.getElementById("largeSearchBar");
let fadeDiv = document.getElementById("fade");
smallSearchBar.addEventListener("click", () => {
    smallSearchBar.style.display = "none";
    largeSearchBar.classList.remove("d-none");
    largeSearchBar.classList.add("d-flex");
    setTimeout(() => {
        largeSearchBar.style.width = "50rem";
    }, 20);
    ////Fade Div
    fadeDiv.style.display = "block";
    fadeDiv.style.top = window.getComputedStyle(navBarSection).height;
    fadeDiv.style.height = window.getComputedStyle(document.body).height;

})
incrementCountSearch.addEventListener("click", () => {
    countSearch++;
    totalCountSearch.innerText = countSearch;
    if (countSearch == 1) {
        guestWordSearch.innerText = "guest"
    }
    else { guestWordSearch.innerText = "guests" }
    whoText.innerText = totalCountSearch.innerText + " " + guestWordSearch.innerText;
    whoinput.value = totalCountSearch.innerText;
    whoText.classList.add("fs-6", "fw-semibold");
    xBtnWho.classList.remove("d-none");
    xBtnWho.classList.add("d-block");
});
decrementCountSearch.addEventListener("click", () => {
    if (countSearch >= 2) {
        countSearch--;
        if (countSearch == 1) {
            guestWordSearch.innerText = "guest"
        }
        totalCountSearch.innerText = countSearch;
        whoText.innerText = totalCountSearch.innerText + " " + guestWordSearch.innerText;
        whoinput.value = totalCountSearch.innerText;
        whoText.classList.add("fs-6", "fw-semibold");
    }
});

//Switch Event
let body = document.body;
body.addEventListener("click", (e) => {
    largeSearchBar.style.width = "0rem";
    smallSearchBar.style.display = "block";
    largeSearchBar.classList.remove("d-flex");
    largeSearchBar.classList.add("d-none");
    fadeDiv.style.display = "none";
})
let navBarSection = document.getElementById("navBarSection");
navBarSection.addEventListener("click", (e) => {
    e.stopPropagation();
})

//////Where Select
let whereItems = document.getElementsByClassName("whereItem");
let whereText = document.querySelector(".WhereText");
let dropdownMenu = document.querySelector(".dropdown-menu");
for (const item of whereItems) {
    item.addEventListener("click", () => {
        whereText.value = item.innerText;

        whereText.classList.add("fs-6", "fw-semibold");
        xBtnWhere.classList.remove("d-none");
        xBtnWhere.classList.add("d-block");
    })
}

//X Button Where
let xBtnWhere = document.getElementById("xBtnWhere");
xBtnWhere.addEventListener("click", () => {
    whereText.innerText = "Search Destinations"
    whereText.value = "";
    whereText.classList.remove("fs-6", "fw-semibold");
    xBtnWhere.classList.remove("d-block");
    xBtnWhere.classList.add("d-none");
})

//X Button Date
let xBtnDate = document.getElementById("xBtnDate");
let PriceInput = document.getElementById("PriceInput");
function handler(e) {
    xBtnDate.classList.remove("d-none");
    xBtnDate.classList.add("d-block");
}
xBtnDate.addEventListener("click", () => {
    PriceInput.value = "";
    xBtnDate.classList.add("d-none")
})

//X Button Who
let xBtnWho = document.getElementById("xBtnWho");
xBtnWho.addEventListener("click", () => {
    whoText.innerText = "Add Guests"
    whoText.classList.remove("fs-6", "fw-semibold");
    totalCountSearch.innerText = "0";
    whoinput.value = "";
    guestWordSearch.innerText = "guest"
    xBtnWho.classList.remove("d-block");
    xBtnWho.classList.add("d-none");
    countSearch = 0;
})

//Share Button
const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]')
const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl))
function myFunction() {
    // Get the text field
    var copyText = window.location.href;
    // Copy the text inside the text field
    navigator.clipboard.writeText(copyText);
}

//ClearBtn
var ClearBtn = document.getElementById("ClearBtn");
ClearBtn.addEventListener("click", () => {
    CheckIn_Input.value = "";
    CheckIn_Output.value = "";
    count = 1;
    totalCount.innerHTML = "1";
    reserve_btn.innerText = "Check availability"
    reserve_btn.type = "button"
    notChargeYetDiv.classList.remove("d-block");
    notChargeYetDiv.classList.add("d-none");
    CancellationAddDatesBtn.classList.remove("d-none");
    CancellationAddDatesBtn.classList.add("d-block");

})
//CheckIn_Input Btn
var CheckIn_Input = document.getElementById("CheckIn_Input");
var reserve_btn = document.getElementById("reserve-btn");
var notChargeYetDiv = document.getElementById("notChargeYetDiv");
function ReserveBtn() {
    if (document.getElementById("check_out").value.trim()!='') {
        reserve_btn.innerText = "Reserve"
        reserve_btn.type = "submit"
        notChargeYetDiv.classList.remove("d-none");
        notChargeYetDiv.classList.add("d-block");
    }
}

//CheckIn_Output
var CheckIn_Output = document.getElementById("CheckIn_Output");
var CancellationText = document.getElementById("CancellationText");
var CancellationAddDatesBtn = document.getElementById("CancellationAddDatesBtn");
function CheckOutChange(e) {
    CancellationText.innerText = "Free cancellation for 48 hours."
    CancellationAddDatesBtn.classList.remove("d-block");
    CancellationAddDatesBtn.classList.add("d-none");

}

//ReportBtn
/*var ReportRadios = document.getElementsByClassName("form-check-input");*/
var flexRadioDefault1 = document.getElementById("flexRadioDefault1");
var ReportBtn = document.getElementById("ReportBtn");
function radio() {
    ReportBtn.disabled = false;
}

//Search Handling
var search_btn = document.getElementById("search-btn");
search_btn.addEventListener("click", (event) => {
    if (whoinput.value == "" && whereText.value == "" && PriceInput.value == "") {
        alert("Pleaze Enter data to search");
        event.stopImmediatePropagation();
        search_btn.type = "button";
    }
    else if (PriceInput.value < 0) {
        alert("Invalid Price !");
        event.stopImmediatePropagation();
        PriceInput.value = "";
        search_btn.type = "button";
    }
    else {
        search_btn.type = "submit"
    }
})




//pass guest to payment
function GeustNum() {
    document.getElementById("guestes").value = document.getElementById("total-count").innerText;
}









