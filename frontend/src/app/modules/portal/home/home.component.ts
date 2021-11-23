import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { Subject, takeUntil } from 'rxjs';
import { IngredientService } from 'src/app/core/services/ingredient.service';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { BaseComponent } from 'src/app/shared/components/base/base.component';
import { CookingTimeOptions, IngredientsCountOptions } from 'src/app/shared/models/filter-options';
import { Filters } from 'src/app/shared/models/filters';
import { Ingredient } from 'src/app/shared/models/ingredient/ingredient';
import { Recipe } from 'src/app/shared/models/recipe/recipe';
import { SortingOptions } from 'src/app/shared/models/sorting-options';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent implements OnInit {

  recipes: Recipe[];
  products: Ingredient[];
  sortingOptions: SelectItem[] = 
    Object.keys(SortingOptions).map(key => ({ label: SortingOptions[key], value: key }));
  selectedOption;
  displayFilters: boolean = false;

  selectedCookingTime: SelectItem[] = [];
  cookingTimeOptions: SelectItem[] = 
    Object.keys(CookingTimeOptions).map(key => ({ label: CookingTimeOptions[key], value: key }));
  selectedIngredientsCount: SelectItem[] = [];
  ingredientsCountOptions: SelectItem[] = 
    Object.keys(IngredientsCountOptions).map(key => ({ label: IngredientsCountOptions[key], value: key }));

  selectedProducts: Ingredient[] = [];

  constructor(private recipeService: RecipeService,
    private ingredientService: IngredientService) {
    super();
   }

  ngOnInit(): void {
    this.recipeService.getRecipes()
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(res => {
      this.recipes = res;
      // for (let i = 0; i < 7; i++){
      //   this.recipes.push(this.recipes[0]);
      // }
    });
  }

  showDialog() {
    this.ingredientService.getIngredients()
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(res => {
      this.products = res;
      this.displayFilters = true;
    });
  }

  onSubmit() {
    const filters: Filters = {
      sortingBy: this.selectedOption,
      cookingTimeOptions: this.selectedCookingTime.map(i => i.value),
      ingredientsCountOptions: this.selectedIngredientsCount.map(i => i.value),
      productsIds: this.selectedProducts.map(i => i.id)
    };

    this.recipeService.getRecipesByFilters(filters)
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(res => {
      this.displayFilters = false;
      this.recipes = res;
    });
  }

}
