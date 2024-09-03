import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

//lien ket api
export class SharedService {

  readonly  APIurl = "http://localhost:5224/api";
  readonly PhotoUrl = "http://localhost:5224/Photos";

  constructor(private http:HttpClient) { }
  //dinh nghia api

  layDSThucDon():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'/ThucDon' );
  }

  themThucDon(val:any){
    return this.http.post(this.APIurl+'/ThucDon', val);
  }
  suaThucDon(val:any){
    return this.http.put(this.APIurl+'/ThucDon', val);
  }
  xoaThucDon(val:any){
    return this.http.delete<any>(this.APIurl+'/ThucDon/'+val );
  }

  layDSMonAn():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'/MonAn' );
  }

  themMonAn(val:any){
    return this.http.post(this.APIurl+'/MonAn', val);
  }
  suaMonAn(val:any){
    return this.http.put(this.APIurl+'/MonAn', val);
  }
  xoaMonAn(val:any){
    return this.http.delete<any>(this.APIurl+'/MonAn/' + val);
  }
  taiAnh(val:any){
    return this.http.post<any>(this.APIurl+'/MonAn/SaveFile' , val);
  }
  layDSTenThucDon():Observable<any[]>{
    return this.http.get<any>(this.APIurl+'/MonAn/GetAllThucDon' );
  }
  dangNhap(val:any):Observable<any[]>{
    return this.http.post<any>(this.APIurl+'/NguoiDung', val);
  }
}
