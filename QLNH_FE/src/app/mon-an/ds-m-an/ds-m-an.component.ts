import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../shared.service'; //goi api qua thu vien nay

@Component({
  selector: 'app-ds-m-an',
  templateUrl: './ds-m-an.component.html',
  styleUrl: './ds-m-an.component.css'
})

  export class DsMAnComponent implements OnInit {
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
      this.service.layDSMonAn().subscribe(data => {
        this.DSThucDon = data;
      })
    }

    chiTietThucDon(tDon:any){
      
      this.tDon = tDon;
      this.dangThemSua=true;
      this.tieuDe = "Sửa Món Ăn";

    }
    themThucDon(){
      this.tDon={
        MaThucDon :0 ,
        TenThucDon: ""
      }
      this.dangThemSua=true;
      this.tieuDe = "Thêm Món Ăn";
    }
    xoathucDon(tDon:any){
      if (confirm("Bạn Có Chắc  Muốn Xóa ")){
        this.service.xoaMonAn(tDon.MaThucDon).subscribe(
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
