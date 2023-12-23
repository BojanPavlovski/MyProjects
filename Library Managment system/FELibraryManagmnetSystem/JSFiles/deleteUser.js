let searchInput = document.getElementById("searchInput");
let confirmBtn = document.getElementById("confirm");
let cancelBtn = document.getElementById("cancel");
let populatedDiv = document.getElementById("populatedDiv");
let searchBtn = document.getElementById("search");
let errorMessage = document.getElementById("errorMessage");
let warningMessage = document.getElementById("warningMessage");
let failedMessage = document.getElementById("failedMessage");
let successMessage = document.getElementById("successMessage");

//a function that makes a call to the API, that retrieves a User,
//that is going to be delted later
function getUser(username){
    let url = `http://localhost:5113/api/Users/getUser/${username}`;
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
            if(typeof(data.firstName) == 'undefined' || typeof(data.lastName) == 'undefined' || typeof(data.address) == 'undefined' || typeof(data.phonenumber) == 'undefined'  || typeof(data.email) == 'undefined' || typeof(data.userName) == 'undefined' || typeof(data.rentedBooks) == 'undefined'){
                populatedDiv.innerHTML += "";
                errorMessage.style.visibility = "visible";
            }
            else{
                errorMessage.style.visibility = "hidden";
                populatedDiv.innerHTML += `
                <div class="card" style="max-width: 18rem;" style="display: inline-grid;">
                    <div class="card-body" style="width: 300px">
                                <p class="card-title">Firstname: ${data.firstName}</p>
                                <p class="card-text">Lastname: ${data.lastName}</p>
                                <p class="card-text">Address: ${data.address}</p>
                                <p class="card-text">Phonenumber: ${data.phonenumber}</p>
                                <p class="card-text">Email: ${data.email}</p>
                                <p class="card-text">Username: ${data.userName}</p>
                                <p>Rented Books:${data.rentedBooks} </p>
                    </div>
                </div>
              
            `
            warningMessage.style.display = "block";
            }
        })
    })
    .catch(error => {
        console.log(error);
    })
}

searchBtn.addEventListener("click", function(event){
    event.preventDefault();
    getUser(searchInput.value);
    populatedDiv.style.display = "block";
})

//a function that calls the API to delete the User entity based on provided entity
function deleteUser(username){
    let url = `http://localhost:5113/api/Users/${username}`;
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

confirmBtn.addEventListener("click", function(){
    deleteUser(searchInput.value);
});


cancelBtn.addEventListener("click", function(){
    errorMessage.style.visibility = "hidden";
    populatedDiv.style.display = "none";
    warningMessage.style.display ="none";
    failedMessage.style.display = "none";
    successMessage.style.display = "none";
})