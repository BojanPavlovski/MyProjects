let searchInput = document.getElementById("searchInput");
let searchBtn = document.getElementById("search");
let errorMessage = document.getElementById("errorMessage");
let populatedDiv = document.getElementById("populatedDiv");

//a function that calls the API to get book based on provided book title
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