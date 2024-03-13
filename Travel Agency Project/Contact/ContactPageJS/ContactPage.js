//A script calling a google map API to showcase location to the user
// Initialize and add the map
let map;

async function initMap() {
  // The location of Skopje
  const position = { lat: 41.997345, lng: 21.427996 };
  // Request needed libraries.
  //@ts-ignore
  const { Map } = await google.maps.importLibrary("maps");
  const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

  // The map, centered at Uluru
  map = new Map(document.getElementById("map"), {
    zoom: 4,
    center: position,
    mapId: "DEMO_MAP_ID",
  });

  // The marker, positioned at Uluru
  const marker = new AdvancedMarkerElement({
    map: map,
    position: position,
    title: "Skopje",
  });
}

initMap();