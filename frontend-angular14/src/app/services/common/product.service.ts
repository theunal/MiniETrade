import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
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

  async getProducts(page: number = 0, size: number = 5, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<{ products: Product[], totalCount: number }> {
    const promiseData = this.htttpClientService.get<{ products: Product[], totalCount: number }>({
      controller: 'products',
      action: 'getAll',
      queryString: `Pagination.Page=${page}&Pagination.Size=${size}`
    }).toPromise()
    promiseData
      .then(x => successCallBack())
      .catch((error: HttpErrorResponse) => errorCallBack(error.message))
    return await promiseData
  }

  async delete(id: string) {
    let deleteObservable = this.htttpClientService.delete({
      controller: 'products',
      action: 'delete'
    }, id)

   await firstValueFrom(deleteObservable)
  }

}
