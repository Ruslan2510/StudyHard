var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, NgZone } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Auth } from 'src/app/services/Auth';
let RegistrationComponent = class RegistrationComponent {
    constructor(fb, auth, ngZone, alertify) {
        this.fb = fb;
        this.auth = auth;
        this.ngZone = ngZone;
        this.alertify = alertify;
        this.isLoading = false;
        this.emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
        this.registrationForm = this.fb.group({
            email: ['', Validators.required],
            password: ['', Validators.required]
        });
    }
    ngOnInit() {
        window['angularComponentReference'] =
            {
                component: this,
                zone: this.ngZone,
            };
    }
    createNewUser() {
        const userData = this.registrationForm.value;
        debugger;
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
};
RegistrationComponent = __decorate([
    Component({
        selector: 'registration',
        templateUrl: './registration.component.html',
        styleUrls: ['./registration.component.css']
    }),
    __metadata("design:paramtypes", [FormBuilder,
        Auth,
        NgZone,
        AlertifyService])
], RegistrationComponent);
export { RegistrationComponent };
//# sourceMappingURL=registration.component.js.map