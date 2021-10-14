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
import MemberDetailsModel from "../../../models/memberDetails.model";
let UserComponent = class UserComponent {
    constructor(http, router) {
        this.http = http;
        this.router = router;
        this.user = new MemberDetailsModel();
        this.isLoading = true;
        this.isLoadingPackages = true;
        this.isLoadingNews = true;
    }
    ngOnInit() {
        // this.http.get('/api/memberdetails/user').subscribe((res: MemberDetailsModel) => {
        //     this.user = res;
        //     this.isLoading = false;
        // }, error => {
        //     console.log(error);
        // });
        // this.http.get("/api/Packages/userpackages").subscribe((res: Package[]) => {
        //     this.userpackages = res;
        //     this.isLoadingPackages = false;
        // }, error => {
        //     console.log(error);
        // });
        const pagination = {
            page: 0,
            pagesize: 10
        };
        this.http.post("/api/Blog/bloglist", pagination).subscribe((res) => {
            this.blogNews = res.paginatedList;
            console.log("LIST: ", res.paginatedList);
            this.isLoadingNews = false;
        }, error => {
            console.log(error);
        });
    }
    findTest(testId) {
        this.http.get(`/api/Tests/checktelegramresult/${testId}`).subscribe((res) => {
            this.question = res;
            if (this.question.isCanBeShown) {
                this.router.navigate([`/platform/telegramresult/${testId}`]);
            }
        }, error => {
            console.log(error);
        });
    }
};
UserComponent = __decorate([
    Component({
        selector: 'user',
        templateUrl: './user.component.html',
        styleUrls: ['./user.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient, Router])
], UserComponent);
export { UserComponent };
//# sourceMappingURL=user.component.js.map