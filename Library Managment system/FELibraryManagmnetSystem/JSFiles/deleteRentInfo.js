let usernameInput = document.getElementById("username");
let bookTitleInput = document.getElementById("bookTitle");
let searchBtn = document.getElementById("searchBtn");
let confirmBtn = document.getElementById("confirm");
let cancelBtn = document.getElementById("cancel");
let warningMessage = document.getElementById("warningMessage");
let populatedDiv = document.getElementById("populatedDiv");
let successMessage = document.getElementById("successMessage");
let failedMessage = document.getElementById("failedMessage");
let errorMessage = document.getElementById("errorMessage");

// a function that makes a call to the API to retrieve rentInfo based on username and book title, thats later is going to be deleted
function getRentInfo(username, booktitle){
    let url = `http://localhost:5113/api/RentInfo/getRentInfoByUsernameAndBookTitle/${username}/${booktitle}`
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'GET',
        headers: {
            "Authorization" : `Bearer ${token}`,
            'Content-Type' : 'application/json'
        }
    })
    .then(response => {
        if(!response.ok){
            errorMessage.style.visibility = "visible";
            populatedDiv.innerHTML += "";
        }

        console.log(response)
        return response.json()

        .then(data => {
            if(typeof(data.name) == 'undefined' || typeof(data.username) == 'undefined' || typeof(data.bookName) == 'undefined' || typeof(data.price) == 'undefined' || typeof(data.dateOfPickUp) == 'undefined' || typeof(data.dateOfReturn) == 'undefined'){
                populatedDiv.innerHTML += "";
                errorMessage.style.visibility = "visible";
            }
            else{
                errorMessage.style.visibility = "hidden";
                populatedDiv.innerHTML += `
                <br>
                <div class="card" style="background-color: lightblue;">
                    <div class="card-body" style="width: 300px">
                        <p class="card-title">Name: ${data.name}</p>
                        <p class="card-text">Username: ${data.username}</p>
                        <p class="card-text">Book title: ${data.bookName}</p>
                        <p class="card-text">Price: ${data.price}</p>
                        <p class="card-text">Date of pick-up: ${data.dateOfPickUp}</p>
                        <p class="card-text">Date of return: ${data.dateOfReturn}</p>
                    </div>
                </div>
                <br>
                `
                warningMessage.style.display = "block";
            }
        })
    })
    .catch(error => {
        console.log(error);
    })
}

searchBtn.addEventListener('click', function(event){
    event.preventDefault()
    getRentInfo(usernameInput.value, bookTitleInput.value)
})
//a function that makes a call to the API that deletes a rentInfo from database
function deleteRentInfo(username, booktitle){
    let url = `http://localhost:5113/api/RentInfo/deleteRentInfoByUsernameAndBooktitle/${username}/${booktitle}`
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'DELETE',
        headers: {
            "Authorization" : `Bearer ${token}`
        }
    })
    .then(response => {
        if(!response.ok){
            failedMessage.style.display = "block";
            populatedDiv.style.display = "none";
            warningMessage.style.display = "none";
        }
        else{
            successMessage.style.display = "block";
            populatedDiv.style.display = "none";
            warningMessage.style.display = "none";
        }

        console.log(response)
    })
    .catch(error => {
        console.log(error);
    })
}

confirmBtn.addEventListener('click', function(){
    deleteRentInfo(usernameInput.value, bookTitleInput.value);
})

cancelBtn.addEventListener('click', function(){
    errorMessage.style.visibility = "hidden";
    populatedDiv.style.display = "none";
    warningMessage.style.display ="none";
    failedMessage.style.display = "none";
    successMessage.style.display = "none";
})


