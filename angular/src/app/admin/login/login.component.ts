import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {first} from "rxjs/operators";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public formGroup: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.formGroup = this.initFormGroup();
  }

  public login(): void {
  // this.authService.login(this.formGroup.get('username').value,this.formGroup.get('password').value).pipe(first())
  //     .subscribe(
  //       data => {
  //         this.router.navigate(['/f19-a-team/admin/pickup-map']);
  //       }, error => {
  //         console.error(error);
  //       });
    this.router.navigate(['/f19-a-team/admin/pickup-map']);
  }

  private initFormGroup(): FormGroup {
    return this.fb.group({
      username: null,
      password: null
    })
  }

}
