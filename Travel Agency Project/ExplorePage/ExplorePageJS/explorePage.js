//selectors
let destinations = document.getElementById("destinations");
let pricesSelect = document.getElementById("prices");
let inputField = document.getElementById("inputField");
let displayDestinationsDiv = document.getElementById("childDisplayDestinationsDiv");
let errorDiv = document.getElementById("errorDiv");
let searchBtn = document.getElementById("searchBtn");

//Object Constructor
function Destination(destinationType,country, destinationName, price, description, passangerCapacity){
    this.destinationType = destinationType;
    this.country = country;
    this.destinationName = destinationName;
    this.price = price;
    this.description =  description;
    this.passangerCapacity = passangerCapacity;
}

//An array with Destinations that serves as an in-memory database
let destinationArray = [
    new Destination('Africa', 'Egypt', 'Cairo', 800, 'placeholder text for description', 30),
    new Destination('Africa', 'Egypt', 'Hurghada', 1200, 'placeholder text for description', 30),
    new Destination('Africa', 'Egypt', 'Sharm El-Sheikh', 1300, 'placeholder text for description', 30),
    new Destination('Africa', 'Egypt', 'Alexandria', 1000, 'placeholder text for description', 30),
    new Destination('Africa', 'Zanzibar', 'Zanzibar City', 1300, 'placeholder text for description', 30),
    new Destination('Europe', 'France', 'Paris', 500, 'placeholder text for description', 20),
    new Destination('Europe', 'Spain', 'Barcelona', 550, 'placeholder text for description', 20),
    new Destination('Europe', 'Spain', 'Madrid', 600, 'placeholder text for description', 20),
    new Destination('Europe', 'Spain', 'Marbella', 800, 'placeholder text for description', 20),
    new Destination('Europe', 'Italy', 'Rome', 600, 'placeholder text for description', 20),
    new Destination('Europe', 'Italy', 'Milan', 650, 'placeholder text for description', 20),
    new Destination('Europe', 'Italy', 'Napoli', 700, 'placeholder text for description', 20),
    new Destination('Europe', 'Greece', 'Athens', 350, 'placeholder text for description', 20),
    new Destination('Europe', 'Greece', 'Mykonos', 1550, 'placeholder text for description', 20),
    new Destination('Asia', 'Japan', 'Tokio', 2200, 'placeholder text for description', 15),
    new Destination('Asia', 'Japan', 'Kyoto', 2100, 'placeholder text for description', 15),
    new Destination('Asia', 'Japan', 'Hiroshima', 2200, 'placeholder text for description', 15),
    new Destination('Asia', 'China', 'Beijing', 2500, 'placeholder text for description', 15),
    new Destination('Asia', 'India', 'New Delhi', 2500, 'placeholder text for description', 10),
    new Destination('Asia', 'Thailand', 'Bangkok', 2000, 'placeholder text for description', 15)
]

// function for filtering Destinations by destination type
function getByDestinationType(destinationArray, destinationType){
    // logic for filtering Destinations by destination type
    if(destinationType == 'undefined' || destinationType == null || typeof(destinationType)!= 'string'){
        console.log('That destination does not exist.');
    }
    else if(destinationType){
        let filteredDestinationArray = destinationArray.filter((destination) => destination.destinationType === destinationType);
        render(filteredDestinationArray);
        return filteredDestinationArray;
    }
}

//function that returns an array with Destinations with prices 
// in ascending or descending order depending on user input
//and renders the objects inside the array in Boostrap cards
function getByPriceRange(array, priceInput){
    //let copy = copiedDestinationArray(array);
    if(priceInput == 'low-high' || priceInput == ""){   
        let newArr = array.sort((d1, d2) => (d1.price - d2.price));
        render(newArr);
    }
    else if(priceInput == 'high-low'){
       let newArr = array.sort((d1, d2) => d2.price - d1.price);
       render(newArr); 
    }
    else{
        console.log("An error occured.")
    }
    
}

//a function that returns a Destination depending on user input
//and renders the objects inside the array in Bootstrap cards
function getDestinationByUserInput(array, userInput){
    let input = userInput.toLowerCase();
    if(input == 'undefined' || input == null || typeof(input) != 'string'){
        console.log('An error occured.')
    }

    let filteredArray = array.filter((destination) => destination.destinationName.toLowerCase() == input);

    if(filteredArray.length == 0){
        errorDiv.style.display = "block";
        displayDestinationsDiv.style.display = "none";
    }
    else{
        render(filteredArray);
    }
}

//a function that combines previous functions that returns filtered arrays depending on user input
function getDestinations(array, destinationType, priceInput, userInput){
    if(destinationType == "" && priceInput == ""  && userInput == ""){
        return getByPriceRange(array , priceInput);
    }
    if(destinationType && priceInput){
        let result = destinationArray.filter((destination) => destination.destinationType == destinationType);
        return getByPriceRange(result, priceInput);
    }

    if(priceInput && destinationType == ""){
        return getByPriceRange(array, priceInput);
    }

    if(destinationType && priceInput == ""){
        return getByDestinationType(array, destinationType);
    }

    if(userInput == 'undefined' || userInput == null || typeof(userInput) != 'string'){
        console.log("An error occured.")
    }
    else{
        return getDestinationByUserInput(array, userInput);
    }
}

//a seperate function we use to render data from arrays to the UI
function render(array){
    array.forEach(obj => {
        displayDestinationsDiv.innerHTML += `
        <div class="card">
        <div class="card-header">
          ${obj.destinationType}
        </div>
        <div class="card-body">
          <h5 class="card-title">Destination name: ${obj.destinationName}</h5>
          <p class="card-text">Description: ${obj.description}</p>
          <p class="card-text">Price: ${obj.price}$</p>
        </div>
      </div>
        `
    });
}

//adding an event listener that fires when user clicks the search button and calls the getDestinations function
searchBtn.addEventListener("click", function (){
    getDestinations(destinationArray, destinations.value, pricesSelect.value, inputField.value);
});


