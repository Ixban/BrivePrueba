
$(document).ready(function () {
    var table = $('[data-table-3]').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        },
        "columns": [
            null,
            null,
            null,
            null,
            null,
            { "orderable": false }

        ],
        "order": [[1, "asc"]],
    });

    /* $('.form-control-search').keyup(function(){
    table.search($(this).val()).draw() ;
    }); */
});

$(document).ready(function () {
    var table = $('[data-table-2]').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        },
        "columns": [
            null,
            null,
            null,
            null,
            { "orderable": false }

        ],
        "order": [[1, "asc"]],
    });

    /* $('.form-control-search').keyup(function(){
    table.search($(this).val()).draw() ;
    }); */
});

$(document).ready(function () {
    var table = $('[data-table-1]').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        },
        "columns": [
            null,
            null,
            null,
            { "orderable": false }

        ],
        "order": [[1, "asc"]],
    });

    /* $('.form-control-search').keyup(function(){
    table.search($(this).val()).draw() ;
    }); */
});


$(document).ready(function () {
    var table = $('[data-table-4]').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        },
        "columns": [
            null,
            null,
            null,
            null,
            { "orderable": false }

        ],
        "order": [[1, "asc"]],
    });

    /* $('.form-control-search').keyup(function(){
    table.search($(this).val()).draw() ;
    }); */
});


$(document).ready(function () {
    var table = $('[data-table-5]').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        },
        "columns": [
            null,
            null,
            null,
            null,
            { "orderable": false }

        ],
        "order": [[1, "asc"]],
    });

    /* $('.form-control-search').keyup(function(){
    table.search($(this).val()).draw() ;
    }); */
});


/*Users*/
function openModal() {
    document.getElementById("exampleModalLabel").innerHTML = "Crear Usuario";
    document.getElementById("Action").setAttribute("onClick", "javascript: saveModal();");
    document.getElementById("formUser").reset();
    $("#exampleModal").modal();
}

function closeModal() {
    document.getElementById("formUser").reset();
    $("#exampleModal").modal('hide');
}

