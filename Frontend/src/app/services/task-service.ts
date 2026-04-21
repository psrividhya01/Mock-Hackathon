import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task} from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:7000/api/tasks';

  // POST - Add new task
  addTask(task: Task): Observable<Task> {
    return this.http.post<Task>(this.baseUrl, task);
  }

  // GET - All tasks
  getAllTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl);
  }

  // GET - Tasks by client ID
  getTasksByClient(clientId: number): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.baseUrl}/client/${clientId}`);
  }

  // GET - Unbilled tasks (tasks not yet invoiced)
  getUnbilledTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.baseUrl}/unbilled`);
  }

  // GET - Unbilled tasks by client
  getUnbilledTasksByClient(clientId: number): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.baseUrl}/unbilled/client/${clientId}`);
  }

  // GET - Task by ID
  getTaskById(taskId: number): Observable<Task> {
    return this.http.get<Task>(`${this.baseUrl}/${taskId}`);
  }

  // PUT - Update task
  updateTask(taskId: number, task: Task): Observable<Task> {
    return this.http.put<Task>(`${this.baseUrl}/${taskId}`, task);
  }

  // DELETE - Delete task
  deleteTask(taskId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${taskId}`);
  }
}