import { Component } from '@angular/core';
import { ListadoContribuyentes } from './components/listado-contribuyentes/listado-contribuyentes';
import { Contribuyente } from '../../core/models/contribuyente.model';
import { ContribuyenteService } from '../../core/services/contribuyente.service';

@Component({
  selector: 'app-contribuyentes',
  imports: [ListadoContribuyentes],
  templateUrl: './contribuyentes.html',
  styles: ``
})
export class Contribuyentes {
  
  contribuyentes: Contribuyente[] = [];

  constructor(private contribuyenteService: ContribuyenteService) {}

  ngOnInit() {
   this.fetchContribuyentes();
  }

  fetchContribuyentes(){
    this.contribuyenteService.getContribuyentes()
      //.subscribe(data => console.log(data));
      .subscribe({
        next: data => this.contribuyentes = data,
        error: err => {
          console.error('Error al obtener contribuyentes:', err);
          //aqui podemos poner alertas para notificar al usuario
        },
        complete: () => console.log('Carga de contribuyentes completada')
      });
  }
  
}
