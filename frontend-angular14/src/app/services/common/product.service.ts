import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductAddDto } from 'src/app/models/ProductAddDto';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private htttpClientService: HttpClientService) { }

  productAdd(productAddDto: ProductAddDto) {
    return this.htttpClientService.post({
      controller: 'products',
      action: 'add'
    }, productAddDto)
  }

  async getProducts(page: number = 0, size: number = 5, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<{ result: Product[], totalCount: number }> {
    const promiseData = this.htttpClientService.get<{ result: Product[], totalCount: number }>({
      controller: 'products',
      action: 'getAll',
      queryString: `page=${page}&size=${size}`
    }).toPromise()

    promiseData
      .then(x => successCallBack())
      .catch((error: HttpErrorResponse) => errorCallBack(error.message))

    return await promiseData
  }


}
