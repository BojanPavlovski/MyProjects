let titleInput = document.getElementById("title");
let authorInput = document.getElementById("author");
let yearInput = document.getElementById("year");
let genreInput = document.getElementById("genre");
let availabilityInput = document.getElementById("availability");
let updateBookBtn = document.getElementById("updateBookBtn");
let errorMessage = document.getElementById("errorMessage");

let boolVal = JSON.parse(availabilityInput.value);
//a function that makes a call to the API to update Book update
function updateBook(){
    let url = "http://localhost:5113/api/Books/updateBook";
    let bookToUpdate = {
        Title: titleInput.value,
        Author: authorInput.value,
        Year: ~~yearInput.value,
        Genre: ~~genreInput.value,
        Availability: boolVal
    }
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'PUT',
        body: JSON.stringify(bookToUpdate),
        headers: {
            "Authorization" : `Bearer ${token}`,
            'Content-Type' : 'application/json'
        }
    })
    .then(function(response){
        if(response.ok){
            console.log("succesful update.");
            errorMessage.style.visibility = "hidden";
            window.location.href = "file:///C:/Users/Bojan/Desktop/Library%20Managment%20system/FELibraryManagmnetSystem/HtmlFiles/books.html";
            
        }
        else{
            errorMessage.style.visibility = "visible";
            console.log("error updating.");
        }
    })
    .catch(function(error){
        console.log(error);
    })
}

updateBookBtn.addEventListener("click", function(event){
    event.preventDefault();
    updateBook();
})