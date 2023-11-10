import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ArticuloService {
  private apiUrl = '/api/articulo';

  constructor(private http: HttpClient) { }

 
}
