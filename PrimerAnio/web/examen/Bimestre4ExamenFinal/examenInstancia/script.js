var nodoARemover;
var nodoPadre;

function remover(){
    nodoARemover = document.getElementById("contenido");
    nodoPadre = nodoARemover.parentNode;
    nodoPadre.removeChild(nodoARemover);

    var botonQuitarContenido = document.getElementById("botonRemover");
    var botonAgregarContenido = document.getElementById("botonRecrear");

    botonQuitarContenido.setAttribute("disabled", true);
    botonAgregarContenido.removeAttribute("disabled");
}

function recrear() {
    nodoPadre.appendChild(nodoARemover);
    var botonQuitarContenido = document.getElementById("botonRemover");
    var botonAgregarContenido = document.getElementById("botonRecrear");

    botonQuitarContenido.removeAttribute("disabled");
    botonAgregarContenido.setAttribute("disabled", true);
}
