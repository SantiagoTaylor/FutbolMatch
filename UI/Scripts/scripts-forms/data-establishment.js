
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
                                                 <img class="bd-placeholder-img img-fluid rounded-start" src="https://media.licdn.com/dms/image/C4D03AQEH5EGs0OkeTw/profile-displayphoto-shrink_400_400/0/1544222558401?e=2147483647&v=beta&t=9J2nsw37uSb5_1q6yQ2E5Dlpzf4cr1j00uh___veQ9k"
                                                     alt="Imagen" style="width: 100%; height: 100%; object-fit: cover;">
                                             </div>
                                             <div class="col-md-8">
                                                 <div class="card-body">
                                                     <h5 class="card-title fs-6">${emp.Name} ${emp.Lastname}</h5>
                                                     <div class="d-flex flex-column">
                                                         <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Username:</strong> ${emp.Username}</p>
                                                         <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Rol:</strong> ${emp.Role}</p>
                                                         <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Telefono:</strong><a  href="https://wa.me/+549${emp.Phone}" target="_blank"> ${emp.Phone}</a></p>
                                                         <p class="card-text mb-0" style="font-size:.8rem; white-space: nowrap;"><strong>Estado:</strong><span style="color:${stColor};"> ${status}</span></p>
                                                         <button class="card-text mb-0 btn btn-primary" style="font-size:.8rem; white-space: nowrap; text-overflow: ellipsis; overflow:hidden; display: inline-block; min-width: 80px;" onclick="window.open('https://mail.google.com/mail/?view=cm&fs=1&to=${emp.Email}', '_blank'); return false;">Enviar correo</button>
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