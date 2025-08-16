import { Component } from '@angular/core';
import { ComprobanteFiscal } from '../../core/models/comprobante-fiscal.model';
import { ComprobanteFiscalService } from '../../core/services/comprobante-fiscal.service';
import { ListadoComprobantesFiscales } from "./components/listado-comprobantes-fiscales/listado-comprobantes-fiscales";

@Component({
  selector: 'app-comprobantes-fiscales',
  imports: [ListadoComprobantesFiscales],
  templateUrl: './comprobantes-fiscales.html',
  styles: ``
})
export class ComprobantesFiscales {
  comprobantes: ComprobanteFiscal[] = [];

  constructor(private comprobanteService: ComprobanteFiscalService) {}

  ngOnInit() {
   this.fetchContribuyentes();
  }

  fetchContribuyentes(){
    this.comprobanteService.getComprobantesFiscales()
      .subscribe({
        next: data => this.comprobantes = data,
        error: err => {
          console.error('Error al obtener comprobante:', err);
          //aqui podemos poner alertas para notificar al usuario
        },
        complete: () => console.log('Carga de comprobante completada')
      });
  }
}
