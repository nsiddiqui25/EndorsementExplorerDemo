import { Injectable } from '@angular/core';
import { EndorsementDemo } from './endorsement-demo.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EndorsementDemoService {
  constructor(
    private http: HttpClient
    ) { }

  formData: EndorsementDemo = new EndorsementDemo();
  readonly baseURL = 'https://localhost:44328/api/UndFormVersions';
  list: EndorsementDemo[];

  getUndFormVersion(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as EndorsementDemo[]);
  }


}
