let errorMessage = document.getElementById("errorMessage");
let searchInput = document.getElementById("searchInput");
let searchBtn = document.getElementById("search");
let populatedDiv = document.getElementById("populatedDiv");

//a function that makes a call to the API that retrieves a User entity based on provided username
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