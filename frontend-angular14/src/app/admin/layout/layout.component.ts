import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Product } from 'src/app/models/product';
import { ProductUdpateDto } from 'src/app/models/productUpdateDto';
import { HttpClientService } from 'src/app/services/common/http-client.service';

declare var $: any

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService, private httpClientService: HttpClientService) { }

  ngOnInit(): void {
  }


  getAll() {
    this.spinner.show()
    this.httpClientService.get<Product>({
      controller: 'products',
      action: 'getall'
    }).subscribe(res => {
      this.spinner.hide()
      console.log(res)
    }, err => {
      this.spinner.hide()
      console.log(err)
    })
  }

  getById() {
    this.spinner.show()
    this.httpClientService.get<Product>({
      controller: 'products',
      action: 'getById'
    },'19b80305-2e6b-465f-2ee6-08da5dd6d864').subscribe(res => {
      this.spinner.hide()
      console.log(res)
    }, err => {
      this.spinner.hide()
      console.log(err)
    })
  }

  add() {
    this.spinner.show()
    this.httpClientService.post(
      {
        controller: 'products',
        action: 'add'
      },
      {
        productName: 'asus tuf a15',
        stock: 15,
        price: 14999
      }
    ).subscribe(res => {
      this.spinner.hide()
      console.log(res)
    }, err => {
      this.spinner.hide()
      console.log(err)
    })
  }

  update() {
    this.spinner.show()
    this.httpClientService.put(
      {
        controller: 'products',
        action: 'update'
      },
      {
        id: 'e06c61b0-0718-4124-0667-08da5d38235b',
        productName: 'laptop 5 ',
        stock: 100,
        price: 102
      }
    ).subscribe(res => {
      this.spinner.hide()
      console.log(res)
    }, err => {
      this.spinner.hide()
      console.log(err)
    })
  }

  delete() {
    this.spinner.show()
    this.httpClientService.delete(
      {
        controller: 'products',
        action: 'delete'
      }, 
      '18420f54-22b4-433d-4a43-08da5e9d77e8'
    ).subscribe((res : any) => {
      this.spinner.hide()
      console.log(res.message)
    }, err => {
      this.spinner.hide()
      console.log(err)
    })
  }
}