//script of image uploader 
//#region image upload 
var button = document.querySelector("#content input");
var img = document.querySelector('#firstimage');
var div=document.getElementById('image');
var delet=document.getElementById("deleteimg");
button.addEventListener('change', function (e) {
    document.getElementById("content").classList.add("d-none");
    img.classList.add("w-100");
    img.classList.add("h-100");
    img.src = window.URL.createObjectURL(this.files[0]);
    delet.classList.remove("d-none");
    document.getElementById('sub').classList.remove("d-none");
    imgup();
    document.getElementById("previewimg").src = img.src;
    document.getElementById("imagepreview").src = img.src;
    var x = document.getElementById("delete").value.split("\\")
    var last = x[x.length - 1];
    arrayofimages.push(last);
})
delet.addEventListener('click',function (e) {
    document.getElementById("content").classList.remove("d-none");
    delet.classList.add("d-none");
    img.src="";
    img.classList.remove("w-100");
    img.classList.remove("h-100");
    buttonofimg.setAttribute("disabled",true);
    button.value="";
    document.getElementById('sub').classList.add("d-none");

})
var sunimg=document.querySelectorAll(".sub-image+ input")
function upload(id){
    var label = document.querySelector(".sub-image[for=" + id + "]");
    label.children[1].classList.add("d-none");
    label.children[0].classList.remove("d-none");

    label.children[0].classList.add("w-100");
    label.children[0].classList.add("h-100");
    label.children[0].src = window.URL.createObjectURL(event.target.files[0]);
    var x = document.getElementById(id).value.split("\\")
    var last = x[x.length - 1];
    arrayofimages.push(last);
}
function show(label){
    if(!label.children[0].classList.contains("d-none"))
    label.children[2].classList.remove("d-none")
    label.children[0].classList.add("opacity-50");

    label.children[2].addEventListener('click',function (e) {
        label.children[1].classList.remove("d-none");
    label.children[0].classList.add("d-none");
    label.children[0].src="";
    label.children[0].classList.remove("w-100");
    label.children[0].classList.remove("h-100");
    label.children[2].classList.add("d-none")
    label.nextElementSibling.value="";
    buttonofimg.setAttribute("disabled",true);
    })
}
function hide(label){
    label.children[2].classList.add("d-none")
    label.children[0].classList.remove("opacity-50");
}
//#endregion
//#region counter for beds ...
let count = 1;
let count1 = 1;
let count2 = 1;
let count3 = 1;
let count4 = 1;
let count5 = count4+1;
// Counter 1 
function Counertfunc() {
    count++
    if (count < 17) {
        let span = document.querySelector(".counter");
        span.innerHTML = count;
        document.getElementById("geust").value = count;
    }
    else {
        let btn1 = document.getElementById("btn1");
        btn1.disable = true;
    }
}
function CounertfuncDown() {
    if (count > 1) {
        count--
        let span = document.querySelector(".counter");
        span.innerHTML = count;
        document.getElementById("geust").value = count;

    }
    else {
        let btn2 = document.getElementById("btn2");
        btn2.disable = true;
    }
}
// Counter 2 
function Counertfunc1() {
    count1++
    if (count1 < 51) {
        let span = document.getElementsByClassName("counter")[1];
        span.innerHTML = count1;
        document.getElementById("bedroom").value = count1;
    }
    else {
        let btn3 = document.getElementById("btn3");
        btn3.disable = true;
    }
}
function CounertfuncDown1() {
    if (count1 > 1) {
        count1--
        let span = document.getElementsByClassName("counter")[1];
        span.innerHTML = count1;
        document.getElementById("bedroom").value = count1;

    }
    else {
        let btn4 = document.getElementById("btn4");
        btn4.disable = true;
    }
}
// Counter 3
function Counertfunc2() {
    count2++
    if (count2 < 51) {
        let span = document.getElementsByClassName("counter")[2];
        span.innerHTML = count2;
        document.getElementById("beds").value = count2;

    }
    else {
        let btn5 = document.getElementById("btn5");
        btn5.disable = true;
    }
}
function CounertfuncDown2() {
    if (count2 > 1) {
        count2--
        let span = document.getElementsByClassName("counter")[2];
        span.innerHTML = count2;
        document.getElementById("beds").value = count2;

    }
    else {
        let btn6 = document.getElementById("btn6");
        btn6.disable = true;
    }
}
// Counter 4
function Counertfunc3() {
    count3++
    if (count3 < 51) {
        let span = document.getElementsByClassName("counter")[3];
        span.innerHTML = count3;
        document.getElementById("bathrooms").value = count3;

    }
    else {
        let btn7 = document.getElementById("btn7");
        btn7.disable = true;
    }
}
function CounertfuncDown3() {
    if (count3 > 1) {
        count3--
        let span = document.getElementsByClassName("counter")[3];
        span.innerHTML = count3;
        document.getElementById("bathrooms").value = count3;

    }
    else {
        let btn8 = document.getElementById("btn8");
        btn8.disable = true;
    }
}
// Counter 5
function Counertfunc4() {
    if (count5 - count4 == 1) {
        count4++;
        count5++;
    }
    else
        count4++;
    if (count4 <10) {
        let span = document.getElementsByClassName("counter")[4];
        let span1 = document.getElementsByClassName("counter")[5];
        span.innerHTML = count4;
        span1.innerHTML = count5;
        document.getElementById("minstay").value = count4;
        document.getElementById("maxstay").value = count5;
    }
    else {
        let btn9 = document.getElementById("btn9");
        btn9.disable = true;
    }
}
function CounertfuncDown4() {
    if (count4 > 1) {
        count4--
        let span = document.getElementsByClassName("counter")[4];
        span.innerHTML = count4;
        document.getElementById("minstay").value = count4;

    }
    else {
        let btn10 = document.getElementById("btn10");
        btn10.disable = true;
    }
}
// Counter 6
function Counertfunc5() {
    count5++
    if (count5 < 60) {
        let span = document.getElementsByClassName("counter")[5];
        span.innerHTML = count5;
        document.getElementById("maxstay").value = count5;

    }
    else {
        let btn11 = document.getElementById("btn11");
        btn11.disable = true;
    }
}
function CounertfuncDown5() {
    if (count5 > count4+1) {
        count5--
        let span = document.getElementsByClassName("counter")[5];
        span.innerHTML = count5;
        document.getElementById("maxstay").value = count5;

    }
    else {
        let btn12 = document.getElementById("btn12");
        btn12.disable = true;
    }
}




