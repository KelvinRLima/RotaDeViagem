import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RotaValorComponent } from './components/rota-valor/rota-valor.component';
import { RotaComponent } from './components/rota/rota.component';


const routes: Routes = [
  { path: '', redirectTo: 'rota', pathMatch: 'full'},
  {
    path: 'rota', component: RotaComponent
  },
  {
    path: 'rota-valor', component: RotaValorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RotaRoutingModule { }
