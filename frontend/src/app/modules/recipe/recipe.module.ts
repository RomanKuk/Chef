import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { RecipeHeaderComponent } from './recipe-header/recipe-header.component';
import { RecipeIngredientsComponent } from './recipe-ingredients/recipe-ingredients.component';
import { RecipeInstructionsComponent } from './recipe-instructions/recipe-instructions.component';
import { RecipeReviewsComponent } from './recipe-reviews/recipe-reviews.component';
import { RecipeRoutingModule } from './recipe-routing.module';
import { RecipeComponent } from './recipe.component';
import { CoreModule } from 'src/app/core/core.module';
import { SharedModule } from 'primeng/api';
import { PrimeComponentsModule } from 'src/app/shared/prime-components/prime-components.module';



@NgModule({
  declarations: [
    RecipeComponent,
    RecipeHeaderComponent,
    RecipeIngredientsComponent,
    RecipeInstructionsComponent,
    RecipeReviewsComponent
  ],
  imports: [
    CommonModule,
    RecipeRoutingModule,
    CoreModule,
    PrimeComponentsModule
  ]
})
export class RecipeModule { }
