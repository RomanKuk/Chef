import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs';
import { BaseComponent } from 'src/app/shared/components/base/base.component';
import { Recipe } from 'src/app/shared/models/recipe/recipe';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent extends BaseComponent implements OnInit {

  recipe: Recipe = {} as Recipe;

  constructor(private route: ActivatedRoute) {
      super();
      this.route.data.pipe(takeUntil(this.unsubscribe$)).subscribe(({ project }) =>
      {
        this.recipe = project;
      });
     }

  ngOnInit(): void {
  }
}

