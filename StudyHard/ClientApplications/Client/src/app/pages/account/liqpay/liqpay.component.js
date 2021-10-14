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
import { ActivatedRoute } from '@angular/router';
import { Window } from 'src/app/services/Window';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { NgZone } from '@angular/core';
let LiqpayComponent = class LiqpayComponent {
    constructor(http, activateRoute, winRef, router, ngZone) {
        this.http = http;
        this.winRef = winRef;
        this.router = router;
        this.ngZone = ngZone;
        activateRoute.params.subscribe(params => this.packageId = params['id']);
        this.isLoading = true;
    }
    ngOnInit() {
        window['angularComponentReference'] =
            {
                component: this,
                zone: this.ngZone,
                goToSubjects: () => this.goToSubjects(),
                goToNewPostDetails: () => this.goToNewPostDetails(),
            };
        this.http.get(`/api/Liqpay/data/${this.packageId}`)
            .subscribe((result) => {
            this.isLoading = false;
            this.liqpayData = result;
            this.winRef.current.initAngularLiqpay(this.liqpayData.data, this.liqpayData.signature, this.router);
        });
    }
    goToSubjects() {
        this.router.navigate([`/platform/subjects/${this.packageId}`]);
    }
    goToNewPostDetails() {
        this.router.navigate([`/platform/user/profile/newpost`]);
    }
};
LiqpayComponent = __decorate([
    Component({
        selector: 'liqpay',
        templateUrl: './liqpay.component.html'
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute, Window, Router, NgZone])
], LiqpayComponent);
export { LiqpayComponent };
//# sourceMappingURL=liqpay.component.js.map