import { CommonModule, CurrencyPipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ComprobanteFiscal } from '../../../../core/models/comprobante-fiscal.model';
import { Contribuyente } from '../../../../core/models/contribuyente.model';

@Component({
  selector: 'app-listado-comprobantes-fiscales',
  imports: [CurrencyPipe],
  templateUrl: './listado-comprobantes-fiscales.html',
  styles: ``
})
export class ListadoComprobantesFiscales {
  @Input() comprobantes: ComprobanteFiscal[] = []; 
  @Input() contribuyente: Contribuyente | null =  null; 

  get totalItbis(): number {
    return this.comprobantes.reduce((acc, item) => acc + item.itbis18, 0);
  }

}
