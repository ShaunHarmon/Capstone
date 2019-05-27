import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class JobsService {

  constructor(
    private http: HttpClient) { }

  getAll() {
    return this.http.get<Job[]>('/api/jobs');
  }

  //getById(id: number) {
  //  return this.http.get('/api/users/' + id);
  //}

  create(job: Job) {
    return this.http.post('/api/jobs', job);
  }

  //update(user: User) {
  //  return this.http.put('/api/users/' + user.id, user);
  //}

  //delete(id: number) {
  //  return this.http.delete('/api/users/' + id);
  //}
}


