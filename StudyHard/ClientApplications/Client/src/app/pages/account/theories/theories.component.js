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
import { HttpClient } from "@angular/common/http";
let TheoriesComponent = class TheoriesComponent {
    constructor(http, activateRoute) {
        this.http = http;
        this.isLoading = true;
        this.isZmist = false;
        activateRoute.params.subscribe(params => {
            this.subjectId = params['subjectId'];
            this.caregoryId = params['categoryId'];
        });
    }
    toggleMobile() {
        this.isOpen = !this.isOpen;
    }
    ngOnInit() {
        this.http.get(`/api/Theories/${this.caregoryId}/theories`).subscribe((res) => {
            this.theories = res;
            this.selectedTheoryId = this.theories[0].id;
            this.selectedCategoryName = this.theories[0].categoryName;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
    selectTheory(id) {
        this.selectedTheoryId = id;
        this.isZmist = false;
    }
    scrollElement() {
        this.isScrolling = true;
        setTimeout(() => { this.isScrolling = false; console.log('scroll-end'); }, 500);
    }
    toggleMenu() {
        this.isZmist = !this.isZmist;
    }
};
TheoriesComponent = __decorate([
    Component({
        selector: 'theories',
        templateUrl: './theories.component.html',
        styleUrls: ['./theories.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute])
], TheoriesComponent);
export { TheoriesComponent };
//# sourceMappingURL=theories.component.js.map