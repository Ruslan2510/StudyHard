var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ElementRef, ViewChild } from '@angular/core';
import { Auth } from 'src/app/services/Auth';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Window } from 'src/app/services/Window';
import { NgZone } from '@angular/core';
import { Router } from '@angular/router';
let LoginPageComponent = class LoginPageComponent {
    constructor(fb, router, auth, windowRef, ngZone) {
        this.fb = fb;
        this.router = router;
        this.auth = auth;
        this.windowRef = windowRef;
        this.ngZone = ngZone;
        //TODO move to environments
        this.idDevelopment = false;
        this.loginForm = this.fb.group({
            email: ['', Validators.required],
            password: ['', Validators.required]
        });
        this.isLoading = false;
    }
    login() {
        const loginData = this.loginForm.value;
        this.isLoading = true;
        this.auth.login(loginData, this.hideLoader.bind(this));
    }
    hideLoader() {
        this.isLoading = false;
    }
    convertToScript() {
        const element = this.script.nativeElement;
        const script = document.createElement('script');
        script.src = 'https://telegram.org/js/telegram-widget.js?5';
        var url = this.windowRef.current.location.href;
        if (url.includes("devpravoplatform")) {
            script.setAttribute('data-telegram-login', "PravoDevBot");
        }
        else {
            script.setAttribute('data-telegram-login', "pravozno_bot");
        }
        script.setAttribute('data-size', 'large');
        // Callback function in global scope
        script.setAttribute('data-onauth', 'loginWithTelegram(user)');
        script.setAttribute('data-request-access', 'write');
        element.parentElement.replaceChild(script, element);
    }
    ngOnInit() {
        window['angularComponentReference'] =
            {
                component: this,
                zone: this.ngZone,
                navigateAfterLogin: () => this.navigateAfterLogin(),
            };
        var url = this.windowRef.current.location.href;
        this.idDevelopment = url.includes("localhost");
        //if (this.auth.isTokenExist()) {
        //    this.windowRef.current.location.href = '/platform/user';
        //}
    }
    ngAfterViewInit() {
        this.convertToScript();
    }
    navigateAfterLogin() {
        this.router.navigate(['/platform/user']);
    }
};
__decorate([
    ViewChild('script', { static: true }),
    __metadata("design:type", ElementRef)
], LoginPageComponent.prototype, "script", void 0);
LoginPageComponent = __decorate([
    Component({
        selector: 'login',
        templateUrl: './login-page.component.html',
        styleUrls: ['./login.component.css']
    }),
    __metadata("design:paramtypes", [FormBuilder,
        Router,
        Auth,
        Window,
        NgZone])
], LoginPageComponent);
export { LoginPageComponent };
//# sourceMappingURL=login-page.component.js.map