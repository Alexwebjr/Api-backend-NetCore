import { CommonModule, TitleCasePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Contribuyente } from '../../../../core/models/contribuyente.model';
import { ComprobanteFiscal } from '../../../../core/models/comprobante-fiscal.model';
import { ListadoComprobantesFiscales } from "../../../comprobantes-fiscales/components/listado-comprobantes-fiscales/listado-comprobantes-fiscales";
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-listado-contribuyentes',
  imports: [TitleCasePipe, ListadoComprobantesFiscales],
  templateUrl: './listado-contribuyentes.html',
  styles: ``
})
export class ListadoContribuyentes {
  @Input() contribuyentes: Contribuyente[] = []; 

  private modalInstance?: Modal;

  contribuyente: Contribuyente | null = null;
  comprobantes: ComprobanteFiscal[] = [];

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

  verComprobantes(rncCedula: string) {
    this.contribuyente = this.contribuyentes.find(c => c.rncCedula === rncCedula) || null;
    this.comprobantes = this.contribuyente?.comprobantesFiscales || [];
    console.log(this.contribuyente);
    console.log(this.comprobantes);
    this.abrirModal();
  }

  abrirModal() {
    const modalEl = document.getElementById('exampleModal');
    if (modalEl) {
      this.modalInstance = new Modal(modalEl, {});
      this.modalInstance.show();
    }
  }

  cerrarModal() {
    this.modalInstance?.hide();
  }

}
