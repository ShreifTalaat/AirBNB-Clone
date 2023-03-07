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
var countSearch = 1;

// Display initial count value
totalCount.innerHTML = count;
totalCountSearch.innerHTML = count;

// Function to increment count
const handleIncrement = () => {
    if (count < numberOfGuests) {
        count++;
        totalCount.innerText = count;
        guestWord.innerText = "guests"
    }
};

// Function to decrement count
const handleDecrement = () => {
    if (count >= 2) {
        count--;
        if (count == 1) {
            guestWord.innerText = "guest"
        }
        totalCount.innerText = count;
    }
};


// Add click event to buttons
incrementCount.addEventListener("click", handleIncrement);
decrementCount.addEventListener("click", handleDecrement);

//Map
// Initialize and add the map
function initMap() {
    // The location of Address
    const uluru = { lat: 1.924992, lng: 73.399658 };
    // The map, centered at Address
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 4,
        center: uluru,
    });
    // The marker, positioned at Address
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}
window.initMap = initMap;

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
    guestWordSearch.innerText = "guests"
    whoText.innerText = totalCountSearch.innerText + " " + guestWordSearch.innerText;
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
        whereText.innerText = item.innerText;
        whereText.classList.add("fs-6", "fw-semibold");
        xBtnWhere.classList.remove("d-none");
        xBtnWhere.classList.add("d-block");
    })
}

//X Button Where
let xBtnWhere = document.getElementById("xBtnWhere");
xBtnWhere.addEventListener("click", () => {
    whereText.innerText = "Search Destinations"
    whereText.classList.remove("fs-6", "fw-semibold");
    xBtnWhere.classList.remove("d-block");
    xBtnWhere.classList.add("d-none");
})

//X Button Date
let xBtnDate = document.getElementById("xBtnDate");
let DateInput = document.getElementById("DateInput");
function handler(e) {
    xBtnDate.classList.remove("d-none");
    xBtnDate.classList.add("d-block");
}
xBtnDate.addEventListener("click", () => {
    $("input[type=text]").val("");
    xBtnDate.classList.add("d-none")
})

//X Button Who
let xBtnWho = document.getElementById("xBtnWho");
xBtnWho.addEventListener("click", () => {
    whoText.innerText = "Add Guests"
    whoText.classList.remove("fs-6", "fw-semibold");
    totalCountSearch.innerText = "1";
    guestWordSearch.innerText = "guest"
    xBtnWho.classList.remove("d-block");
    xBtnWho.classList.add("d-none");
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










