import { HttpErrorResponse } from "@angular/common/http";
import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Rota } from "../../../model/rota";
import { RotaService } from "../../../rota.service";

@Component({
  selector: "app-add",
  templateUrl: "./add.component.html",
  styleUrls: ["./add.component.css"],
})
export class AddComponent implements OnInit {
  titulo: string;
  rota: Rota = {
    id: 0,
    origem: "",
    destino: "",
    valor: 0
  };

  constructor(
    public dialogRef: MatDialogRef<AddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Rota,
    private serv: RotaService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    if (this.data) {
      this.titulo = "Editar Rota";
      this.rota = this.data;
      console.log("Dialog Update", this.data);
    } else {
      this.titulo = "Adicionar Rota";
    }
  }

  salvar(): void {
    if (this.rota.id == 0) {
      console.log("Add!");
      this.serv.adicionar(this.rota).subscribe(
        (result) => {
          if (result.status) {
            this.dialogRef.close();
            this._snackBar.open(result.message, "", {
              duration: 3000,
            });
          } else {
            this._snackBar.open(result.message, "", {
              duration: 3000,
            });
          }
        },
        (err: HttpErrorResponse) => {
          this._snackBar.open("Erro: " + err.message, "", {
            duration: 3000,
          });
        }
      );
    } else {
      console.log("Update!");
      this.serv.atualizar(this.rota).subscribe(
        (result) => {
          if (result.status) {
            this.dialogRef.close();
            this._snackBar.open(result.message, "", {
              duration: 3000,
            });
          } else {
            this._snackBar.open(result.message, "", {
              duration: 3000,
            });
          }
        },
        (err: HttpErrorResponse) => {
          this._snackBar.open("Erro: " + err.message, "", {
            duration: 3000,
          });
        }
      );
    }
  }

  close(): void {
    this.dialogRef.close();
  }
}
