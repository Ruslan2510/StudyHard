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
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
let ProfileComponent = class ProfileComponent {
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.isLoading = true;
    }
    ngOnInit() {
        this.http.get('/api/memberdetails/universities').subscribe((uni) => {
            this.universities = uni;
        });
        this.http.get('/api/memberdetails/user').subscribe((res) => {
            this.user = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
    save() {
        this.isLoading = true;
        console.log(this.user);
        this.http.post('/api/memberdetails/user', this.user).subscribe(x => {
            this.router.navigate([`/platform/user/`]);
        }, error => {
            console.log(error);
            this.isLoading = false;
        });
    }
};
ProfileComponent = __decorate([
    Component({
        selector: 'profile',
        templateUrl: './profile.component.html'
    }),
    __metadata("design:paramtypes", [HttpClient, Router])
], ProfileComponent);
export { ProfileComponent };
//# sourceMappingURL=profile.component.js.map