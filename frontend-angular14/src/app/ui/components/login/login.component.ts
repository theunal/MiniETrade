import { GoogleLoginProvider, SocialAuthService, FacebookLoginProvider } from '@abacritt/angularx-social-login';
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

  isAuth: boolean = false

  googleLoginButtonPressed: boolean = false

  constructor(private userService: UserService, private toastr: ToastrService, private spinner: NgxSpinnerService,
    private activatedRoute: ActivatedRoute, private router: Router, private socialAuthService: SocialAuthService,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.createLoginForm()
    if (this.authService.isAuth === false) {
      this.socialAuthService.authState.subscribe(res => {
        this.spinner.show()
        this.userService.googleLogin(res).subscribe((res: any) => {
          this.spinner.hide()
          this.toastr.success('Giriş Başarılı')
          localStorage.setItem('token', res.token.token)
          this.activatedRoute.queryParams.subscribe(res => {
            res['returnUrl'] ? this.router.navigate([res['returnUrl']]) : ''
          })
          console.log(this.authService.isAuthenticated())
        })
      }, err => {
        this.spinner.hide()
        console.log('google login err')
      })
    }
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

  async fbLogin() {
    await this.socialAuthService.signIn(FacebookLoginProvider.PROVIDER_ID)
    this.spinner.show()
    this.socialAuthService.authState.subscribe(res => {
      this.userService.fbLogin(res).subscribe(res => {
        this.spinner.hide()
        this.toastr.success('Giriş Başarılı')
        localStorage.setItem('token', res.token.token)
        this.authService.isAuthenticated()
        this.activatedRoute.queryParams.subscribe(res => {
          res['returnUrl'] ? this.router.navigate([res['returnUrl']]) : ''
        })
      }, err => {
        this.spinner.hide()
      })
    })
  }

  googleLoginButton() {
    this.googleLoginButtonPressed = true
    console.log(this.googleLoginButtonPressed)
  }
}
