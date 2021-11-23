import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductList } from 'src/app/shared/models/product-list/product-list';
import { CoreHttpService } from './core-http.service';

@Injectable({
  providedIn: 'root'
})
export class ProductListService {

  private apiPrefix = '/productLists';

  constructor(
      private httpService: CoreHttpService
  ) { }
  
  getProductListByUserId(userId: number): Observable<ProductList> {
    return this.httpService.getRequest<ProductList>(`${this.apiPrefix}/${userId}`);
  }
}
