import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { RotaService } from '../../rota.service';
import { Rota } from '../../model/rota';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AddComponent } from '../dialogs/add/add.component';
import { DeleteComponent } from '../dialogs/delete/delete.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HeaderService } from 'src/app/core/template/header/header.service';

@Component({
  selector: 'app-rota',
  templateUrl: './rota.component.html',
  styleUrls: ['./rota.component.css']
})
export class RotaComponent implements OnInit {

  rotas: Rota[]
  displayedColumns = ['origem', 'destino', 'valor', 'acoes']
  
  constructor(private serv: RotaService, public dialog: MatDialog,
    private _snackBar: MatSnackBar, private headerService: HeaderService) {
      headerService.headerData = {
        title: 'Rotas',
        icon: 'mode_of_travel',
        routeUrl: ''
      }
    }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.serv.listar().subscribe(result => {
      if (result.status){
        this.rotas = result.data;
      }
      else {
        this._snackBar.open(result.message, '', {
          duration: 3000
        });
      }
    }, (err: HttpErrorResponse) => {
      this._snackBar.open('Erro: ' + err.message, '', {
        duration: 3000
      });
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(AddComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(confirm => {
      this.loadData();
    });
  }

  update(rota: Rota): void {
    const dialogRef = this.dialog.open(AddComponent, {
      width: '400px',
      data: rota
    });

    dialogRef.afterClosed().subscribe(confirm => {
      this.loadData();
    });
  }

  delete(rota: Rota): void {
    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '400px',
      data: rota
    });

    dialogRef.afterClosed().subscribe(confirm => {
      this.loadData();
    });
  }
}
