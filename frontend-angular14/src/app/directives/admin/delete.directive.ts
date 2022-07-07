import { Position } from './../../services/admin/alertifyjs.service';
import { Directive, ElementRef, HostListener, Input, Output, Renderer2, EventEmitter } from '@angular/core';
import { AlertifyjsService, MessageType } from 'src/app/services/admin/alertifyjs.service';
import { HttpClientService } from 'src/app/services/common/http-client.service';

declare var $: any

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(private element: ElementRef, private renderer: Renderer2, private http: HttpClientService,
    private alertify: AlertifyjsService) {
    let button = renderer.createElement('button')
    button.setAttribute('class', 'btn btn-danger btn-sm')
    button.innerHTML = 'Sil'
    renderer.appendChild(element.nativeElement, button)
  }

  @Input()
  id: string

  @Input()
  controller: string

  @Input()
  action: string


  @Output()
  getProducts: EventEmitter<any> = new EventEmitter()

  @HostListener('click')
  onclick() {
    this.http.delete({
      controller: this.controller,
      action: this.action
    }, this.id).subscribe((res: any) => {
      this.alertify.message(res.message, MessageType.Success, Position.TopCenter)
    }, err => {
      console.log('delete error')
    })
    $(this.element.nativeElement.parentElement).fadeOut(500, () => {
      this.getProducts.emit()
    })
    console.log(this.id)
  }
}

