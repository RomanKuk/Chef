import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { Recipe } from 'src/app/shared/models/recipe/recipe';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent implements OnInit {

  recipe: Recipe = {} as Recipe;
  unsubscribe$ = new Subject<void>();

  constructor(private recipeService: RecipeService,
    private route: ActivatedRoute) {
      this.route.data.pipe(takeUntil(this.unsubscribe$)).subscribe(({ project }) =>
      {
        this.recipe = project;
      });
     }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

}

