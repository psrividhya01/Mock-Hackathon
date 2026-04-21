import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClientDetail} from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:7000/api/clients';

  // POST - Create new client
  createClient(client: ClientDetail): Observable<ClientDetail> {
    return this.http.post<ClientDetail>(this.baseUrl, client);
  }

  // GET - All clients
  getAllClients(): Observable<ClientDetail[]> {
    return this.http.get<ClientDetail[]>(this.baseUrl);
  }

  // GET - Client by ID
  getClientById(clientId: number): Observable<ClientDetail> {
    return this.http.get<ClientDetail>(`${this.baseUrl}/${clientId}`);
  }

  // GET - Client by Name
  getClientByName(name: string): Observable<ClientDetail[]> {
    const params = new HttpParams().set('name', name);
    return this.http.get<ClientDetail[]>(`${this.baseUrl}/search`, { params });
  }

  // PUT - Update client
  updateClient(clientId: number, client: ClientDetail): Observable<ClientDetail> {
    return this.http.put<ClientDetail >(`${this.baseUrl}/${clientId}`, client);
  }

  // DELETE - Delete client
  deleteClient(clientId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${clientId}`);
  }
}