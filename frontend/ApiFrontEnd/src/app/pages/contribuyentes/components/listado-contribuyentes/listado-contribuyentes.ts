import { CommonModule, CurrencyPipe, TitleCasePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Contribuyente } from '../../../../core/models/contribuyente.model';
import { ComprobanteFiscal } from '../../../../core/models/comprobante-fiscal.model';
import { ListadoComprobantesFiscales } from "../../../comprobantes-fiscales/components/listado-comprobantes-fiscales/listado-comprobantes-fiscales";
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-listado-contribuyentes',
  imports: [TitleCasePipe, ListadoComprobantesFiscales, CurrencyPipe],
  templateUrl: './listado-contribuyentes.html',
  styles: ``
})
export class ListadoContribuyentes {
  @Input() contribuyentes: Contribuyente[] = []; 

  private modalInstance?: Modal;

  contribuyente: Contribuyente | null = null;
  comprobantes: ComprobanteFiscal[] = [];

  get totalItbis(): number {
    return this.contribuyente?.comprobantesFiscales?.reduce(
      (acc, item) => acc + item.itbis18,
      0
    ) ?? 0;
  }

  getAlertClass(estatus: string) {
    switch (estatus) {
      case 'activo':
        return 'alert alert-success py-1 px-2 m-0';
      case 'inactivo':
        return 'alert alert-danger py-1 px-2 m-0';
      case 'suspendido':
        return 'alert alert-warning py-1 px-2 m-0';
      default:
        return 'alert alert-secondary py-1 px-2 m-0';
    }
  }

  selectedContribuyente(contribuyente: Contribuyente){
    this.contribuyente = contribuyente;
  }

  verComprobantes(contribuyente: Contribuyente) {
    this.selectedContribuyente(contribuyente);
    this.comprobantes = this.contribuyente?.comprobantesFiscales || [];
    this.abrirModal();
  }

  abrirModal() {
    const modalEl = document.getElementById('comprobanteModal');
    if (modalEl) {
      this.modalInstance = new Modal(modalEl, {});
      this.modalInstance.show();
    }
  }

  cerrarModal() {
    this.modalInstance?.hide();
  }

}
