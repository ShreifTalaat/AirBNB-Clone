// Select increment and decrementbuttons on Search Bar
const incrementCountSearch = document.getElementById("increment-count-search");
const decrementCountSearch = document.getElementById("decrement-count-search");
const whoText = document.getElementById("whoText");
////Who DropDown
let guestsDropDown = document.getElementById("guestsDropDown");
let whoDiv = document.getElementById("whoDiv");


// Select guest Word
const guestWordSearch = document.getElementById("guest-word-search");


// Select total count
const totalCountSearch = document.getElementById("total-count-search");
// Variable to track count
var countSearch = 0;
// Display initial count value
totalCountSearch.innerHTML = countSearch;

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












