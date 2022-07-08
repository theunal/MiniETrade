import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/common/auth.service';
import { UserService } from 'src/app/services/common/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup

  constructor(private userService: UserService, private toastr: ToastrService, private spinner: NgxSpinnerService,
    private activatedRoute: ActivatedRoute, private router: Router, private socialAuthService: SocialAuthService,
    private authService: AuthService) {

    if (this.authService.isAuthenticated() === false) {
      this.socialAuthService.authState.subscribe(res => {
        this.spinner.show()
        this.userService.googleLogin(res).subscribe((res: any) => {
          this.spinner.hide()
          this.toastr.success('Giriş Başarılı')
          localStorage.setItem('token', res.token.token)
          this.activatedRoute.queryParams.subscribe(res => {
            res['returnUrl'] ? this.router.navigate([res['returnUrl']]) : ''
          })
        })
      }, err => {
        this.spinner.hide()
        console.log('google login err')
      })
    }
    
  }

  ngOnInit(): void {
    this.createLoginForm()
  }

  createLoginForm() {
    this.loginForm = new FormGroup({
      userNameOrEmail: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    })
  }

  login() {
    this.spinner.show()
    if (this.loginForm.valid) {
      this.userService.login(this.loginForm.value).subscribe(res => {
        this.spinner.hide()
        this.toastr.success(res.message)
        localStorage.setItem('token', res.accessToken.token)
        this.activatedRoute.queryParams.subscribe(res => {
          res['returnUrl'] ? this.router.navigate([res['returnUrl']]) : ''
        })
      }, err => {
        this.spinner.hide()
        this.toastr.error(err.error)
      })
    } else {
      this.spinner.hide()
      this.toastr.warning('Lütfen giriş bilgilerinizi giriniz.')
    }
  }
}
