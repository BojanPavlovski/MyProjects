// getting necessary elements to target
let titleInput = document.getElementById("title");
let authorInput = document.getElementById("author");
let yearInput = document.getElementById("year");
let genreInput = document.getElementById("genre");
let availabilityInput = document.getElementById("availability");
let addBookBtn = document.getElementById("addBookBtn");
let errorMessage = document.getElementById("errorMessage");

let boolVal = JSON.parse(availabilityInput.value);

//a function that calls API to add book
function addBook(){
    let url = "http://localhost:5113/api/Books/addBook";
    let newBook = {
        Title: titleInput.value,
        Author: authorInput.value,
        Year: ~~yearInput.value,
        Genre: ~~genreInput.value,
        Availability: boolVal
    }
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'POST',
        body: JSON.stringify(newBook),
        headers: {
            "Authorization" : `Bearer ${token}`,
            'Content-Type' : 'application/json'
        }
    })
    .then(function(response){
        if(response.ok){
            window.location.href = "file:///C:/Users/Bojan/Desktop/Library%20Managment%20system/FELibraryManagmnetSystem/HtmlFiles/books.html";
            console.log("Success.")
        }
        else{
            errorMessage.style.visibility = "visible";
        }
    })
    .catch(function(error){
        console.log(error);
    })
}

addBookBtn.addEventListener("click", function(event){
    event.preventDefault();
    addBook();
})
