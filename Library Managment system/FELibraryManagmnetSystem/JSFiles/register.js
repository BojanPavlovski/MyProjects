let firstnameInput = document.getElementById("firstname");
let lastnameInput = document.getElementById("lastname");
let emailInput = document.getElementById("email");
let usernameInput = document.getElementById("username");
let passwordInput = document.getElementById("pass");
let confirmPasswordInput = document.getElementById("confirmPass");
let registerBtn = document.getElementById("registerBtn");

//a function that registers an Admin by calling API with fetch
    function register(){

        let url = "http://localhost:5113/api/Admin/registerAdmin";
        let registerAdmin = {
            Firstname: firstnameInput.value,
            Lastname: lastnameInput.value,
            Email: emailInput.value,
            Username: usernameInput.value,
            Password: passwordInput.value,
            ConfirmPassword: confirmPasswordInput.value
        };
    
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(registerAdmin),
            headers: {
                'Content-Type' : 'application/json'
            }
        })
        .then(function(response){
            if(response.ok){
                console.log("Admin registered succesfully.")
                window.location.href = "file:///C:/Users/Bojan/Desktop/Library%20Managment%20system/FELibraryManagmnetSystem/HtmlFiles/login.html";
            }
            else{
                errorMessage.style.visibility = "visible";
            }
            console.log(response)
            response.text()
        })
        .catch(function(error){
            console.log(error);
        })
    };


registerBtn.addEventListener("click", function(event){
    event.preventDefault();
    register();
})



