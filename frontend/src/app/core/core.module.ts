import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { environment } from 'src/environments/environment';
import { HomeGuard } from './guards/home.guard';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    HomeGuard
  ]
})
export class CoreModule { }
