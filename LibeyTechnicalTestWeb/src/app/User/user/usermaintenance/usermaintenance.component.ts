import swal from 'sweetalert2';
import { Component, DebugElement, Input, OnInit } from '@angular/core';
import { DocumentType } from 'src/app/entities/documenttype';
import { Region } from 'src/app/entities/region';
import { Province } from 'src/app/entities/province';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { DocumentTypeService } from 'src/app/core/service/documenttype/documenttype.service';
import { RegionService } from 'src/app/core/service/region/region.service';
import { ProvinceService } from 'src/app/core/service/province/province.service';
import { UbigeoService } from 'src/app/core/service/ubigeo/ubigeo.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { error } from 'console';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  documentNumberParam: string = "";
  documentNumerIsDisabled: boolean = false;

  documentTypes: Array<DocumentType> = [];
  regions: Array<Region> = [];
  provinces: Array<Province> = [];
  ubigeos: Array<Ubigeo> = [];

  documentNumber: string = "";
  documentTypeId: number = 0;
  name: string = "";
  fathersLastName: string = "";
  mothersLastName: string = "";
  address: string = "";
  regionCode: string = "";
  provinceCode: string = "";
  ubigeoCode: string = "";
  phone: string = "";
  email: string = "";
  password: string = "";

  defaultDocumentTypeId: number = 1;
  defaultRegionCode: string = "15";
  defaultProvinceCode: string = "1501";
  defaultUbigeoCode: string = "150133";

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private documentTypeService: DocumentTypeService, private regionService: RegionService, private provinceService: ProvinceService, private ubigeoService: UbigeoService, private libeyUserService: LibeyUserService) {
    this.documentNumberParam = this.activatedRoute.snapshot.paramMap.get('documentNumber') || "";
    this.documentNumerIsDisabled = this.documentNumberParam != "";
    this.documentTypeService.List().subscribe(response => {
      this.documentTypes = response;
    });
    this.regionService.List().subscribe(response => {
      this.regions = response;
    });
    this.OnChangeRegion(this.defaultRegionCode);
    this.OnChangeProvince(this.defaultProvinceCode);
    if(this.documentNumberParam != ""){
      this.libeyUserService.Find(this.documentNumberParam).subscribe(response => {
        console.log(response);
        this.OnChangeRegion(response.regionCode);
        this.OnChangeProvince(response.provinceCode);

        this.documentNumber = response.documentNumber;
        this.documentTypeId = response.documentTypeId;
        this.name = response.name;
        this.fathersLastName = response.fathersLastName;
        this.mothersLastName = response.mothersLastName;
        this.address = response.address;
        this.regionCode = response.regionCode;
        this.provinceCode = response.provinceCode;
        this.ubigeoCode = response.ubigeoCode;
        this.phone = response.phone;
        this.email = response.email;
        this.password = response.password;
      });
    }
  }

  ngOnInit(): void {
    this.documentTypeId = this.defaultDocumentTypeId;
    this.regionCode = this.defaultRegionCode;
    this.provinceCode = this.defaultProvinceCode;
    this.ubigeoCode = this.defaultUbigeoCode;
  }

  OnChangeRegion(regionCode: string) {
    this.provinceCode = "";
    this.ubigeoCode = "";
    this.provinces = [];
    this.ubigeos = [];
    if (regionCode == "") return;
    this.provinceService.ListBy(regionCode).subscribe(response => {
      this.provinces = response;
    });
  }

  OnChangeProvince(provinceCode: string) {
    this.ubigeoCode = "";
    this.ubigeos = [];
    if (provinceCode == "") return;
    this.ubigeoService.ListBy(provinceCode).subscribe(response => {
      this.ubigeos = response;
    });
  }

  Clean() {
    this.OnChangeRegion(this.defaultRegionCode);
    this.OnChangeProvince(this.defaultProvinceCode);
    this.documentNumber = "";
    this.documentTypeId = this.defaultDocumentTypeId;
    this.name = "";
    this.fathersLastName = "";
    this.mothersLastName = "";
    this.address = "";
    this.regionCode = this.defaultRegionCode;
    this.provinceCode = this.defaultProvinceCode;
    this.ubigeoCode = this.defaultUbigeoCode;
    this.phone = "";
    this.email = "";
    this.password = "";
  }

  Submit() {
    let user: LibeyUser = {
      documentNumber: this.documentNumber,
      documentTypeId: this.documentTypeId,
      documentTypeDescription: "",
      name: this.name,
      fathersLastName: this.fathersLastName,
      mothersLastName: this.mothersLastName,
      address: this.address,
      regionCode: this.regionCode,
      regionDescription: "",
      provinceCode: this.provinceCode,
      provinceDescription: "",
      ubigeoCode: this.ubigeoCode,
      ubigeoDescription: "",
      phone: this.phone,
      email: this.email,
      password: this.password,
      active: true
    }

    this.libeyUserService.Create(user).subscribe({
      next: (response) => {
        if (response == true) {
          swal.fire("Bien!", "Se registro con éxito!", "success");
          if (this.documentNumberParam == "") {
            this.Clean();
          }else{
            this.router.navigate(["/user/card"]);
          }
        }
        else {
          swal.fire("Oops!", "Something went wrong!", "error");
        }
      },
      error: (e) => {
        swal.fire("Oops!", "Ocurrió un error!", "error");
      }

    });
  }
}