import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(@Inject('baseUrl') private baseUrl: string, private httpClient: HttpClient) { }

  private url(requestParameter: Partial<RequestParameter>): string {
    var url = `${requestParameter.baseUrl ? requestParameter.baseUrl : this.baseUrl}/${requestParameter.controller}${requestParameter.action ? `/${requestParameter.action}` : ''}`
    console.log(url)
    return url
  }

  get<T>(requestParameter: Partial<RequestParameter>, id?: string): Observable<T> {
    let url = requestParameter.fullEndPoint ? requestParameter.fullEndPoint : `${this.url(requestParameter)}${id ? `/${id}` : ''}`
    return this.httpClient.get<T>(url, { headers: requestParameter.headers })
  }

  post<T>(requestParameter: Partial<RequestParameter>, body: Partial<T>): Observable<string> {
    let url = requestParameter.fullEndPoint ? requestParameter.fullEndPoint : this.url(requestParameter)
    return this.httpClient.post<string>(url, body, { headers: requestParameter.headers })
  }

  put() {

  }

  delete() {

  }
}


export interface RequestParameter {
  controller?: string
  action?: string
  headers?: HttpHeaders
  baseUrl?: string
  fullEndPoint?: string
}