//#endregion 
//#region title
var text_max = 32;
var counter=document.getElementById('count_message');
var textarea=document.getElementById('text');
counter.innerHTML='0/'+ text_max;
textarea.addEventListener('keyup',function() {
  var text_length = textarea.value.length;
  var text_remaining = text_max - text_length;
  counter.innerHTML=text_length +'/'+ text_max;
  if (textarea.value.trim()!='') {
    document.getElementById("titlecheck").removeAttribute("disabled");
  }else
  document.getElementById("titlecheck").setAttribute("disabled",true);
})
//#endregion
//#region description
var desc_max = 500;
var desccounter=document.getElementById('desccount_message');
var desctextarea=document.getElementById('desctext');
desctextarea.value="You'll have a great time at this comfortable place to stay.";
desccounter.innerHTML=desctextarea.value.length+'/'+ desc_max;
desctextarea.addEventListener('keyup',function() {
var text_length = desctextarea.value.length;
  desccounter.innerHTML=text_length +'/'+ desc_max;
  if (desctextarea.value.trim()!='') {
    document.getElementById("desccheck").removeAttribute("disabled");
  }else
  document.getElementById("desccheck").setAttribute("disabled",true);
})
//#endregion
//#region price box
function incrementPrice() {
    var inputField = document.querySelector(".EGP-price input");
    var price = document.querySelector("#price");
    var value = parseInt(price.value);
    if (value < 500) {
      value += 10;
      price.value = value;
      inputField.value = value + "	£";
    }
  }
  
  function decrementPrice() {
    var inputField = document.querySelector(".EGP-price input");
    var price = document.querySelector("#price");
    var value = parseInt(price.value);
    if (value > 50) {
      value -= 10;
      price.value = value;
      inputField.value = value + "	£";
    }
  }
  //#endregion
