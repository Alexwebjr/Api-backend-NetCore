import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ComprobanteFiscal } from '../models/comprobante-fiscal.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComprobanteFiscalService {
  baseUrl: string = environment.apiBaseUrl;

  constructor(
    private http: HttpClient,
  ){}

  getComprobantesFiscales(): Observable<ComprobanteFiscal[]> {
    const url = `${this.baseUrl}/ComprobantesFiscales`;
    return this.http.get<ComprobanteFiscal[]>(url);
  }
}
