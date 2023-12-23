let userPopulatedDiv = document.getElementById("userDiv");
let body = document.getElementsByName('body');
//a function that makes a call to the API that retrieves all Users from database
function getAllUsers(){
    let url = "http://localhost:5113/api/Users";
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
            data.forEach(user => {
                userPopulatedDiv.innerHTML += `
                <div class="card" style="max-width: 18rem;" style="display: inline-grid;">
                    <div class="card-body" style="width: 300px">
                                <p class="card-title">Firstname: ${user.firstName}</p>
                                <p class="card-text">Lastname: ${user.lastName}</p>
                                <p class="card-text">Address: ${user.address}</p>
                                <p class="card-text">Phonenumber: ${user.phonenumber}</p>
                                <p class="card-text">Email: ${user.email}</p>
                                <p class="card-text">Username: ${user.userName}</p>
                                <p>Rented Books:${user.rentedBooks} </p>
                    </div>
                </div>
                `
            });
        })
    })
}



body.onload = getAllUsers();