import { Component } from '@angular/core';
import { ListadoContribuyentes } from './components/listado-contribuyentes/listado-contribuyentes';
import { Contribuyente } from '../../core/models/contribuyente.model';

@Component({
  selector: 'app-contribuyentes',
  imports: [ListadoContribuyentes],
  templateUrl: './contribuyentes.html',
  styles: ``
})
export class Contribuyentes {
  
  contribuyentes: Contribuyente[] = [
    { 
      rncCedula: "00112345678", 
      nombre: "JUAN PEREZ", 
      tipo: "PERSONA FISICA", 
      estatus: "activo",
      comprobantesFiscales: [
        { rncCedula: "00112345678", ncf: "E310000000001", monto: 200.00, itbis18: 36.00 },
        { rncCedula: "00112345678", ncf: "E310000000002", monto: 500.00, itbis18: 90.00 }
      ]
    },
    { 
      rncCedula: "13145678901", 
      nombre: "EMPRESAS DOMINICANAS SRL", 
      tipo: "PERSONA JURIDICA", 
      estatus: "inactivo",
      comprobantesFiscales: [
        { rncCedula: "13145678901", ncf: "B010000000001", monto: 1500.00, itbis18: 270.00 },
        { rncCedula: "13145678901", ncf: "B010000000002", monto: 3000.00, itbis18: 540.00 },
        { rncCedula: "13145678901", ncf: "B010000000003", monto: 1000.00, itbis18: 180.00 }
      ]
    },
    { 
      rncCedula: "40211222333", 
      nombre: "PEDRO GARCIA", 
      tipo: "PERSONA FISICA", 
      estatus: "suspendido",
      comprobantesFiscales: [
        { rncCedula: "40211222333", ncf: "E320000000001", monto: 750.00, itbis18: 135.00 }
      ]
    }
  ];
  
}
