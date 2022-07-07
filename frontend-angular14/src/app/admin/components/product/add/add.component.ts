import { NgxSpinnerService } from 'ngx-spinner';
import { ProductService } from './../../../../services/common/product.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductAddDto } from 'src/app/models/ProductAddDto';
import { ToastrService } from 'ngx-toastr';
import { FileUploadOptions } from 'src/app/services/common/file-upload/file-upload.component';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  @Output() // veri gönderiyoruz
  myEvent: EventEmitter<any> = new EventEmitter()

  @Output()
  fileUploadOptions: Partial<FileUploadOptions> = {
    controller: 'products',
    action: 'upload',
    message: 'resimleri seçin',
    accept: 'image/*',
  }

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
    this.productService.productAdd(product).subscribe((res: any) => {
      this.spinner.hide()
      this.toastr.success(res.message, productName.value)
      this.myEvent.emit(true)
    }, err => {
      this.spinner.hide()
      console.log('err')
    })
  }

}
