import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LandingContentComponent } from './landing-content/landing-content.component';
import {LandingPageComponent} from './landing-page.component';

const routes = [
  {
    path: '',
    component: LandingPageComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [],
})
export class LandingPageRoutingModule {}