import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  items: MenuItem[];
  profileItem: MenuItem[];

  ngOnInit() {
      this.items = [
        {
          label:'Home',
          routerLink: ['/portal/home']
        },
        // {
        //   label:'Saved',
        //   routerLink: ['/portal/saved']
        // },
        {
          label:'Product list',
          routerLink: ['/portal/product-list']
        }
    ];
    this.profileItem =[
      {
      label: "<img src='assets/Avatar-default.png' alt='Avatar' class='avatar' />",
      escape: false,
      items: [
        {
          label: "Settings"
        },
        {
          label: "Logout",
          routerLink: ['/']
        }
      ]
    }
  ];
}
}
