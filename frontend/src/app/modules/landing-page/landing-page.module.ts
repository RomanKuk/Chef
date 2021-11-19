import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingPageComponent } from './landing-page.component';
import { LandingContentComponent } from './landing-content/landing-content.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { LandingPageRoutingModule } from './landing-page-routing.module';
import { LandingHeaderComponent } from './landing-header/landing-header.component';
import { ButtonModule } from 'primeng/button';
import { GalleriaModule } from 'primeng/galleria';
import { PhotoService } from 'src/app/core/services/photo.service';
import { HttpClientModule } from '@angular/common/http';
import { SignInComponent } from '../sign-in/sign-in.component';

@NgModule({
  declarations: [
    LandingPageComponent,
    LandingContentComponent,
    LandingHeaderComponent,
    SignInComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    LandingPageRoutingModule,
    ButtonModule,
    GalleriaModule,
    HttpClientModule
  ],
  providers: [PhotoService]
})
export class LandingPageModule { }
