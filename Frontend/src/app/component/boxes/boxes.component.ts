import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../service/http.service";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {PopupComponent} from "../popup/popup.component";


@Component({
  selector: 'app-boxes',
  templateUrl: './boxes.component.html',
  styleUrls: ['./boxes.component.scss']
})
export class BoxesComponent implements OnInit {

  boxList : any[] = []

  boxName: string = "";
  heigth: number = 0;
  length: number = 0;
  width: number = 0;
  imageUrl: string = "";
  description: string = "";

  constructor(private http : HttpService, private dialog: MatDialog) { }

  async ngOnInit(){
    this.boxList = await this.http.getBoxes();

  }


  openDialog(item: any) {
    let dialogRef = this.dialog.open(PopupComponent, {
      data: {
        boxes: this.boxList,
        item: item

      }
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log("Dialog closed");
      if (result != null) {
        this.boxList[this.boxList.findIndex(item => item.id == result.id)] = result;
      }
    });
  }



  async deleteBox(id: any) {
    const box = await this.http.deleteBox(id);
    this.boxList = this.boxList.filter(item => item.id != box.id)
    await this.ngOnInit();
  }
}
