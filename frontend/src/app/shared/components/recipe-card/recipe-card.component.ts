import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../models/recipe/recipe';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss']
})
export class RecipeCardComponent implements OnInit {

  @Input() recipe: Recipe;
  time: string;  

  constructor() { }

  ngOnInit(): void {
    console.log(this.recipe);
    //this.time = this.timeConvertion(); 
  }

  timeConvertion(): string {
    const recipeTime = this.recipe.summaryTime;
    let result = "";
    if (recipeTime.hours > 1)
    {
      result += `${recipeTime.hours}h `;
    }

    result += `${recipeTime.minutes}m`;

    return result;
  }

}
