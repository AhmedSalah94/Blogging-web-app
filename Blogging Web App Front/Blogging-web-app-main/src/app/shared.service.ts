import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { environment } from 'src/environments/environment';
import { IResponse } from './ViewModels/iresponse';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  options ={headers:new HttpHeaders({ 'Content-Type': 'application/json',
  'Access-Control-Allow-Origin': '*',
  'Access-Control-Allow-Headers': 'Content-Type',
  'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT'})}

  constructor(private httpservice:HttpClient) {}
  getBlogList(): Observable<IResponse>
   {
        this.httpservice.get<IResponse>(`${environment.APIUrl}/Blogs`).subscribe({
          next:(res)=>console.log(res)
        });
        return this.httpservice.get<IResponse>(`${environment.APIUrl}/Blogs`);

  }
  addBlog(val: any) {
      return this.httpservice.post(`${environment.APIUrl}`+"/Blogs/CreateAsync" , val);
  }
  updateBlog(val: any) {
      return this.httpservice.put(`${environment.APIUrl}`+"/Blogs/UpdateAsync", val);
  }
  deleteBlog(id: any) {

      return this.httpservice.delete(`${environment.APIUrl}`+"/Blogs/DeleteAsync/" + id);

  }
}
