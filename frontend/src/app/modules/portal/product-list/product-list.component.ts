import { Component, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs';
import { ProductListService } from 'src/app/core/services/product-list.service';
import { BaseComponent } from 'src/app/shared/components/base/base.component';
import { ComponentIngredient } from 'src/app/shared/models/component-ingredient/component-ingredient';
import { ProductList } from 'src/app/shared/models/product-list/product-list';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent extends BaseComponent implements OnInit {

  productList: ProductList = {} as ProductList;
  ingredientGroups = {};

  constructor(private productListService: ProductListService) {
    super();
   }

  ngOnInit(): void {
    this.productListService.getProductListByUserId(2)
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(res => {
      this.productList = res;
      console.log(this.productList);
      this.ingredientGroups = this.groupByCategory(this.productList.ingredients);
      console.log(this.ingredientGroups);
    });
  }

  groupByCategory(array: ComponentIngredient[]) {
    return array.reduce((r, a) => {
          r[a.ingredient.category.name] = r[a.ingredient.category.name] || [];
          r[a.ingredient.category.name].push(a);
          return r;
      }, Object.create(null));
  }
}
