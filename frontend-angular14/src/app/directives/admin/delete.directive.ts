import { Directive, ElementRef, HostListener, Input, Output, Renderer2, EventEmitter } from '@angular/core';
import { ProductService } from 'src/app/services/common/product.service';

declare var $: any

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(private element: ElementRef, private renderer: Renderer2, private productService: ProductService) {
    let button = renderer.createElement('button')
    button.setAttribute('class', 'btn btn-danger btn-sm')
    button.innerHTML = 'Sil'
    renderer.appendChild(element.nativeElement, button)
  }

  @Input()
  id: string

  @Output()
  getProducts : EventEmitter<any> = new EventEmitter()

  @HostListener('click')
  onclick() {
    this.productService.delete(this.id).then().catch()
    $(this.element.nativeElement.parentElement).fadeOut(500, () => {
      this.getProducts.emit()
    })
    console.log(this.id)
  }

}
