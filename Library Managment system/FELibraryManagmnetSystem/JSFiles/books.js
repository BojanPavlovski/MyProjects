let cardPopulatedDiv = document.getElementById('bookDiv');
let body = document.getElementsByName('body');

//a function that makes a call to the API to retrieve all books from database
function getAllBooks(){
    let url = "http://localhost:5113/api/Books";
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'GET',
        headers: {
            "Authorization" : `Bearer ${token}`
        }
    })
    .then(response => {
        console.log(response);
        return response.json()
        .then(data => {
            console.log('Books are:')
            console.log(data);
            renderBooks(data);
           
        })
    })
    .catch(error => {
        console.log(error);
    })
}

//a seperate function used for rendering data on the client side
function renderBooks(data){
    
    data.forEach(book => {
        cardPopulatedDiv.innerHTML += `
        <div class="card" style="max-width: 18rem;">
           <div class="card-body" style="width: 300px">
                    <h5 class="card-title">Title: ${book.title}</h5>
                    <p class="card-text">Author: ${book.author}</p>
                    <p class="card-text">Year: ${book.year}</p>
            </div>
        </div>
                     `
                    
    })
}

body.onload = getAllBooks();