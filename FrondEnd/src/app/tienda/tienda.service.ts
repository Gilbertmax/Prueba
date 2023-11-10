import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TiendaService {
  private apiUrl = '/api/tienda';

  constructor(private http: HttpClient) { }

 
}
