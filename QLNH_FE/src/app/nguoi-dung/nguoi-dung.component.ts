import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-nguoi-dung',
  templateUrl: './nguoi-dung.component.html',
  styleUrls: ['./nguoi-dung.component.css']
})
export class NguoiDungComponent implements OnInit {

  tenDangNhap: any;
  matKhau:any;

  constructor(private service:SharedService) { }

  table:any=[];
  nDung:any={
    tenDangNhap:"admin",
    matKhau:"admin",
    hoVaTen:""
  };

  ngOnInit(): void {
    //this.dangNhap();
  }

  dangNhap(){
    this.nDung.tenDangNhap = this.tenDangNhap;
    this.nDung.matKhau = this.matKhau;
    this.service.dangNhap(this.nDung).subscribe(data => {
      this.table = data;
    })
    if (this.table[0].Column1 == 1) {
      window.location.href = "http://localhost:4200/monAn";
    } else {
      alert("Đăng nhập thất bại!");
    }
  }

}