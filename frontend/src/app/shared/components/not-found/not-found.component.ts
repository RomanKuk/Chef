import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { AuthService } from 'src/app/core/services//auth.service';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.scss']
})
export class NotFoundComponent implements OnInit {

  link!: string;
  constructor(private location: Location, private authService: AuthService) { }

  ngOnInit(): void {
    this.link = this.location.path();
  }

  logout() {
    //this.authService.logout();
  }
}