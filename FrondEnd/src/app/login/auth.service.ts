import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = '/api/auth';

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const credentials = { username, password };
    return this.http.post(`${this.apiUrl}/login`, credentials);
  }

  
}
