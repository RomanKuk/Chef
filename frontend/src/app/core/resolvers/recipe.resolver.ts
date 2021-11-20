import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { catchError, EMPTY, Observable, of, tap } from 'rxjs';
import { Recipe } from 'src/app/shared/models/recipe/recipe';
import { RecipeService } from '../services/recipe.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeResolverService implements Resolve<Recipe> {
  constructor(private router: Router, private recipeService: RecipeService) {}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const recipeId = Number(route.paramMap.get('recipeId'));
    return this.recipeService.getRecipeById(recipeId).pipe(
      tap((proj) => {
        return proj ?? EMPTY;
      }),
      catchError(() => {
        this.router.navigateByUrl('/portal/**', { skipLocationChange: true });
        return EMPTY;
      })
    );
  }
}
