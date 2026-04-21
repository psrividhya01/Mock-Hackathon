export interface Task {
  taskId:      number;
  taskName:    string;
  hoursWorked: number;
  description: string;
  status:      'pending' | 'in-progress' | 'completed';
  clientId:    number;
  amount?:      number; // Optional field to store calculated amount for the task
}