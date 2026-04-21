import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Navbar } from '../../components/navbar/navbar';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, Navbar],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  constructor(private router: Router) {}

  navigateToClientForm(): void {
    this.router.navigate(['/client-form']);
  }

  navigateToTaskForm(): void {
    this.router.navigate(['/task-form']);
  }

  navigateToInvoiceGeneration(): void {
    this.router.navigate(['/invoice-generation']);
  }

  navigateToInvoiceList(): void {
    this.router.navigate(['/invoice-list']);
  }
}
