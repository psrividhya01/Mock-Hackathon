import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { ClientForm } from './pages/client-form/client-form';
import { TaskForm } from './pages/task-form/task-form';
import { InvoiceGeneration } from './pages/invoice-generation/invoice-generation';
import { InvoiceList } from './pages/invoice-list/invoice-list';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'home', component: Home },
  { path: 'client-form', component: ClientForm },
  { path: 'task-form', component: TaskForm },
  { path: 'invoice-generation', component: InvoiceGeneration },
  { path: 'invoice-list', component: InvoiceList },
  { path: '**', redirectTo: '' }
];
