import { Component, Host, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import swal from 'sweetalert2';

@Component({
  selector: 'app-useritem',
  templateUrl: './useritem.component.html',
  styleUrls: ['./useritem.component.css']
})
export class UseritemComponent implements OnInit {
  @Input() parent: any;
  @Input() item: LibeyUser = {
    documentNumber: "",
    documentTypeId: 0,
    documentTypeDescription: "",
    name: "",
    fathersLastName: "",
    mothersLastName: "",
    address: "",
    regionCode: "",
    regionDescription: "",
    provinceCode: "",
    provinceDescription: "",
    ubigeoCode: "",
    ubigeoDescription: "",
    phone: "",
    email: "",
    password: "",
    active: true,
  };


  constructor(private libeyUserService: LibeyUserService, private router: Router) { }

  ngOnInit(): void {
  }

  Eliminar(documentNumber: string) {
    swal.fire({
      title: "Confirmación",
      icon: "info",
      html: `¿Está seguro que desea eliminar el registro?`,
      showCloseButton: true,
      showCancelButton: true,
      focusConfirm: false,
      confirmButtonText: `
          <i class="fa fa-thumbs-up"></i> Si, confirmo!
        `,
      confirmButtonAriaLabel: "Listo!",
      cancelButtonText: `
          <i class="fa fa-thumbs-down"></i> No, cancelar
        `,
      cancelButtonAriaLabel: "Uff!"
    }).then(({ isConfirmed }) => {
      if (isConfirmed) {
        this.libeyUserService.Delete(documentNumber).subscribe({
          next: response => {
            if (response == true) {
              this.parent.Listar();
              swal.fire("Bien!", "Se eliminó con éxito!", "success");
            }
            else swal.fire("Oops!", "Ocurrió un error!", "error");
          },
          error: (e) => {
            swal.fire("Oops!", "Ocurrió un error!", "error");
          }
        });
      }
    })
  }
}
