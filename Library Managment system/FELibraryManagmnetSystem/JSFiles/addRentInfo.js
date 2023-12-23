let username = document.getElementById("username");
let booktitle = document.getElementById("booktitle");
let price = document.getElementById("price");
let pickUpDate = document.getElementById("pickUpDate")
let addRentInfoBtn = document.getElementById("addRentInfoBtn");
let errorMessage = document.getElementById("errorMessage");
let successMessage = document.getElementById("successMessage");

let currentDate = new Date().toLocaleDateString();

//a function that makes a call to the api to add rentInfo
function addRentInformation(){
    let url = "http://localhost:5113/api/Users/addRentInfo";
    let newRentInfo = {
        Username: username.value,
        BookTitle: booktitle.value,
        Price: ~~price.value,
        PickUpDate: currentDate
    }

    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(newRentInfo),
        headers: {
            "Authorization" : `Bearer ${token}`,
            'Content-Type' : 'application/json'
        }
    })
    .then(response => {
        if(!response.ok){
            errorMessage.style.visibility = "visible"
            console.log("Error");
        }
        else{
            successMessage.style.visibility = "visible"
            console.log("Success");
        }
    })
    .catch(error => {
        console.log(error)
    })
}

addRentInfoBtn.addEventListener("click", function(event){
    event.preventDefault();
    addRentInformation();
})
