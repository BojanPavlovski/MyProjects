let usernameInput = document.getElementById("username");
let passInput = document.getElementById("pass");
let loginBtn = document.getElementById("loginBtn");
let errorMessage = document.getElementById("errorMessage");
// a function that calls the API to Log in
function login(){

    let url = "http://localhost:5113/api/Admin/login";   
    let loginAdmin = {
    Username: usernameInput.value,
    Password: passInput.value
    };

 fetch(url, {
    method: 'POST',
    body: JSON.stringify(loginAdmin),
    headers: {
        'Content-Type' : 'application/json'
    }
})
.then(function(response){
    console.log("Admin successfully logged in.")
    if(response.ok){
        window.location.href = "file:///C:/Users/Bojan/Desktop/Library%20Managment%20system/FELibraryManagmnetSystem/HtmlFiles/welcome.html";
    }
    else{
        errorMessage.style.visibility = "visible";
    }
    console.log(response);

    response.text()
    .then(function(token){
        localStorage.setItem("token", token);
    })
})
.catch(function(error){
    
    console.log(error);
})

};

loginBtn.addEventListener("click", function(event){
    event.preventDefault();
    login();
});


