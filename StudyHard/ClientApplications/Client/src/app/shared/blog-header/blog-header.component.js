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
import { BlogTemplateComponent } from '../templates/blog/blog.template.component';
let BlogHeaderComponent = class BlogHeaderComponent {
    constructor(blogTemplate) {
        this.blogTemplate = blogTemplate;
        this.isLoading = true;
    }
    ngOnInit() {
        this.blogTemplate.getBlog().subscribe((res) => {
            this.blog = res;
            this.isLoading = false;
        });
    }
};
BlogHeaderComponent = __decorate([
    Component({
        selector: 'blog-header',
        templateUrl: './blog-header.component.html',
        styleUrls: ['./blog-header.component.css']
    }),
    __metadata("design:paramtypes", [BlogTemplateComponent])
], BlogHeaderComponent);
export { BlogHeaderComponent };
//# sourceMappingURL=blog-header.component.js.map