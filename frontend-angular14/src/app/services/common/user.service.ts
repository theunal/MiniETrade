import { Observable } from 'rxjs';
import { UserAddDto } from './../../models/user/userAddDto';
import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { UserAddResponse } from 'src/app/models/user/userAddResponse';
import { UserLoginDto } from 'src/app/models/user/userLoginDto';
import { UserLoginResponse } from 'src/app/models/user/userLoginResponse';
import { GoogleLoginRequest } from 'src/app/models/user/googleLoginRequest';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClientService) { }

  userAdd(user: UserAddDto): Observable<UserAddResponse> {
    return this.http.post<UserAddDto>({
      controller: 'users',
      action: 'add'
    }, user)
  }

  login(dto: UserLoginDto): Observable<UserLoginResponse> {
    return this.http.post<UserLoginDto>({
      controller: 'users',
      action: 'login'
    }, dto)
  }

  googleLogin(login: GoogleLoginRequest): Observable<{ token: string }> {
    return this.http.post<GoogleLoginRequest>({
      controller: 'users',
      action: 'googleLogin'
    }, login)
  }
}
