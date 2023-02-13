import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rota } from './model/rota';
import { Result } from 'src/app/shared/model/result';

@Injectable({
  providedIn: 'root'
})
export class RotaService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  listarOrigens(): Observable<Result<string[]>>{
    return this.http.get<Result<string[]>>(`${this.baseUrl}api/Rota/GetOrigens`);
  }
  listarDestinos(): Observable<Result<string[]>>{
    return this.http.get<Result<string[]>>(`${this.baseUrl}api/Rota/GetDestinos`);
  }

  listar(): Observable<Result<Rota[]>>{
    return this.http.get<Result<Rota[]>>(`${this.baseUrl}api/Rota/GetAll`);
  }

  adicionar(rota: Rota): Observable<Result<boolean>>{
    return this.http.post<Result<boolean>>(`${this.baseUrl}api/Rota/Add`, rota);
  }

  atualizar(rota: Rota): Observable<Result<boolean>>{
    return this.http.put<Result<boolean>>(`${this.baseUrl}api/Rota/Update/${rota.id}`, rota);
  }

  deletar(id: number): Observable<Result<boolean>>{
    return this.http.delete<Result<boolean>>(`${this.baseUrl}api/Rota/Delete/${id}`);
  }

  consultaRotaMenorValor(origem: string, destino: string): Observable<Result<string>>{
    return this.http.get<Result<string>>(`${this.baseUrl}api/Rota/Get/${origem},${destino}`);
  }
}
