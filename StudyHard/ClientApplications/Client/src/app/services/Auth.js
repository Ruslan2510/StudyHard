var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import * as moment from "moment";
import { Window } from 'src/app/services/Window';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
let Auth = class Auth {
    constructor(http, router, windowRef, alertify) {
        this.http = http;
        this.router = router;
        this.windowRef = windowRef;
        this.alertify = alertify;
    }
    login(loginModel, callback) {
        this.http.post('api/auth/login', loginModel)
            .subscribe(res => {
            this.setSession(res);
            this.alertify.success('Login Successful');
            this.router.navigate(['/platform/user']);
        }, error => {
            callback();
        });
    }
    createNewUser(newUserData) {
        return this.http.post('api/auth/register', newUserData)
            .subscribe(res => {
            this.setSession(res);
            this.alertify.success('User was created successfully');
            this.router.navigate(['/platform/user']);
        }, err => {
            console.log("ERROR");
        });
    }
    setSession(authResult) {
        localStorage.setItem('access_token', authResult.access_token);
        localStorage.setItem("expires", authResult.expiresIn);
        localStorage.setItem("uid", authResult.uid);
        localStorage.setItem("session_id", authResult.session_id);
    }
    logout() {
        localStorage.removeItem("access_token");
        localStorage.removeItem("expires");
    }
    isLoggedIn() {
        return moment().isBefore(this.getExpiration());
    }
    isLoggedOut() {
        return !this.isLoggedIn();
    }
    getExpiration() {
        const expiration = localStorage.getItem("expires");
        console.log(expiration);
        console.log(moment(expiration));
        return moment(expiration);
    }
    isTokenExist() {
        const expiration = localStorage.getItem("access_token");
        if (expiration && expiration.length > 0) {
            return true;
        }
        return false;
    }
};
Auth = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [HttpClient,
        Router,
        Window,
        AlertifyService])
], Auth);
export { Auth };
//# sourceMappingURL=Auth.js.map