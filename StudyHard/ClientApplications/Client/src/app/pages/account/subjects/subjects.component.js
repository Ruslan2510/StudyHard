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
import { ActivatedRoute } from '@angular/router';
let SubjectsComponent = class SubjectsComponent {
    constructor(http, activateRoute) {
        this.http = http;
        activateRoute.params.subscribe(params => { this.packageId = params['id']; this.ngOnInit(); });
    }
    ngOnInit() {
        this.isLoading = true;
        this.http.get(`/api/Tests/${this.packageId}/subjects`).subscribe((res) => {
            this.subjects = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
};
SubjectsComponent = __decorate([
    Component({
        selector: 'subjects',
        templateUrl: './subjects.component.html'
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute])
], SubjectsComponent);
export { SubjectsComponent };
//# sourceMappingURL=subjects.component.js.map