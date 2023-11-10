
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Articulo } from './articulo.model';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private carrito: Articulo[] = [];
  private carritoSubject = new BehaviorSubject<Articulo[]>(this.carrito);

  getCarrito(): Observable<Articulo[]> {
    return this.carritoSubject.asObservable();
  }

  agregarAlCarrito(articulo: Articulo): void {
    this.carrito.push(articulo);
    this.carritoSubject.next([...this.carrito]);
  }

  eliminarDelCarrito(articulo: Articulo): void {
    this.carrito = this.carrito.filter((a) => a.id !== articulo.id);
    this.carritoSubject.next([...this.carrito]);
  }

  vaciarCarrito(): void {
    this.carrito = [];
    this.carritoSubject.next([...this.carrito]);
  }
}