//#region map
//weather
var map, datasource, popup;
var currentConditionsUrl = 'https://{azMapsDomain}/weather/currentConditions/json?api-version=1.0&query={query}';
var weatherTemplate = {
    //The title tag for the popup. 
    title: 'Current Conditions',
    //HTML string template with placeholders for properties of the weather response.
    content: 
        '<img class="weather-icon" src="/images/icons/weather-black/{iconCode}.png"/>' +
        '<div class="weather-content">' +
        '<div class="weather-temp">{temperature/value}&#176;</div>' +                
        'RealFeel®: {realFeelTemperature/value}&#176;C' +
        '<div class="weather-phrase">{phrase}</div>' +
        'Humidity: {relativeHumidity}&#37</div>',
    //Format numbers with two decimal places.
    numberFormat: {
        maximumFractionDigits: 2
    },
    //Since we trust the data being retrieve, don't sandbox the content so that we can use CSS classes.
    sandboxContent: false
};

////////////////////////

function GetMap() {
    map = new atlas.Map('myMap', {
        center: [29.906334322129908, 31.19323103089259],
        zoom: 8,
        view: 'Auto',
        authOptions: {
            authType: 'subscriptionKey',
            subscriptionKey: 'q2XSYj3iqbbuE6Vohdah_dzaPinj1cCtSMUdl9GnJFs',
            getToken: function (resolve, reject, map) {
                var tokenServiceUrl = "https://samples.azuremaps.com/api/GetAzureMapsToken";
                fetch(tokenServiceUrl).then(r => r.text()).then(token => resolve(token));
            }
        }
    });

    //Wait until the map resources are ready.
    map.events.add('ready', function () {
        map.setStyle({
            showBuildingModels: true,
            showFeedbackLink: false,
            showLogo: false,
            style: "blue"
        });
        //Create a data source and add it to the map.
        datasource = new atlas.source.DataSource();
        map.sources.add(datasource);
        //Create a popup but leave it closed so we can update it and display it later.
        popup = new atlas.Popup();
        //Add a click event to the map.
        map.events.add('click', getWeatherForPoint);
    });

    map.events.add('click', function(e){
        var latt= document.getElementById('lat').value = e.position[1];
        var lonn =document.getElementById('lon').value = e.position[0];
 
    const api_key = "q2XSYj3iqbbuE6Vohdah_dzaPinj1cCtSMUdl9GnJFs";

    const url = `https://atlas.microsoft.com/search/address/reverse/json?subscription-key=${api_key}&api-version=1.0&query=${latt},${lonn}`;
    // $.get({ url: `https://maps.googleapis.com/maps/api/geocode/json?latlng=${latt},${lonn}&sensor=false`, success(data) {
    //     console.log(data.results[0]);
    // }});
    fetch(url)
    .then(response => response.json())
    .then(data => {
        if(data.addresses[0].address.country=="Egypt"||data.addresses[0].address.country=="egypt"){
            // if(data.addresses[0].address.municipalitySubdivision!=undefined)
        document.getElementById("addr").value=(data.addresses[0].address.municipalitySubdivision==undefined?data.addresses[0].address.municipality:data.addresses[0].address.municipalitySubdivision)+' , '+data.addresses[0].address.countrySubdivision;   
            document.getElementById("bnum").removeAttribute("disabled");
            document.getElementById("sname").removeAttribute("disabled");

        //       else 
    //    document.getElementById("addr").value="no places available here";

    } else{
            document.getElementById("addr").value = "place must be inside egypt";
            document.getElementById("bnum").setAttribute("disabled", true);
            document.getElementById("sname").setAttribute("disabled", true);
            document.getElementById("mapchecking").setAttribute("disabled", true);

        }

    })
    .catch(error => console.log(error));
});

    
}
function updateLanguage() {
    var langOptions = document.getElementById('langOptions');
    var lang = langOptions.options[langOptions.selectedIndex].value;
    //Update the language of the map instance.
    map.setStyle({
        language: lang,
    });
}

