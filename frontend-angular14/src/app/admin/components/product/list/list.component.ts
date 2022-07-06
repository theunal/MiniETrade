import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/common/product.service';
import { ToastrService } from 'ngx-toastr';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  displayedColumns: string[] = ['productName', 'stock', 'price', 'createdDate', 'updatedDate']
  dataSource = new MatTableDataSource<Product>()

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private productService: ProductService, private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getProducts()
  }

  async getProducts() {
    this.spinner.show()
    let products = await this.productService
      .getProducts(this.paginator?.pageIndex, this.paginator?.pageSize, () => this.spinner.hide(), (errorMessage) => {
        this.spinner.hide()
        this.toastr.error(errorMessage)
      })
    this.dataSource = new MatTableDataSource<Product>(products.result)
    this.paginator.length = products.totalCount
  }

  pageChange(event: any) {
    this.paginator.pageIndex = event.pageIndex
    this.paginator.pageSize = event.pageSize
    this.getProducts()
  }
}
