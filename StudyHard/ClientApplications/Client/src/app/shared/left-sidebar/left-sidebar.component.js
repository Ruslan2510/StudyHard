var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
let LeftSidebarComponent = class LeftSidebarComponent {
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                this.getPackagesNav();
            }
        });
    }
    getPackagesNav() {
        this.http.get(`/api/Navigation/navigation`).subscribe((res) => {
            this.packagesNav = res;
        }, error => {
            console.log(error);
        });
    }
    ngOnInit() {
        this.getPackagesNav();
        this.http.get('/api/Navigation/examnavigation').subscribe((res) => {
            this.examsNav = res;
        }, error => {
            console.log(error);
        });
    }
};
LeftSidebarComponent = __decorate([
    Component({
        selector: 'left-sidebar',
        templateUrl: './left-sidebar.component.html'
    }),
    __metadata("design:paramtypes", [HttpClient, Router])
], LeftSidebarComponent);
export { LeftSidebarComponent };
//# sourceMappingURL=left-sidebar.component.js.map