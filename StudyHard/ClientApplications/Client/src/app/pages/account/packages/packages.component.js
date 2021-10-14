var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { Package } from 'src/app/models/packages/package.model';
import { Router } from "@angular/router";
let PackagesComponent = class PackagesComponent {
    constructor(router) {
        this.router = router;
        this.arrayColors = ['bg-blue-grey-600', 'bg-blue-600', 'bg-red-600', 'bg-orange-600'];
    }
    ngOnInit() {
        if (this.index >= this.arrayColors.length) {
            this.index = this.index % this.arrayColors.length;
        }
        this.colorSet = JSON.parse(`{"` + this.arrayColors[this.index] + `": true }`);
    }
    goToLiqpay(packageId) {
        this.router.navigate([`/platform/buy/${packageId}`]);
    }
};
__decorate([
    Input(),
    __metadata("design:type", Package)
], PackagesComponent.prototype, "package", void 0);
__decorate([
    Input(),
    __metadata("design:type", Number)
], PackagesComponent.prototype, "index", void 0);
PackagesComponent = __decorate([
    Component({
        selector: 'packages',
        templateUrl: './packages.component.html'
    }),
    __metadata("design:paramtypes", [Router])
], PackagesComponent);
export { PackagesComponent };
//# sourceMappingURL=packages.component.js.map