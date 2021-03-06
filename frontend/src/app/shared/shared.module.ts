import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PrimeComponentsModule } from './prime-components/prime-components.module';
import { DefaultLogoPipe } from './pipes/default-logo.pipe';
import { RecipesDisplayComponent } from './components/recipes-display/recipes-display.component';
import { RecipeCardComponent } from './components/recipe-card/recipe-card.component';
import { BaseComponent } from './components/base/base.component';

@NgModule({
  declarations: [
    LoadingSpinnerComponent,
    NotFoundComponent,
    DefaultLogoPipe,
    RecipesDisplayComponent,
    RecipeCardComponent,
    BaseComponent
  ],
  imports: [
    CommonModule,
    PrimeComponentsModule
  ],
  exports: [
    DefaultLogoPipe,
    RecipesDisplayComponent,
    RecipeCardComponent,
    PrimeComponentsModule
  ]
})
export class SharedModule { }
