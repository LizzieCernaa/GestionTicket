const formulario = document.getElementById('formulario_perfil');
const inputs = document.querySelectorAll('#formulario_perfil textbox');

inputs.forEach((input) => {
    input.addEventListener('keyup', () => {
        console.log('teclalevantada');
    });
});

function Comprobar_clave() {
    var clave_1, clave_2;
    clave_1 = document.getElementById("txt_nueva_contrasena_1").value;
    clave_2 = document.getElementById("txt_nueva_contrasena_2").value;
    if (clave_1 != clave_2) {
        Document.ready = document.getElementById("validador_contrasena").textContent = "Contraseñas no coinciden";
    }
    else {
        if (clave_1 == clave_2) {
            Document.ready = document.getElementById("validador_contrasena").textContent = "Contraseñas coinciden";
        }

    }

};



//funciones para el cambio de estado cerrado a abierto 
function cambio_estado_cerrado_abierto(){
    var seleccion = confirm(" ¿ Reabrir el ticket nuevamente ?");
    if (seleccion) {

        //este condicion nos permite confirmar si se cambia el estado de del ticcket
        //cambiendo el seleccvalu de la lista desplegable
        document.ready = document.getElementById("List_estados").value = '2';
        alert("Se abrio el ticket nuevamente agregue un motivo")
    }
    else
    {        
        document.ready = document.getElementById("List_estados").value = '6';
    }    
    return seleccion;
};


//funciones para el cambio de estado cerrado a en proceso 
function cambio_estado_cerrado_proceso() {
    var seleccion = confirm(" ¿ Dejar el estdo del ticket en proceso nuevamente?");
    if (seleccion) {
        //este condicion nos permite confirmar si se cambia el estado de del ticcket
        //cambiendo el seleccvalu de la lista desplegable
        document.ready = document.getElementById("List_estados").value = '3';
        alert(" El estado del ticket se modifico en proceso nuevamente ")
    }
    else {
        document.ready = document.getElementById("List_estados").value = '6';
    }
    return seleccion;
};

//funciones para el cambio de estado cerrado a pendiente
function cambio_estado_cerrado_pendiente() {
    var seleccion = confirm(" ¿ Dejar el estado del ticket pendiente ?");
    if (seleccion) {
        //este condicion nos permite confirmar si se cambia el estado de del ticcket
        //cambiendo el seleccvalu de la lista desplegable
        document.ready = document.getElementById("List_estados").value = '4';
        alert(" El estado del ticket se modifico a pendiente nuevamente ")
    }
    else {
        document.ready = document.getElementById("List_estados").value = '6';
    }
    return seleccion;
};

//funciones para el cambio de estado cerrado a resuelto
function cambio_estado_cerrado_resuelto()
{

    var seleccion = confirm(" ¿ Dejar el estdo del ticket en resuelto ?");
    if (seleccion) {
        //este condicion nos permite confirmar si se cambia el estado de del ticcket
        //cambiendo el seleccvalu de la lista desplegable
        document.ready = document.getElementById("List_estados").value = '5';
        alert(" El estado del ticket se modifico a resuelto nuevamente ")
    }
    else {
        document.ready = document.getElementById("List_estados").value = '6';
        return seleccion;
    }
};

function agregar_creditos()
{    
    $("#Editar_credito").modal("show");
};


function negrita() {

    document.execCommand()
};