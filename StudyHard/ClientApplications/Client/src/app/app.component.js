var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Window } from '../../src/app/services/Window';
import { Auth } from '../../src/app/services/Auth';
import { SignalRService } from './services/SignalRServicets';
import { HttpClient } from '@angular/common/http';
let AppComponent = class AppComponent {
    constructor(router, windowRef, http, auth, signalR) {
        this.router = router;
        this.windowRef = windowRef;
        this.http = http;
        this.auth = auth;
        this.signalR = signalR;
        this.router.events.subscribe(event => {
            this.windowRef.current.Site.getInstance().initComponents();
            if (event instanceof NavigationEnd) {
                this.checkHttps();
                this.signalRAction();
            }
        });
    }
    ngOnInit() {
        this.signalR.startConnection();
    }
    signalRAction() {
        if (this.auth.isTokenExist()) {
            this.signalR.sessionEvent(this.router.url);
        }
    }
    checkHttps() {
        var needRedirect = false;
        var newUrl = window.location.href;
        if (window.location.href.includes("www.")) {
            newUrl = window.location.href.replace('www.', '');
            needRedirect = true;
        }
        if (needRedirect) {
            window.location.href = newUrl;
        }
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html'
    }),
    __metadata("design:paramtypes", [Router,
        Window,
        HttpClient,
        Auth,
        SignalRService])
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map