import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipeResolverService } from 'src/app/core/resolvers/recipe.resolver';
import { RecipeComponent } from './recipe.component';

const routes: Routes = [
  {
    path: ':recipeId',
    component: RecipeComponent,
    resolve: {
      project: RecipeResolverService
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipeRoutingModule { }
