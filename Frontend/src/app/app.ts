import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { InvoiceGeneration } from './pages/invoice-generation/invoice-generation';
import { InvoiceList } from './pages/invoice-list/invoice-list';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, InvoiceGeneration, InvoiceList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Frontend');
}
