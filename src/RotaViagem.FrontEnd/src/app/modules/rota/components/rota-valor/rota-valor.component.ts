import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HeaderService } from 'src/app/core/template/header/header.service';
import { RotaService } from '../../rota.service';

@Component({
  selector: 'app-rota-valor',
  templateUrl: './rota-valor.component.html',
  styleUrls: ['./rota-valor.component.css']
})
export class RotaValorComponent implements OnInit {

  selectedOrigem: string;
  selectedDestino: string;

  origem: string[] = [];
  destino: string[] = [];
  retorno: string = "";
  
  constructor(private serv: RotaService, private headerService: HeaderService,
    private _snackBar: MatSnackBar) {
    headerService.headerData = {
      title: 'Menor Valor',
      icon: 'attach_money',
      routeUrl: ''
   }
  }

  ngOnInit(): void {
    this.serv.listarOrigens().subscribe(result => {
      if (result.status){
        result.data.forEach(x => this.origem.push(x));
      }
      else {
        this.retorno = '';
        this._snackBar.open(result.message, '', {
          duration: 3000
        });
      }
    }, (err: HttpErrorResponse) => {
      this._snackBar.open('Erro: ' + err.message, '', {
        duration: 3000
      });
    });

    this.serv.listarDestinos().subscribe(result => {
      if (result.status){
        result.data.forEach(x => this.destino.push(x));
      }
      else {
        this.retorno = '';
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

  pesquisar(){
    this.serv.consultaRotaMenorValor(this.selectedOrigem, this.selectedDestino).subscribe(result => {
      if (result.status){
        this.retorno = result.data;
      }
      else {
        this.retorno = '';
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

}
