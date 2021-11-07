import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PrimeComponentsModule } from './prime-components/prime-components.module';

@NgModule({
  declarations: [
    LoadingSpinnerComponent,
    NotFoundComponent
  ],
  imports: [
    CommonModule,
    PrimeComponentsModule
  ]
})
export class SharedModule { }
