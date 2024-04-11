import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Ubigeo } from "src/app/entities/ubigeo";
@Injectable({
	providedIn: "root",
})
export class UbigeoService {
	constructor(private http: HttpClient) {}
	ListBy(provinceCode: string): Observable<Array<Ubigeo>> {
		const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/${provinceCode}`;
		return this.http.get<Array<Ubigeo>>(uri);
	}
}