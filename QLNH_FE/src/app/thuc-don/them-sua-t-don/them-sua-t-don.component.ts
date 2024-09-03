import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from '../../shared.service';
@Component({
  selector: 'app-them-sua-t-don',
  templateUrl: './them-sua-t-don.component.html',
  styleUrl: './them-sua-t-don.component.css'
})
export class ThemSuaTDonComponent implements OnInit {

    maThucDon:any;
    tenThucDon:any;
    @Input() tDon:any;
    constructor(private service:SharedService){}

   ngOnInit(): void {
    this.maThucDon = this.tDon.MaThucDon;
    this.tenThucDon = this.tDon.TenThucDon;

  }
  
  themThucDon(){
    var val = {
      tenThucDon :this.tenThucDon
    };
    this.service.themThucDon(val).subscribe(res => {
        alert(res.toString());
    });
  }
  suaThucDon(){
    var val = {
      maThucDon:this.maThucDon,
      tenThucDon :this.tenThucDon
    };
    this.service.suaThucDon(val).subscribe(res => {
        alert(res.toString());
    });
  }
 
}
