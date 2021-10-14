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
import { ActivatedRoute } from '@angular/router';
let BlogTemplateComponent = class BlogTemplateComponent {
    constructor(http, activatedRoute) {
        this.http = http;
        this.activatedRoute = activatedRoute;
    }
    getBlog() {
        let blogId = "";
        this.activatedRoute.params.subscribe(params => {
            blogId = params['id'];
        });
        return this.http.get(`api/blog/${blogId}`);
    }
};
BlogTemplateComponent = __decorate([
    Component({
        selector: 'blog.template',
        templateUrl: './blog.template.component.html',
        styleUrls: ['./blog.template.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute])
], BlogTemplateComponent);
export { BlogTemplateComponent };
//# sourceMappingURL=blog.template.component.js.map