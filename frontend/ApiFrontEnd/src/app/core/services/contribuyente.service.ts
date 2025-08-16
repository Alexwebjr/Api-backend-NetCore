import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Contribuyente } from '../models/contribuyente.model';

@Injectable({
  providedIn: 'root'
})
export class ContribuyenteService {
  baseUrl: string = environment.apiBaseUrl;

  constructor(
    private http: HttpClient,
  ){}

  getContribuyentes(): Observable<Contribuyente[]> {
    const url = `${this.baseUrl}/contribuyentes`;
    return this.http.get<Contribuyente[]>(url);
  }
  
}
