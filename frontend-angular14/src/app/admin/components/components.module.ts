import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerModule } from './customer/customer.module';
import { OrderModule } from './order/order.module';
import { ProductModule } from './product/product.module';
import { DashboardModule } from './dashboard/dashboard.module';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    CustomerModule,
    DashboardModule,
    OrderModule,
    ProductModule,
  ],
  exports: [
  ]
})
export class ComponentsModule { }
