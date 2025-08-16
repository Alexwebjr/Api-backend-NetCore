import { Routes } from '@angular/router';

export const routes: Routes = [
    //{ path: '', loadComponent: () => import('./pages/home/home.component').then(m => m.HomeComponent) },
    { path: '', loadComponent: () => import('./pages/contribuyentes/contribuyentes').then(m => m.Contribuyentes) },
    { path: 'contribuyentes', loadComponent: () => import('./pages/contribuyentes/contribuyentes').then(m => m.Contribuyentes) },
    { path: 'comprobantes-fiscales', loadComponent: () => import('./pages/comprobantes-fiscales/comprobantes-fiscales').then(m => m.ComprobantesFiscales) },
    { path: '**', redirectTo: '' }
  ];