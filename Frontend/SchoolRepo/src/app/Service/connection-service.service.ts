import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ConnectionServiceService {

  baseURL: string = 'https://localhost:7257/';
  constructor(private http: HttpClient) { }

  public headers = new HttpHeaders({
    'Content-Type': 'application/json'
  })

  GetAverage() {
    return this.http.get<Performance>(this.baseURL + `Performance/GetAverage`, { headers: this.headers });
  }

  GetAllStudents(){
    return this.http.get<Performance>(this.baseURL + `Student/GetAllStudents`, { headers: this.headers });
  }
}
