import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Product } from 'src/app/models/product';
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
    this.add()
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

  // public string ProductName { get; set; }
  // public int Stock { get; set; }
  // public long Price { get; set; }


}