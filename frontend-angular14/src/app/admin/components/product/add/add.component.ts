import { NgxSpinnerService } from 'ngx-spinner';
import { ProductService } from './../../../../services/common/product.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductAddDto } from 'src/app/models/ProductAddDto';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  @Output() // veri gönderiyoruz
  myEvent: EventEmitter<any> = new EventEmitter()

  constructor(private productService: ProductService, private spinner: NgxSpinnerService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  productAdd(productName: HTMLInputElement, stock: HTMLInputElement, price: HTMLInputElement) {
    this.spinner.show()
    let product: ProductAddDto = {
      productName: productName.value,
      stock: parseInt(stock.value),
      price: parseInt(price.value)
    }
    this.productService.productAdd(product).subscribe(res => {
      this.spinner.hide()
      this.toastr.success(productName.value, 'ürün eklendi')
    }, err => {
      this.spinner.hide()
      if (err.statusCode = '200') {
        this.toastr.success(productName.value, 'ürün eklendi 2')
        this.myEvent.emit(true)
      }
      else
        this.toastr.error(err.error)
    })
  }

}
