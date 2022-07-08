import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path: 'admin', component: LayoutComponent, canActivate: [AuthGuard], children: [
      { path: '', component: DashboardComponent },
      { path: 'customer', canActivate: [AuthGuard], loadChildren: () => import('./admin/components/customer/customer.module').then(module => module.CustomerModule) },
      { path: 'order', canActivate: [AuthGuard], loadChildren: () => import('./admin/components/order/order.module').then(module => module.OrderModule) },
      { path: 'product', canActivate: [AuthGuard], loadChildren: () => import('./admin/components/product/product.module').then(module => module.ProductModule) },
    ]
  },
  { path: '', component: HomeComponent },
  { path: 'basket', loadChildren: () => import('./ui/components/basket/basket.module').then(module => module.BasketModule) },
  { path: 'product', loadChildren: () => import('./ui/components/product/product.module').then(module => module.ProductModule) },
  { path: 'register', loadChildren: () => import('./ui/components/register/register.module').then(module => module.RegisterModule) },
  { path: 'login', loadChildren: () => import('./ui/components/login/login.module').then(module => module.LoginModule) }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
