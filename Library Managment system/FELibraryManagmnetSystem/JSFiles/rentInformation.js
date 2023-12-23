let rentInfoDiv = document.getElementById("rentInfoDiv");
let body = document.getElementsByName("body");
//a function that calls an API to retrieve all rentInfo from db
function getAllRentInfo(){
    let url = "http://localhost:5113/api/RentInfo";
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'GET',
        headers: {
            "Authorization" : `Bearer ${token}`
        }
    })
    .then(response => {
        console.log(response)
        return response.json()
        .then(data => {
            data.forEach(data => {
                rentInfoDiv.innerHTML += `
            <div class="card" style="max-width: 18rem;" style="display: inline-grid;">
                <div class="card-body" style="width: 300px">
                            <p class="card-title">Name: ${data.name}</p>
                            <p class="card-text">Username: ${data.username}</p>
                            <p class="card-text">Book title: ${data.bookName}</p>
                            <p class="card-text">Price: ${data.price}</p>
                            <p class="card-text">Date of pick-up: ${data.dateOfPickUp}</p>
                            <p class="card-text">Date of return: ${data.dateOfReturn}</p>
                            
                </div>
            </div>
            `
            });
        })
    })
}

body.onload = getAllRentInfo();