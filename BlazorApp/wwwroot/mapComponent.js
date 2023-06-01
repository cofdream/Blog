import 'https://api.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.js';

mapboxgl.accessToken = 'pk.eyJ1IjoiY29mZHJlYW0iLCJhIjoiY2xpZDluM3V2MDUzczNlcWpkYjUxa3N5YiJ9.tGQC3lMP0QgHtFrTywIPPw';

export function addMapToElement(element) {
    return new mapboxgl.Map({
        container: element,
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [-74.5, 40],
        zoom: 9
    });
}

export function setMapCenter(map, latitude, longitude) {
    map.setCenter([longitude, latitude]);
}