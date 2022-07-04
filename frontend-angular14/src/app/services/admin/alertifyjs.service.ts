import { Injectable } from '@angular/core';

declare var alertify: any

@Injectable({
  providedIn: 'root'
})
export class AlertifyjsService {

  constructor() { }

  message(message: string, messageType: MessageType, position: Position, delay: number = 2) {
    alertify.set('notifier', 'delay', delay)
    alertify.set('notifier', 'position', position)
    alertify[messageType](message)
  }
}


export enum MessageType {
  Error = "error",
  Message = "message",
  Notify = "notify",
  Success = "success",
  Warning = "warning"
}

export enum Position {
  TopCenter = 'top-center',
  TopRight = 'top-right',
  TopLeft = 'top-left',

  BottomCenter = 'bottom-center',
  BottomRight = 'bottom-right',
  BottomLeft = 'bottom-left',
}