import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Filters } from 'src/app/shared/models/filters';
import { Recipe } from 'src/app/shared/models/recipe/recipe';
import { CoreHttpService } from './core-http.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private apiPrefix = '/recipes';

  constructor(
      private httpService: CoreHttpService
  ) { }

  getRecipes(): Observable<Recipe[]> {
    return this.httpService.getRequest<Recipe[]>(`${this.apiPrefix}`);
  }

  
  getRecipeById(id: number): Observable<Recipe> {
    return this.httpService.getRequest<Recipe>(`${this.apiPrefix}/${id}`);
  }

  getRecipesByFilters(filters: Filters): Observable<Recipe[]> {
    return this.httpService.postRequest<Recipe[]>(`${this.apiPrefix}/get-filtered-recipes`, filters);
  }
}
