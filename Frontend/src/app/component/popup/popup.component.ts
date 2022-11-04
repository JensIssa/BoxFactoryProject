import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {HttpService} from "../../service/http.service";

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.scss']
})
export class PopupComponent implements OnInit {

  id: number = 0;
  boxName: string = "";
  heigth: number = 0;
  length: number = 0;
  width: number = 0;
  imageUrl: string = "";
  description: string = "";

  boxList: any[] = [];


  constructor(private dialogRef: MatDialogRef<PopupComponent>,
              @Inject(MAT_DIALOG_DATA) public data : any,
              private http: HttpService) {
    this.boxList = data.boxList;

    this.id = data.item.id;
    this.boxName = data.item.boxName;
    this.heigth = data.item.heigth;
    this.length = data.item.length;
    this.width = data.item.width;
    this.imageUrl = data.item.imageUrl;
    this.description = data.item.description;
  }

  ngOnInit(): void {

  }

  async updateBox() {
    const dto = await this.createDTO();
    console.log(dto);
    const item = await this.http.updateBox(this.id, dto);
    this.dialogRef.close(item);
  }

  close() {
    this.dialogRef.close();
  }


   async createDTO() {
    let dto = {
      id: this.id,
      boxName: this.boxName,
      heigth: this.heigth,
      length: this.length,
      width: this.width,
      imageUrl: this.imageUrl,
      description: this.description
    }
    return dto;
  }
}
