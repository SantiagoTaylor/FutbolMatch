
var estCurrent;

function showData(e, dataCurrentEst) {
    if (dataCurrentEst != null) {
        estCurrent = dataCurrentEst;
    }
    else {
        dataCurrentEst = estCurrent;
    }
    const container = $('.container-data');
    container.empty();
    const sltValue = e.value;
    let objs = "";
    if (sltValue == "users") {
        if (dataCurrentEst.Employees.length != 0) {
            let status = "", stColor, role;
            dataCurrentEst.Employees.forEach((emp) => {
                switch (emp.Blocked) {
                    case true:
                        status = "Bloqueado";
                        stColor = "red";
                        break;
                    case false:
                        status = "No Bloqueado";
                        stColor = "green";
                        break;
                }
                const elEmp = ` 
                    <article class="col-md-4 mt-1">
                            <div class="card p-0 item-data">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img class="bd-placeholder-img img-fluid rounded-start" src="https://st3.depositphotos.com/15648834/17930/v/450/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg"
                                            alt="Imagen" style="width: 100%; height: 100%; object-fit: cover;">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body" onclick=()>
                                            <h5 class="card-title fs-6 d-flex justify-content-between">${emp.Name} ${emp.Lastname}<a class="text-end" href="frmRegisterEmployee.aspx?username=${emp.Username}"><i class="bi bi-pencil-square"></i></a> </h5>
                                                <div class="d-flex flex-column">
                                                    <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Username:</strong> ${emp.Username}</p>
                                                    <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Rol:</strong> ${emp.Role}</p>
                                                    <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Estado:</strong><span style="color:${stColor};"> ${status}</span></p>
                                                <div class="btn-group mt-1" role="group">
                                                    <button class="card-text mb-0 btn btn-primary" type="button" style="font-size:.8rem; white-space: nowrap; text-overflow: ellipsis; overflow:hidden; display: inline-block; min-width: 80px;" onclick="window.open('https://mail.google.com/mail/?view=cm&fs=1&to=${emp.Email}', '_blank'); return false;">Correo</button>
                                                    <button class="card-text mb-0 btn btn-success" type="button" style="font-size:.8rem; white-space: nowrap; text-overflow: ellipsis; overflow:hidden; display: inline-block; min-width: 80px;" onclick="window.open('https://wa.me/+549${emp.Phone}', '_blank'); return false;">WhatsApp</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </article>`;
                objs += elEmp;
            });
        } else {
            container.append(`<p class="text-center">No hay Empleados registrados</p>`);
        }
    } else if (sltValue == "fields") {
        if (dataCurrentEst.Fields.length != 0) {
            dataCurrentEst.Fields.forEach((field) => {
                const elField = ` 
                    <article class="col-md-4 mt-1">
                            <div class="card p-0 item-data">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img class="bd-placeholder-img img-fluid rounded-start" src="https://i.pinimg.com/originals/9c/76/c6/9c76c63586c831cb638e9de05f3f0748.jpg"
                                            alt="Imagen" style="width: 100%; height: 100%; object-fit: cover;">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h5 class="card-title fs-6">${field.FieldName}</h5>
                                            <div class="d-flex flex-column">
                                                <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Tipo:</strong> ${field.FloorType}</p>
                                                <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Tamaño:</strong> ${field.Size}</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </article>`;
                objs += elField;
            });
        }
        else {
            container.append(`<p class="text-center">No hay Canchas registradas</p>`);
        }
    }
    container.append(objs);
}

window.showData = showData;