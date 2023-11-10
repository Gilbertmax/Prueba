import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';
import { Articulo } from './articulo.model';

@Component({
  selector: 'app-cart',
  template: `
    <h2>Carrito de Compras</h2>
    <ul>
      <li *ngFor="let articulo of carrito$ | async">
        {{ articulo.descripcion }} - {{ articulo.precio | currency }}
        <button (click)="eliminarDelCarrito(articulo)">Eliminar</button>
      </li>
    </ul>
    <button (click)="vaciarCarrito()">Vaciar Carrito</button>
  `,
})
export class CartComponent implements OnInit {
  carrito$: Observable<Articulo[]>;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.carrito$ = this.cartService.getCarrito();
  }

  eliminarDelCarrito(articulo: Articulo): void {
    this.cartService.eliminarDelCarrito(articulo);
  }

  vaciarCarrito(): void {
    this.cartService.vaciarCarrito();
  }
}