function saveModal() {


    var validation = true;

    if ($('#inputUsuario').val() == "") {
        alert("Usuario Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputTelefono').val() == "") {
        alert("Telefono Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputEmail').val() == "") {
        alert("Email Debe Ser LLenado");
        validation = false;
    }

    var data = {
        name: $('#inputNombre').val(),
        lastName: $('#inputApellidoP').val(),
        email: $('#inputEmail').val(),
        UserName: $('#inputUsuario').val()
    };

    if (validation == true) {

        $.ajax({
            url: "/Usuario/UsuarioAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });

    }

    //console.log(data);
    document.getElementById("formUser").reset();
    location.reload();
    $("#exampleModal").modal('hide');
}

function editModal() {

    var validation = true;

    if ($('#inputUsuario').val() == "") {
        alert("Usuario Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputTelefono').val() == "") {
        alert("Telefono Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputEmail').val() == "") {
        alert("Email Debe Ser LLenado");
        validation = false;
    }

    var data = {
        id: $('#inputId').val(),
        name: $('#inputNombre').val(),
        lastName: $('#inputApellidoP').val(),
        email: $('#inputEmail').val(),
        UserName: $('#inputUsuario').val()
    };

    if (validation == true) {
        $.ajax({
            url: "/Usuario/UsuarioAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });
    }


    //console.log(data);
    document.getElementById("formUser").reset();
    location.reload();
    $("#exampleModal").modal('hide');

}

function edit(id) {

    document.getElementById("exampleModalLabel").innerHTML = "Editar Usuario";
    document.getElementById("Action").setAttribute("onClick", "javascript: editModal();");

    var data = {
        id: id,
    };

    $.ajax({
        url: "/Usuario/GetUser",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (mydata) {
            //console.log(mydata);
            $('#inputId').val(mydata.id);
            $('#inputNombre').val(mydata.name);
            $('#inputApellidoP').val(mydata.lastName);
            $('#inputUsuario').val(mydata.userName);
            $('#inputEmail').val(mydata.email);
            $("#exampleModal").modal();
        }
    });

    //console.log("Editar");
    document.getElementById("formUser").reset();
    $("#exampleModal").modal();
}

function validateForm() {

    if ($('#inputUsuario').val() == "") {
        alert("Usuario Debe Ser LLenado");
        return false;
    }
    if ($('#inputTelefono').val() == "") {
        alert("Telefono Debe Ser LLenado");
        return false;
    }
    if ($('#inputEmail').val() == "") {
        alert("Email Debe Ser LLenado");
        return false;
    }
}

/*Products*/
function openModalProduct() {
    document.getElementById("exampleModalLabel").innerHTML = "Crear Producto";
    document.getElementById("Action").setAttribute("onClick", "javascript: saveModalProduct();");
    document.getElementById("formProduct").reset();
    $("#exampleModal").modal();
}

function closeModalProduct() {
    document.getElementById("formProduct").reset();
    $("#exampleModal").modal('hide');
}

function saveModalProduct() {


    var validation = true;

    if ($('#inputNombre').val() == "") {
        alert("Producto Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputSKU').val() == "") {
        alert("SKU Debe Ser LLenado");
        validation = false;
    }

    var data = {
        name: $('#inputNombre').val(),
        sku: $('#inputSKU').val(),
    };

    if (validation == true) {

        $.ajax({
            url: "/Producto/ProductoAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });

    }

    //console.log(data);
    document.getElementById("formProduct").reset();
    location.reload();
    $("#exampleModal").modal('hide');
}

function editModalProduct() {

    var validation = true;

    if ($('#inputNombre').val() == "") {
        alert("Nombre Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputSKU').val() == "") {
        alert("SKU Debe Ser LLenado");
        validation = false;
    }

    var data = {
        id: $('#inputId').val(),
        name: $('#inputNombre').val(),
        sku: $('#inputSKU').val(),
    };

    if (validation == true) {
        $.ajax({
            url: "/Producto/ProductoAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });
    }


    //console.log(data);
    document.getElementById("formProduct").reset();
    location.reload();
    $("#exampleModal").modal('hide');

}

function editProduct(id) {

    document.getElementById("exampleModalLabel").innerHTML = "Editar Prodcutor";
    document.getElementById("Action").setAttribute("onClick", "javascript: editModalProduct();");

    var data = {
        id: id,
    };

    $.ajax({
        url: "/Producto/GetProducto",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (mydata) {
            //console.log(mydata);
            $('#inputId').val(mydata.id);
            $('#inputNombre').val(mydata.name);
            $('#inputSKU').val(mydata.sku);
        }
    });

    //console.log("Editar");
    document.getElementById("formProduct").reset();
    $("#exampleModal").modal();
}

function validateFormProduct() {

    if ($('#inputNombre').val() == "") {
        alert("Nombre Debe Ser LLenado");
        return false;
    }
    if ($('#inputSKU').val() == "") {
        alert("SKU Debe Ser LLenado");
        return false;
    }
}


/*Sucursal*/
function openModalSucursal() {
    document.getElementById("exampleModalLabel").innerHTML = "Crear Sucursal";
    document.getElementById("Action").setAttribute("onClick", "javascript: saveModalSucursal();");
    document.getElementById("formSucursal").reset();
    $("#exampleModal").modal();
}

function closeModalSucursal() {
    document.getElementById("formSucursal").reset();
    $("#exampleModal").modal('hide');
}

function saveModalSucursal() {


    var validation = true;

    if ($('#inputNombre').val() == "") {
        alert("Producto Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputTelefono').val() == "") {
        alert("Telefono Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputDireccion').val() == "") {
        alert("Direccion Debe Ser LLenado");
        validation = false;
    }

    var data = {
        sucursalName: $('#inputNombre').val(),
        telefono: $('#inputTelefono').val(),
        direction: $('#inputDireccion').val(),
    };

    if (validation == true) {

        $.ajax({
            url: "/Sucursal/SucursalAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });

    }

    //console.log(data);
    document.getElementById("formSucursal").reset();
    location.reload();
    $("#exampleModal").modal('hide');
}

function editModalSucursal() {

    var validation = true;

    if ($('#inputNombre').val() == "") {
        alert("Nombre Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputTelefono').val() == "") {
        alert("Telefono Debe Ser LLenado");
        validation = false;
    }
    if ($('#inputDireccion').val() == "") {
        alert("Direccion Debe Ser LLenado");
        validation = false;
    }

    var data = {
        id: $('#inputId').val(),
        sucursalName: $('#inputNombre').val(),
        telefono: $('#inputTelefono').val(),
        direction: $('#inputDireccion').val(),
    };

    if (validation == true) {
        $.ajax({
            url: "/Sucursal/SucursalAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });
    }


    //console.log(data);
    document.getElementById("formSucursal").reset();
    location.reload();
    $("#exampleModal").modal('hide');

}

function editSucursal(id) {

    document.getElementById("exampleModalLabel").innerHTML = "Editar Sucursal";
    document.getElementById("Action").setAttribute("onClick", "javascript: editModalSucursal();");

    var data = {
        id: id,
    };

    $.ajax({
        url: "/Sucursal/GetSucursal",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (mydata) {
            //console.log(mydata);
            $('#inputId').val(mydata.id);
            $('#inputNombre').val(mydata.sucursalName);
            $('#inputTelefono').val(mydata.telefono);
            $('#inputDireccion').val(mydata.direction);
        }
    });

    //console.log("Editar");
    document.getElementById("formSucursal").reset();
    $("#exampleModal").modal();
}

function validateFormSucursal() {

    if ($('#inputNombre').val() == "") {
        alert("Nombre Debe Ser LLenado");
        return false;
    }
    if ($('#inputTelefono').val() == "") {
        alert("Telefono Debe Ser LLenado");
        return false;
    }
    if ($('#inputDireccion').val() == "") {
        alert("Direccion Debe Ser LLenado");
        return false;
    }
}


/*Inventario*/
function openModalInventory() {
    document.getElementById("exampleModalLabel").innerHTML = "Agregar Sucursal";
    document.getElementById("Action").setAttribute("onClick", "javascript: saveModalInventory();");
    document.getElementById("formInventory").reset();
    $("#exampleModal").modal();
}

function closeModalInventory() {
    document.getElementById("formInventory").reset();
    $("#exampleModal").modal('hide');
}

function saveModalInventory() {


    var validation = true;

    if ($('#inputCantidad').val() == "") {
        alert("Cantidad Debe Ser LLenado");
        validation = false;
    }

    var data = {
        amount: $('#inputCantidad').val(),
        Product: {
            id: $('#selectProduct').val()
        },
        Sucursal: {
            id: $('#selectSucursal').val()
        },
    };

    if (validation == true) {

        $.ajax({
            url: "/Inventory/InventoryAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });

    }

    //console.log(data);
    document.getElementById("formInventory").reset();
    location.reload();
    $("#exampleModal").modal('hide');
}

function editModalInventory() {

    var validation = true;

    if ($('#inputCantidad').val() == "") {
        alert("Cantidad Debe Ser LLenado");
        validation = false;
    }

    var data = {
        amount: $('#inputCantidad').val(),
        Product: {
            id: $('#selectProduct').val()
        },
        Sucursal: {
            id: $('#selectSucursal').val()
        },
        id: $('#inputId').val(),
    };

    if (validation == true) {
        $.ajax({
            url: "/Inventory/InventoryAdd",
            type: "POST",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (mydata) {
                //console.log(mydata);
            }
        });
    }


    //console.log(data);
    document.getElementById("formInventory").reset();
    location.reload();
    $("#exampleModal").modal('hide');

}

function editInventory(id) {

    document.getElementById("exampleModalLabel").innerHTML = "Editar Inventorio";
    document.getElementById("Action").setAttribute("onClick", "javascript: editModalInventory();");

    var data = {
        id: id,
    };

    $.ajax({
        url: "/Inventory/GetInventory",
        type: "POST",
        dataType: "json",
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (mydata) {
            //console.log(mydata, "mydata")
            $('#inputId').val(mydata.id);
            $('#inputCantidad').val(mydata.amount);
            $('#selectProduct').val(mydata.product.id);
            $('#selectSucursal').val(mydata.sucursal.id);
        }
    });

    //console.log("Editar");
    document.getElementById("formInventory").reset();
    $("#exampleModal").modal();
}

function validateFormSucursal() {

    if ($('#inputCantidad').val() == "") {
        alert("Cantidad Debe Ser LLenado");
        return false;
    }
}

$(document).ready(function () {

        $.ajax({
            url: "/Inventory/GetProductos",
            type: "POST",
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                $.each(data, function (i, data) {
                    //console.log(data, "Aqui");
                    $("#selectProduct").append('<option value="' + data.Value + '">' + data.Text + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
        return false;
  
});

$(document).ready(function () {

    $.ajax({
        url: "/Inventory/GetSucursales",
        type: "POST",
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            $.each(data, function (i, data) {
                //console.log(data, "Aqui");
                $("#selectSucursal").append('<option value="' + data.Value + '">' + data.Text + '</option>');
            });
        },
        error: function (ex) {
            alert('Failed.' + ex);
        }
    });
    return false;

});