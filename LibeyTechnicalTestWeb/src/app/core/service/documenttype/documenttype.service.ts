import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { DocumentType } from "src/app/entities/documenttype";
@Injectable({
	providedIn: "root",
})
export class DocumentTypeService {
	constructor(private http: HttpClient) {}
	List(): Observable<Array<DocumentType>> {
		const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
		return this.http.get<Array<DocumentType>>(uri);
	}
}