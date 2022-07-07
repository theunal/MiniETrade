import { HttpHeaders } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { HttpClientService } from '../http-client.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {

  constructor(private http: HttpClientService) { }

  @Input()
  options: Partial<FileUploadOptions>

  public files: NgxFileDropEntry[] = []

  public selectedFiles(files: NgxFileDropEntry[]) {

    this.files = files

    let fileData: FormData = new FormData()
    for (let file of files) {
      (file.fileEntry as FileSystemFileEntry).file((_file: File) => {
        fileData.append(_file.name, _file, file.relativePath)
      })
    }

    this.http.post( 
      {
        controller: this.options.controller,
        action: this.options.action,
        queryString: this.options.queryString,
        headers: new HttpHeaders({ 'responseType': 'blob' })
      }, fileData).subscribe(res => {
        console.log('res')
      }, err => {
        console.log('err')
      })
  }

}

export interface FileUploadOptions {
  controller?: string
  action?: string
  queryString?: string
  message?: string
  accept?: string
}