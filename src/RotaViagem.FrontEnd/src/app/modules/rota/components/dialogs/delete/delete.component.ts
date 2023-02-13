import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Rota } from '../../../model/rota';
import { RotaService } from '../../../rota.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: Rota,
    public dialogRef: MatDialogRef<DeleteComponent>,
    private serv: RotaService,
    private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  confirmDelete(): void {
    this.serv.deletar(this.data.id).subscribe(
      (result) => {
        if (result.status){
          this.dialogRef.close();
          this._snackBar.open(result.message, '', {
            duration: 3000
          });
        }
        else {
          this.dialogRef.close();
          this._snackBar.open(result.message, '', {
            duration: 3000
          });
        }
      },
      (err: HttpErrorResponse) => {
        this._snackBar.open('Erro: ' + err.message, '', {
          duration: 3000
        });
      }
    );
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
