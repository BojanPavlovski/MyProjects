// targeting necessary elements 
let body = document.getElementsByName('body');
let cardPopulatedDiv = document.getElementById('cardPopulatedDiv');

// creating a function that calls the API using fetch
function getAllBeers(){
    fetch(`https://api.punkapi.com/v2/beers`)
    .then(response => {
        // console.log(response)
        return response.json()
        .then(data => {
            // console.log(data)
            data.forEach(beer => {
              // creating a card dynamically and populating it with data from the API
                cardPopulatedDiv.innerHTML += `
                
                <div class="card mb-3" style="max-width: 700px;">
  <div class="row g-0">
    <div class="col-md-4">
      <img src="${beer.image_url}" class="img-fluid rounded-start" alt="images of beer" style="height: 300px"">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title">Name: ${beer.name}</h5>
        <p class="card-text">Description:</p>
        <p class="card-text">${beer.description}</p>
        <p class="card-text">First brewed: ${beer.first_brewed}</p>
        <p class="card-text">Tagline: ${beer.tagline}</p>
      </div>
    </div>
  </div>
</div>
                `
            });
        })
    })
}

// when the body loads the function "getAllBeers" will be called, rendering all data as instructed in the function
body.onload = getAllBeers();