import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) { }
	Create(user: LibeyUser): Observable<boolean> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.post<boolean>(uri, user);
	}
	Delete(documentNumber: string): Observable<boolean> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.delete<boolean>(uri);
	}
	ListBy(documentNumber: string = "", name: string = "", fathersLastName: string = "", mothersLastName: string = ""): Observable<Array<LibeyUser>>{
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser?documentNumber=${documentNumber}&name=${name}&fathersLastName=${fathersLastName}&mothersLastName=${mothersLastName}`;
		return this.http.get<Array<LibeyUser>>(uri);
	}
	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}
}