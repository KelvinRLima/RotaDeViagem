import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RotaRoutingModule } from './rota-routing.module';
import { RotaComponent } from './components/rota/rota.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { RotaValorComponent } from './components/rota-valor/rota-valor.component';
import { AddComponent } from './components/dialogs/add/add.component';
import { DeleteComponent } from './components/dialogs/delete/delete.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [RotaComponent, AddComponent, DeleteComponent, RotaValorComponent],
  imports: [
    CommonModule,
    RotaRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class RotaModule { }
