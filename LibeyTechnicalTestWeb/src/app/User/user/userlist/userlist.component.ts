import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {
  documentNumberFilter: string = "";
  nameFilter: string = "";
  fathersLastNameFilter: string = "";
  mothersLastNameFilter: string = "";
  
  libeyUsers: Array<LibeyUser> = [];

  constructor(private libeyUserService: LibeyUserService) { 
    this.Listar();
  }

  Listar(){
    this.libeyUserService.ListBy(this.documentNumberFilter, this.nameFilter, this.fathersLastNameFilter, this.mothersLastNameFilter).subscribe(response => {
      this.libeyUsers = response;
    });
  }

  ngOnInit(): void {
  }

}
