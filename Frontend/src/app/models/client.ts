import { Task } from './task';

export interface ClientDetail {
  clientId: string;
  clientName: string;
  email: string;
  hourlyrate: number;
  task: Task[];
  
}
