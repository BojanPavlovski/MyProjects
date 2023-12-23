let firstnameInput = document.getElementById("firstname");
let lastnameInput = document.getElementById("lastname");
let addressInput = document.getElementById("address");
let phonenumberInput = document.getElementById("phonenumber");
let emailInput = document.getElementById("email");
let usernameInput = document.getElementById("username");
let updateBtn = document.getElementById("updateUserBtn");
let errorMessage = document.getElementById("errorMessage");
//a function that makes a call to the API to update User entity
function updateUser(){
    let url = "http://localhost:5113/api/Users/updateUser";
    let userToUpdate = {
        Firstname: firstnameInput.value,
        Lastname: lastnameInput.value,
        Address: addressInput.value,
        Phonenumber: phonenumberInput.value,
        Email: emailInput.value,
        Username: usernameInput.value
    }
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'PUT',
        body: JSON.stringify(userToUpdate),
        headers: {
            "Authorization" : `Bearer ${token}`,
            'Content-Type' : 'application/json'
        }
    })
    .then(response => {
        if(response.ok){
            console.log("Sucesss");
            errorMessage.style.visibility = "hidden";
            window.location.href = "file:///C:/Users/Bojan/Desktop/Library%20Managment%20system/FELibraryManagmnetSystem/HtmlFiles/users.html";
        }
        else{
            console.log("error updating")
            errorMessage.style.visibility = "visible";
        }
    })
    .catch(error => {
        console.log(error);
    })
}

updateBtn.addEventListener("click", function(event){
    event.preventDefault();
    updateUser();
})