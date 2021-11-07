import { Component, OnInit } from '@angular/core';
import { PhotoService } from 'src/app/core/services/photo.service';

@Component({
  selector: 'app-landing-content',
  templateUrl: './landing-content.component.html',
  styleUrls: ['./landing-content.component.scss']
})
export class LandingContentComponent implements OnInit {

  images!: any[];

  responsiveOptions:any[] = [
      {
          breakpoint: '1024px',
          numVisible: 5
      },
      {
          breakpoint: '768px',
          numVisible: 3
      },
      {
          breakpoint: '560px',
          numVisible: 1
      }
  ];

  constructor(private photoService: PhotoService) { }

  ngOnInit() {
      this.photoService.getImages().then(images => this.images = images)
  }

}
