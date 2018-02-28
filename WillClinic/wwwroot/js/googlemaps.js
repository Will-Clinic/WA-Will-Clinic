function initialize() {
    var latlng = new google.maps.LatLng(-34.397, 150.644);
    var options =
        {
            zoom: 3,
            center: new google.maps.LatLng(37.09, -95.71),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            mapTypeControl: true,
            mapTypeControlOptions:
            {
                style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
                poistion: google.maps.ControlPosition.TOP_RIGHT,
                mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                google.maps.MapTypeId.TERRAIN,
                google.maps.MapTypeId.HYBRID,
                google.maps.MapTypeId.SATELLITE]
            },
            navigationControl: true,
            navigationControlOptions:
            {
                style: google.maps.NavigationControlStyle.ZOOM_PAN
            },
            scaleControl: true,
            disableDoubleClickZoom: true,
            draggable: false,
            streetViewControl: true,
            draggableCursor: 'move'
        };
    var map = new google.maps.Map(document.getElementById("map"), options);
}
window.onload = initialize;