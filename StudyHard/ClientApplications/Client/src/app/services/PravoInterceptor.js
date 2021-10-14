var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from "@angular/core";
import { HttpErrorResponse, HttpResponse } from "@angular/common/http";
import { tap } from 'rxjs/operators';
import { Router } from "@angular/router";
import { ConfigService } from "./ConfigService";
import { AlertifyService } from "./alertify/alertify.service";
let PravoInterceptor = class PravoInterceptor {
    constructor(router, config, alertify) {
        this.router = router;
        this.config = config;
        this.alertify = alertify;
    }
    intercept(req, next) {
        const idToken = localStorage.getItem("access_token");
        let request;
        if (idToken) {
            request = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + idToken)
            });
        }
        return next.handle(idToken ? request : req).pipe(tap(event => {
            if (event instanceof HttpResponse) { }
        }, err => {
            this.alertify.error(err.message);
            if (err instanceof HttpErrorResponse) {
                if (err.status == 401) {
                    console.log('Unauthorized');
                    this.router.navigate(['/account/login']);
                }
            }
        }));
    }
};
PravoInterceptor = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [Router, ConfigService, AlertifyService])
], PravoInterceptor);
export { PravoInterceptor };
//# sourceMappingURL=PravoInterceptor.js.map