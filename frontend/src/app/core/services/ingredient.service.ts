import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ingredient } from 'src/app/shared/models/ingredient/ingredient';
import { Recipe } from 'src/app/shared/models/recipe/recipe';
import { CoreHttpService } from './core-http.service';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  private apiPrefix = '/ingredients';

  constructor(
      private httpService: CoreHttpService
  ) { }

  getIngredients(): Observable<Ingredient[]> {
    return this.httpService.getRequest<Ingredient[]>(`${this.apiPrefix}`);
  }
}
