import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../shared.service'; //goi api qua thu vien nay
@Component({
  selector: 'app-ds-t-don',
  templateUrl: './ds-t-don.component.html',
  styleUrl: './ds-t-don.component.css'
})
export class DsTDonComponent implements OnInit {
    constructor(private service:SharedService){

    }

    tieuDe:any;
    DSThucDon:any=[];
    tDon:any;
    dangThemSua:boolean=false;

    ngOnInit(): void {
      this.tailaiDSThucDon();
    }

    tailaiDSThucDon(){
      this.service.layDSThucDon().subscribe(data => {
        this.DSThucDon = data;
      })
    }

    chiTietThucDon(tDon:any){
      
      this.tDon = tDon;
      this.dangThemSua=true;
      this.tieuDe = "Sửa Thực Đơn";

    }
    themThucDon(){
      this.tDon={
        MaThucDon :0 ,
        TenThucDon: ""
      }
      this.dangThemSua=true;
      this.tieuDe = "Thêm Thực Đơn";
    }
    xoathucDon(tDon:any){
      if (confirm("Bạn Có Chắc  Muốn Xóa ")){
        this.service.xoaThucDon(tDon.MaThucDon).subscribe(
          data =>{
            alert(data.toString());
            this.tailaiDSThucDon();
          }
        );
      }
     

    }
    dong(){
      this.dangThemSua=false;
      this.tailaiDSThucDon();
    }
}
