import { Component, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { Recipe } from 'src/app/shared/models/recipe/recipe';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  unsubscribe$ = new Subject<void>();
  recipes: Recipe[];

  constructor(private recipesService: RecipeService) { }

  ngOnInit(): void {
    this.recipesService.getRecipes()
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(res => {
      this.recipes = res;
      for (let i = 0; i < 7; i++){
        this.recipes.push(this.recipes[0]);
      }
    });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

}
