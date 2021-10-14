import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Login } from 'src/app/models/login.model';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Auth } from 'src/app/services/Auth';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private auth: Auth,
    private ngZone: NgZone,
    private alertify: AlertifyService) {
  }

  isLoading: boolean = false;
  emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;

  registrationForm = this.fb.group({
    email:['', Validators.required],
    password:['', Validators.required]
  });

  ngOnInit(): void {
    window['angularComponentReference'] =
    {
        component: this,
        zone: this.ngZone,
    };
  }

  createNewUser() {
    const userData: Login = this.registrationForm.value;
    debugger
    let errorFlag = false;
    if (!userData.email || !userData.email.match(this.emailPattern)) {
      this.alertify.error('Email is invalid');
      errorFlag = true;
    }

    if (!userData.password) {
      this.alertify.error('Password is invalid');
      errorFlag = true;
    }

    if (userData.password.length < 8 && userData.password) {
      this.alertify.error('Password less than 8 chracters');
      errorFlag = true;
    }
    
    if (!errorFlag) {
      this.isLoading = true;
      this.auth.createNewUser(userData); 
    }
  }
}
