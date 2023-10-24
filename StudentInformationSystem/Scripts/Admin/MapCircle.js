$.ajaxSetup({ cache: false });

(g => {
    var h, a, k,
        p = "The Google Maps JavaScript API",
        c = "google",
        l = "importLibrary",
        q = "__ib__",
        m = document,
        b = window;
    b = b[c] || (b[c] = {});
    var d = b.maps || (b.maps = {}),
        r = new Set,
        e = new URLSearchParams,
        u = () => h || (h = new Promise(async (f, n) => {
            await (a = m.createElement("script"));
            e.set("libraries", [...r] + "");
            for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]);
            e.set("callback", c + ".maps." + q);
            a.src = `https://maps.${c}apis.com/maps/api/js?` + e;
            d[q] = f;
            a.onerror = () => h = n(Error(p + " could not load."));
            a.nonce = m.querySelector("script[nonce]")?.nonce || "";
            m.head.append(a)
        }));
    d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n))
})
    ({
        key: "AIzaSyAzDzWAbQIvmpmtl3JhY3tiVej5BHboWec",
        v: "beta"
    });


let map;
let homeCircle = null;

function GetDistance(fromLat, fromLng, toLat, toLng) {
    const R = 6371e3; // metres
    const φ1 = fromLat * Math.PI / 180; // φ, λ in radians
    const φ2 = toLat * Math.PI / 180;
    const Δφ = (toLat - fromLat) * Math.PI / 180;
    const Δλ = (toLng - fromLng) * Math.PI / 180;

    const a = Math.sin(Δφ / 2) * Math.sin(Δφ / 2) +
        Math.cos(φ1) * Math.cos(φ2) *
        Math.sin(Δλ / 2) * Math.sin(Δλ / 2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));

    const d = R * c; // in metres
    return d;
}

async function initMap() {

    const schools = JSON.parse(schoolsJson);
    const ncPosition = JSON.parse(ncPositionJson);

    // Request needed libraries.
    const { Map } = await google.maps.importLibrary("maps")
    const { AdvancedMarkerElement, PinElement } = await google.maps.importLibrary("marker")

    // The map, centered at Uluru
    map = new Map(document.getElementById("map"), {
        zoom: 15,
        center: ncPosition,
        mapId: "3a02aff5c8709231"
    })

    const ncIcon = document.createElement("div");
    ncIcon.innerHTML = '<img src="/Content/Images/nalanda_logo.png" width = "32">';
    const ncPin = new PinElement({
        scale: 2,
        glyph: ncIcon,
        glyphColor: "#800000",
        background: "#808080",
        borderColor: "#800000",
    });
    new AdvancedMarkerElement({
        map,
        position: ncPosition,
        content: ncPin.element,
        title: "Nalanda College"
    });

    schools.forEach(school => {
        const icon = document.createElement("div");
        icon.innerHTML = '<i class="fa fa-graduation-cap fa-lg"></i>';
        const faPin = new PinElement({
            glyph: icon,
            glyphColor: "#000000",
            background: "#FFD514",
            borderColor: "#000000",
        });
        new AdvancedMarkerElement({
            map,
            position: { lat: school.lat, lng: school.lng },
            content: faPin.element,
            title: school.text
        });

        new google.maps.Marker({
            position: { lat: school.lat, lng: school.lng },
            label: { text: school.text, className: 'marker-position' },
            map: map,
        });
    });

    var homeMrker = null;
    var homeLat = null;
    var homeLng = null;
    $('input[name="HomeLocation"]').on('click focus', function () { $(this).select(); });
    $('#btnSetHomeLoc').click(() => {
        homeMrker && homeMrker.setMap(null);
        homeCircle && homeCircle.setMap(null);
        var homeLoc = $('input[name="HomeLocation"]').val();
        if (!homeLoc) return;
        homeLoc = homeLoc.replace(' ', '');
        var coords = homeLoc.split(",");
        console.log(coords.length);
        if (coords.length < 2) return;
        homeLat = +coords[0];
        homeLng = +coords[1];
        map.setCenter(new google.maps.LatLng(homeLat, homeLng));

        if (homeMrker == null) {
            const icon = document.createElement("div");
            icon.innerHTML = '<i class="fa fa-home fa-3x"></i>';
            const faPin = new PinElement({
                scale: 2,
                glyph: icon,
                glyphColor: "#000000",
                background: "#ed6939",
                borderColor: "#000000",
            });
            homeMrker = new AdvancedMarkerElement({
                map,
                position: { lat: homeLat, lng: homeLng },
                content: faPin.element,
                title: "Home Location",
                gmpDraggable: true
            });

            homeCircle = new google.maps.Circle({
                strokeColor: "#000000",
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: "#000000",
                fillOpacity: 0.35,
                map,
                center: { lat: homeLat, lng: homeLng },
                radius: GetDistance(homeLat, homeLng, ncPosition.lat, ncPosition.lng),
                editable: true
            });
            var btnPrint = $('a[data-popup-editor]');
            var curHref = btnPrint.attr('href');
            var newHref = curHref.substring(0, curHref.lastIndexOf("?")) + "?homeLatitude=" + homeLat + "&homeLongitude=" + homeLng;
            btnPrint.attr('href', newHref);

            homeMrker.addListener("dragend", (event) => {
                var hLat = homeMrker.position.lat;
                var hLng = homeMrker.position.lng;

                var homeLoc = hLat + ', ' + hLng;
                $('input[name="HomeLocation"]').val(homeLoc);

                homeMrker.position = { lat: hLat, lng: hLng };
                homeCircle.setCenter(new google.maps.LatLng(hLat, hLng));
                homeCircle.setRadius(GetDistance(hLat, hLng, ncPosition.lat, ncPosition.lng));
                map.setCenter(new google.maps.LatLng(hLat, hLng));
            });
        }
        else {
            homeMrker.setMap(map);
            homeCircle.setMap(map);
            homeMrker.position = { lat: homeLat, lng: homeLng };
            homeCircle.setCenter(new google.maps.LatLng(homeLat, homeLng));
            homeCircle.setRadius(GetDistance(homeLat, homeLng, ncPosition.lat, ncPosition.lng));
        }
    });

    $('#btnFindHomeLoc').click(() => {
        window.open('https://www.google.com/maps/@' + ncPosition.lat + ',' + ncPosition.lng + ',15z?entry=ttu', '_blank');
    });

    $('#btnPrintCircle').click((e) => {
        if (BeforePrintAdmissionMap()) {
            PrintAdmissionMap(null);
        }
    });
}

