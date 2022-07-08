import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserAddDto } from 'src/app/models/user/userAddDto';
import { UserService } from 'src/app/services/common/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup
  passwordCheck: boolean = false

  constructor(private toastr: ToastrService, private userService: UserService) { }

  ngOnInit(): void {
    this.createRegisterForm()
  }

  createRegisterForm() {
    this.registerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(3)]),
      userName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(3)]),
      passwordAgain: new FormControl('', [Validators.required, Validators.minLength(3)]),
    })
  }

  register() {
    this.passwordCheck = this.registerForm.value.password === this.registerForm.value.passwordAgain ? true : false

    if (!this.passwordCheck) {
      this.toastr.warning('Parolalar Eşleşmiyor.')
      return
    }

    if (this.registerForm.valid) {
      let user: UserAddDto = {
        name: this.registerForm.value.name,
        userName: this.registerForm.value.userName,
        email: this.registerForm.value.email,
        password: this.registerForm.value.password,
      }

      console.log(user)
      this.userService.userAdd(user).subscribe(res => {
        this.toastr.success(res.message)
      }, err => {
        this.toastr.error(err.error)
      })

    } else {
      this.toastr.warning('Lütfen gerekli alanları doldurunu<.')
    }
  }

}
