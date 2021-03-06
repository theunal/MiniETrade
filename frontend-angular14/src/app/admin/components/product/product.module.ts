import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './add/add.component';
import { MatInputModule } from '@angular/material/input';
import { ListComponent } from './list/list.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { DeleteDirective } from 'src/app/directives/admin/delete.directive';
import {MatDialogModule} from '@angular/material/dialog';
import { FileUploadModule } from 'src/app/services/common/file-upload/file-upload.module';

const routes: Routes = [
  { path: '', component: ProductComponent }
]

@NgModule({
  declarations: [
    ProductComponent,
    AddComponent,
    ListComponent,
    DeleteDirective
  ],
  imports: [
    CommonModule,
    MatInputModule,
    NgxSpinnerModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    FileUploadModule,
    RouterModule.forChild(routes)
  ]
})
export class ProductModule { }
