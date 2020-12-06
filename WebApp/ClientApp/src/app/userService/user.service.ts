import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'https://localhost:44348/';
  constructor(private http: HttpClient) { }

  SaveUser(user) {
    return this.http.post(this.rootUrl + 'api/User/Create', user);
  }


  getAllUsers() {
    return this.http.get(this.rootUrl + 'api/User/Get');
  }

  EditUser(user) {
    return this.http.post(this.rootUrl + 'api/User/Update', user);
  }

  DeleteUser(id) {
    return this.http.get(this.rootUrl + 'api/User/Delete/'+id);
  }
}
