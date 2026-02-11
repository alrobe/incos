function quitarContenido(){
    var contenido = document.getElementById("contenido");
    var botonQuitarContenido = document.getElementById("botonQuitarContenido");
    var botonAgregarContenido = document.getElementById("botonAgregarContenido");
    
    contenido.hidden = true;
    var disabled = botonAgregarContenido.attributes.getNamedItem("disabled");
    botonAgregarContenido.attributes.removeNamedItem("disabled");
    botonQuitarContenido.attributes.setNamedItem(disabled);
}

function agregarContenido() {
    var contenido = document.getElementById("contenido");
    var botonQuitarContenido = document.getElementById("botonQuitarContenido");
    var botonAgregarContenido = document.getElementById("botonAgregarContenido");
    
    contenido.hidden = false;
    var disabled = botonQuitarContenido.attributes.getNamedItem("disabled");
    botonQuitarContenido.attributes.removeNamedItem("disabled");
    botonAgregarContenido.attributes.setNamedItem(disabled);
}
