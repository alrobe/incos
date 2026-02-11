
var parrafoABorrar;
var padre;

function borrar() {
    parrafoABorrar = document.getElementById("parrafoABorrar")
    padre = parrafoABorrar.parentNode
    padre.removeChild(parrafoABorrar)

    var botonRecrear = document.getElementById("botonRecrear")
    botonRecrear.removeAttribute("disabled")

    var botonBorrar = document.getElementById("botonBorrar")
    botonBorrar.setAttribute("disabled", true)
}

function agregar() {
    padre.appendChild(parrafoABorrar)

    var botonRecrear = document.getElementById("botonRecrear")
    botonRecrear.removeAttribute("disabled")

    var botonBorrar = document.getElementById("botonBorrar")
    botonBorrar.setAttribute("disabled", true)
}