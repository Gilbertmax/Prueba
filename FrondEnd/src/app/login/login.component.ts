
import { Component } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-login',
  template: `
    <form (submit)="login()">
      <label>Username: <input [(ngModel)]="username" name="username" /></label>
      <label>Password: <input [(ngModel)]="password" name="password" type="password" /></label>
      <button type="submit">Login</button>
    </form>
  `,
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private authService: AuthService) { }

  login() {
    this.authService.login(this.username, this.password).subscribe(
      (response) => {
        // Manejar la respuesta del servidor, por ejemplo, almacenar el token en localStorage
        console.log(response.token);
        // Redirigir a una página después del inicio de sesión exitoso
      },
      (error) => {
        // Manejar errores
        console.error(error);
      }
    );
  }
}
