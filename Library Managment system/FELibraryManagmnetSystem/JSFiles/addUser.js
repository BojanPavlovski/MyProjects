let firstName = document.getElementById("firstName");
let lastName = document.getElementById("lastName");
let address = document.getElementById("address");
let phonenumber = document.getElementById("phonenumber");
let email = document.getElementById("email");
let username = document.getElementById("username");
let addUserBtn = document.getElementById("addUserBtn");
let errorMessage = document.getElementById("errorMessage");

//a function that makes a call to the API to add User
function addUser(){
    let url = "http://localhost:5113/api/Users";
    let newUser = {
        Firstname: firstName.value,
        Lastname: lastName.value,
        Address: address.value,
        Phonenumber: phonenumber.value,
        Email: email.value,
        Username: username.value
    }

    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(newUser),
        headers: {
            "Authorization" : `Bearer ${token}`,
            'Content-Type' : 'application/json'
        }
    })
    .then(response => {
        if(!response.ok){
            errorMessage.style.visibility = "visible";
        }
        else{
            window.location.href = "file:///C:/Users/Bojan/Desktop/Library%20Managment%20system/FELibraryManagmnetSystem/HtmlFiles/users.html";
        }
    })
    .catch(error => {
       console.log(error)
    })
}

addUserBtn.addEventListener("click", function(event){
    event.preventDefault();
    addUser();
});