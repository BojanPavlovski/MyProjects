let errorMessage = document.getElementById("errorMessage");
let usernameInput = document.getElementById("username");
let searchBtn = document.getElementById("searchBtn");
let populatedDiv = document.getElementById("populatedDiv");

//a function that makes a call to the API and retrives a user based on provided username
function getRentInfoByUsername(username){
    let url = `http://localhost:5113/api/RentInfo/getByUsername/${username}`
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

            data.forEach(rentInfo => {
                populatedDiv.innerHTML += `
                <br>
                <div class="card" style="background-color: lightblue;">
                    <div class="card-body" style="width: 300px">
                        <p class="card-title">Name: ${rentInfo.name}</p>
                        <p class="card-text">Username: ${rentInfo.username}</p>
                        <p class="card-text">Book title: ${rentInfo.bookName}</p>
                        <p class="card-text">Price: ${rentInfo.price}</p>
                        <p class="card-text">Date of pick-up: ${rentInfo.dateOfPickUp}</p>
                        <p class="card-text">Date of return: ${rentInfo.dateOfReturn}</p>
                    </div>
                </div>
                <br>
                `
                errorMessage.style.visibility = "hidden";
            });
        })
    })
    .catch(error => {
        console.log(error);
    })
}

searchBtn.addEventListener('click', function(event){
    event.preventDefault();
    getRentInfoByUsername(usernameInput.value);
})