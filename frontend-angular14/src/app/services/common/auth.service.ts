import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isAuth: boolean = false

  constructor(private jwtHelperService: JwtHelperService, private router: Router, private toastr: ToastrService) { }

  isAuthenticated() {
    let token = localStorage.getItem('token')
    let expired = this.jwtHelperService.isTokenExpired(token)

    token && !expired ? this.isAuth = true : this.isAuth = false
    return this.isAuth
  }

  logout() {
    localStorage.removeItem('token')
    this.isAuth = false
    // this.router.navigate(['/login']) logine giderse otomatik giriş yapıyor
    this.toastr.info('çıkış yaptınız')
  }

}
