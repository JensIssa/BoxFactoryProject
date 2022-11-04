import {Component, OnInit} from '@angular/core';
import {HttpService} from "./service/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{




  constructor(private http: HttpService) {

  }


  async ngOnInit() {
    const boxes = await this.http.getBoxes();
    console.log(boxes);
  }



}
