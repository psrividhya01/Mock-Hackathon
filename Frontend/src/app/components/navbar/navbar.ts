import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  template: `
    <nav class="navbar">
      <div class="navbar-brand">
        <button class="brand-btn" (click)="goHome()">
          <h1 class="brand-title">Freelance Management</h1>
        </button>
      </div>
      <div class="navbar-menu">
        <button class="nav-btn" (click)="navigateToClientForm()">
          <span class="nav-icon"></span> Create Client
        </button>
        <button class="nav-btn" (click)="navigateToTaskForm()">
          <span class="nav-icon"></span> Assign Task
        </button>
        <button class="nav-btn" (click)="navigateToInvoiceGeneration()">
          <span class="nav-icon"></span> Generate Invoice
        </button>
        <button class="nav-btn" (click)="navigateToInvoiceList()">
          <span class="nav-icon"></span> Invoice List
        </button>
      </div>
    </nav>
  `,
  styles: [`
    .navbar {
      background: linear-gradient(135deg, #1e3c72 0%, #2a5298 100%);
      padding: 1rem 2rem;
      display: flex;
      justify-content: space-between;
      align-items: center;
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
      position: sticky;
      top: 0;
      z-index: 100;
    }

    .navbar-brand {
      flex: 1;
    }

    .brand-btn {
      background: none;
      border: none;
      cursor: pointer;
      padding: 0;
      margin: 0;
    }

    .brand-title {
      color: white;
      margin: 0;
      font-size: 1.8rem;
      font-weight: 700;
      letter-spacing: 0.5px;
    }

    .navbar-menu {
      display: flex;
      gap: 1rem;
      align-items: center;
      flex-wrap: wrap;
    }

    .nav-btn {
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
      color: white;
      border: none;
      padding: 0.7rem 1.2rem;
      border-radius: 8px;
      font-size: 0.95rem;
      font-weight: 600;
      cursor: pointer;
      display: flex;
      align-items: center;
      gap: 0.5rem;
      transition: all 0.3s ease;
      box-shadow: 0 4px 8px rgba(102, 126, 234, 0.3);
    }

    .nav-btn:hover {
      transform: translateY(-2px);
      box-shadow: 0 6px 16px rgba(102, 126, 234, 0.4);
      background: linear-gradient(135deg, #764ba2 0%, #667eea 100%);
    }

    .nav-btn:active {
      transform: translateY(0);
    }

    .nav-icon {
      font-size: 1.2rem;
    }

    @media (max-width: 768px) {
      .navbar {
        flex-direction: column;
        gap: 1rem;
        padding: 1rem;
      }

      .navbar-menu {
        width: 100%;
        justify-content: center;
      }

      .nav-btn {
        flex: 1;
        min-width: 140px;
        justify-content: center;
      }
    }

    @media (max-width: 480px) {
      .navbar {
        padding: 0.8rem;
      }

      .brand-title {
        font-size: 1.3rem;
      }

      .navbar-menu {
        gap: 0.5rem;
      }

      .nav-btn {
        padding: 0.6rem 0.8rem;
        font-size: 0.85rem;
      }

      .nav-icon {
        font-size: 1rem;
      }
    }
  `]
})
export class Navbar {
  constructor(private router: Router) {}

  goHome(): void {
    this.router.navigate(['/']);
  }

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
