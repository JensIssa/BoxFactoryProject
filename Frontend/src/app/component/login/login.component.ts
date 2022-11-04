import { Component, OnInit } from '@angular/core';
import {Routes} from "@angular/router";
import {BoxesComponent} from "../boxes/boxes.component";
import {HttpService} from "../../service/http.service";
import {Router} from "@angular/router";


const routes: Routes = [{
  path: 'boxes', component: BoxesComponent
}]

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: any;
  password: any;

  constructor(private http: HttpService, private router: Router) { }

  ngOnInit(): void {
  }

  async login() {
    let dto = {
      username: this.username,
      password: this.password
    }
    var token = await this.http.login(dto);
    localStorage.setItem('token', token)
    await this.router.navigateByUrl("/boxes");
  }
}