//weather functions 
function getWeatherForPoint(e) {
    //Close the popup if it is open.
    popup.close();

    //Request the current conditions weather data and show it in the pop up.
    var requestUrl = currentConditionsUrl.replace('{query}', e.position[1] + ',' + e.position[0]);

    processRequest(requestUrl).then(response => {
        var content;

        if (response && response.results && response.results[0]) {
            //Use the weatherTemplate settings to create templated content for the popup.
            content = atlas.PopupTemplate.applyTemplate(response.results[0], weatherTemplate);
        } else {
            content = '<div style="padding:10px;">Weather data not available for this location.</div>';
        }

        popup.setOptions({
            content: content,
            position: e.position
        });

        popup.open(map);
    });
}

function processRequest(url) {
    //This is a reusable function that sets the Azure Maps platform domain, sings the request, and makes use of any transformRequest set on the map.
    return new Promise((resolve, reject) => {
        //Replace the domain placeholder to ensure the same Azure Maps cloud is used throughout the app.
        url = url.replace('{azMapsDomain}', atlas.getDomain());

        //Get the authentication details from the map for use in the request.
        var requestParams = map.authentication.signRequest({ url: url });

        //Transform the request.
        var transform = map.getServiceOptions().tranformRequest;
        if (transform) {
            requestParams = transform(url);
        }

        fetch(requestParams.url, {
            method: 'GET',
            mode: 'cors',
            headers: new Headers(requestParams.headers)
        })
            .then(r => r.json(), e => reject(e))
            .then(r => {
                resolve(r);
            }, e => reject(e));
    });
}
/////////////////////////////////////////////////////////////////////////////////////

//#endregion
//script of slider
var slide = document.getElementsByClassName("step-container");

var next = document.querySelectorAll(".step-next-btn");
// var back = document.querySelectorAll(".step-back-btn");

var x = 0;
for (let i = 0; i < next.length - 1; i++) {

    next[i].addEventListener('click', function () {
        x = i;
        slide[i].classList.add("d-none");
        slide[i + 1].classList.remove("d-none");
    })
}


function back(a) {
    a.parentElement.parentElement.classList.add("d-none");
    a.parentElement.parentElement.previousElementSibling.classList.remove("d-none");
}

//image uplaod check
var buttonofimg=document.getElementById("uploadimg");

   var labels= document.querySelectorAll(".sub-image");
   function imgup () {
    if (labels[0].nextElementSibling.value.length > 0 && labels[1].nextElementSibling.value.length > 0&& labels[2].nextElementSibling.value.length > 0&& labels[3].nextElementSibling.value.length > 0) {
        buttonofimg.removeAttribute("disabled");
    }
    else
    buttonofimg.setAttribute("disabled",true);
 }
   for (let i = 0; i< labels.length; i++) {
         labels[i].nextElementSibling.addEventListener('input',imgup)
          
       }
     
//category check

for (let i = 0; i < document.querySelectorAll("input[type=radio]").length; i++) {
    document.querySelectorAll("input[type=radio]")[i].addEventListener('change',function () {
        if (document.querySelectorAll("input[type=radio]")[0].checked||
        document.querySelectorAll("input[type=radio]")[1].checked||
        document.querySelectorAll("input[type=radio]")[2].checked)
        {
            document.getElementById("categorycheck").removeAttribute("disabled");
        }
    })

    
}

//map check 
function pass(val) {
    
    document.getElementById("addr").setAttribute("asp-route-location", document.getElementById("addr").value);

}
function buttondis() {
    if (document.getElementById("bnum").value.trim() != "" || document.getElementById("sname").value.trim() != "")
        document.getElementById("mapchecking").removeAttribute("disabled");
    else
        document.getElementById("mapchecking").setAttribute("disabled",true);
}
//image pass
var arrayofimages = [];


function passimage() {
    document.getElementById("delete").setAttribute("asp-route-images", arrayofimages);
}
//cat pass
var catId;
for (var i = 0; i < document.querySelectorAll("input[type=radio]").length; i++) {
    if (document.querySelectorAll("input[type=radio]")[i].checked) {
       catId= document.querySelectorAll("input[type=radio]")[i].id
    }
}
//function catpass(button) {
//    button.setAttribute("asp-route-catId", "dadsa");

//}

