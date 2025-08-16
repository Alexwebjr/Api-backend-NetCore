import { ComprobanteFiscal } from "./comprobante-fiscal.model";

export interface Contribuyente {
    id: number;
    rncCedula: string;
    nombre: string;
    tipo: 'PERSONA FISICA' | 'PERSONA JURIDICA';
    estatus: 'activo' | 'inactivo' | 'suspendido';
    comprobantesFiscales?: ComprobanteFiscal[];
  }
  