initMap();

function BeforePrintAdmissionMap() {
    if (!homeCircle) {
        return false;
    }
    return true;
}

function PrintAdmissionMap(reponse) {
    const menuVisible = $('#sidebar > ul').is(":visible");

    if (reponse.data.CategoryName && reponse.data.ChildName)
        $('#printSpanHeader').text(reponse.data.CategoryName + "/" + reponse.data.ReferenceNumber + "    (" + reponse.data.ChildName + ")");
    else
        $('#printSpanHeader').text("");

    if (reponse.data.Address1)
        $('#printSpanAddress').text("Home Address : " + reponse.data.Address1 + " " + reponse.data.Address2);
    else
        $('#printSpanAddress').text("");

    $('#printSpanPosition').text("Home Location : (" + reponse.data.HomeLatitude + ", " + reponse.data.HomeLongitude + ")");
    $('#printSpanDistance').text("Distance to School : " + (homeCircle.radius / 1000).toFixed(2) + " km");

    menuVisible && $('.toggle-nav').trigger('click');

    $('#printSpanBy').text("Printed By : " + reponse.data.ModifiedBy);
    var modDate = new Date(parseInt(reponse.data.ModifiedDate.substr(6)));
    var mon = modDate.getMonth().toString().padStart(2, '0');
    var dat = modDate.getDate().toString().padStart(2, '0');
    var hrs = modDate.getHours().toString().padStart(2, '0');
    var min = modDate.getMinutes().toString().padStart(2, '0');
    var sec = modDate.getSeconds().toString().padStart(2, '0');
    var datStr = modDate.getFullYear() + "-" + mon + "-" + dat + " " + hrs + ":" + min + ":" + sec;
    $('#printSpanOn').text("Printed On : " + datStr);

    if (reponse.data.ParentName)
        $('#lblPrintApplicantName').text(reponse.data.ParentName);
    else
        $('#lblPrintApplicantName').text("");

    setTimeout(() => {
        window.print();
        menuVisible && $('.toggle-nav').trigger('click');
    }, 200);
}