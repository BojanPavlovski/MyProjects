let searchInput = document.getElementById("searchInput");
let confirmBtn = document.getElementById("confirm");
let cancelBtn = document.getElementById("cancel");
let populatedDiv = document.getElementById("populatedDiv");
let searchBtn = document.getElementById("search");
let errorMessage = document.getElementById("errorMessage");
let warningMessage = document.getElementById("warningMessage");
let failedMessage = document.getElementById("failedMessage");
let successMessage = document.getElementById("successMessage");

//a function that makes a call to the API to retrieve a book based on provided title, that is going to get deleted later
function getBook(title){
    let url = `http://localhost:5113/api/Books/${title}`
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
            
            if(typeof(data.title) == 'undefined' || typeof(data.author) == 'undefined' || typeof(data.year) == 'undefined'){
                populatedDiv.innerHTML += "";
                errorMessage.style.visibility = "visible";
            }
            else{
                errorMessage.style.visibility = "hidden";
                populatedDiv.innerHTML += `
                <br>
            <div class="card" style="background-color: lightblue;">
                <div class="card-body" style="width: 300px">
                    <h5 class="card-title">Title: ${data.title}</h5>
                    <p class="card-text">Author: ${data.author}</p>
                    <p class="card-text">Year: ${data.year}</p>
                </div>
            </div>
            <br>
              
            `
            warningMessage.style.display = "block";
            }

        
        })
    })
    .catch(error => {
        console.log(error);
    })
}


    searchBtn.addEventListener("click", function(event){
        event.preventDefault();
        getBook(searchInput.value);
        populatedDiv.style.display = "block";
    
    })



//a function that makes a call to the API to delete a book based on provided tite
function deleteBook(title){
    let url = `http://localhost:5113/api/Books/${title}`
    let token = localStorage.getItem("token");

    fetch(url, {
        method: 'DELETE',
        headers: {
            "Authorization" : `Bearer ${token}`
        }
    })
    .then(response => {
        if(!response.ok){
            failedMessage.style.display = "block";
            populatedDiv.style.display = "none";
            warningMessage.style.display = "none";
        }
        else{
            successMessage.style.display = "block";
            populatedDiv.style.display = "none";
            warningMessage.style.display = "none";
        }

        console.log(response)
    })
    .catch(error => {
        console.log(error);
    })
}

confirmBtn.addEventListener("click", function(){
    deleteBook(searchInput.value);
});


cancelBtn.addEventListener("click", function(){
    errorMessage.style.visibility = "hidden";
    populatedDiv.style.display = "none";
    warningMessage.style.display ="none";
    failedMessage.style.display = "none";
    successMessage.style.display = "none";
})
