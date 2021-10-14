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
import { ViewEncapsulation } from '@angular/core';
import { BlogTemplateComponent } from 'src/app/shared/templates/blog/blog.template.component';
let BlogPageComponent = class BlogPageComponent {
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
BlogPageComponent = __decorate([
    Component({
        selector: 'blog-page',
        templateUrl: './blog-page.component.html',
        styleUrls: ['./blog-page.component.css'],
        encapsulation: ViewEncapsulation.None
    }),
    __metadata("design:paramtypes", [BlogTemplateComponent])
], BlogPageComponent);
export { BlogPageComponent };
//# sourceMappingURL=blog-page.component.js.map