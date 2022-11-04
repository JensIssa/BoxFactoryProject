import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BoxesComponent} from "./component/boxes/boxes.component";
import {CreationsComponent} from "./component/creations/creations.component";
import {LoginComponent} from "./component/login/login.component";


const routes: Routes = [
  {path: 'boxes', component: BoxesComponent},
  {path: 'creations', component: CreationsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [BoxesComponent, CreationsComponent]
