import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import * as moment from "moment";
import { Login } from "src/app/models/login.model";
import { Window } from 'src/app/services/Window';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Injectable()
export class Auth {

    constructor(
        private http: HttpClient,
        private router: Router,
        private windowRef: Window,
        private alertify: AlertifyService) { }

    login(loginModel: Login, callback: any) {
        this.http.post('api/auth/login', loginModel)
            .subscribe(res => {
                this.setSession(res);
                this.alertify.success('Login Successful');
                this.router.navigate(['/platform/user'])
            }, error => {
                callback();
            });
    }

    createNewUser(newUserData: Login) {
        return this.http.post('api/auth/register', newUserData)
            .subscribe(res => {
                this.setSession(res);
                this.alertify.success('User was created successfully');
                this.router.navigate(['/platform/user']);
            }, err => {
                console.log("ERROR");
            });
    }

    private setSession(authResult) {
        localStorage.setItem('access_token', authResult.access_token);
        localStorage.setItem("expires", authResult.expiresIn);
        localStorage.setItem("uid", authResult.uid);
        localStorage.setItem("session_id", authResult.session_id);
    }

    logout() {
        localStorage.removeItem("access_token");
        localStorage.removeItem("expires");
    }

    public isLoggedIn() {
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
}
