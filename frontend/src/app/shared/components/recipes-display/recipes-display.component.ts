import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../models/recipe/recipe';

@Component({
  selector: 'app-recipes-display',
  templateUrl: './recipes-display.component.html',
  styleUrls: ['./recipes-display.component.scss']
})
export class RecipesDisplayComponent implements OnInit {

  @Input() recipes: Recipe[];


  constructor() { }

  ngOnInit(): void {
  }

}
