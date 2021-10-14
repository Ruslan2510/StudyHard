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
let ExamPreviewComponent = class ExamPreviewComponent {
    constructor(http) {
        this.http = http;
        this.isRatingLoading = false;
        this.isPlotLoading = false;
        this.subjectId = 2;
        this.lastResult = 0;
        this.isPlotLoading = true;
        this.isRatingLoading = true;
        this.isAvailableForUser = false;
    }
    ngOnInit() {
        this.checkUser();
        this.getRating();
    }
    checkUser() {
        this.http.get(`api/exam/usercheck`).subscribe((res) => {
            this.isAvailableForUser = res.isProfileFilled;
            this.isLimitReached = res.isLimitReached;
            this.lastResult = res.lastResult;
        }, error => {
            console.log(error);
        });
    }
    getRating() {
        this.http.get(`api/exam/rating/${this.subjectId}`).subscribe((res) => {
            this.subjectRating = res;
            this.isRatingLoading = false;
        }, error => {
            console.log(error);
        });
    }
};
ExamPreviewComponent = __decorate([
    Component({
        selector: 'exam-preview',
        templateUrl: './exam-preview.component.html'
    }),
    __metadata("design:paramtypes", [HttpClient])
], ExamPreviewComponent);
export { ExamPreviewComponent };
//# sourceMappingURL=exam-preview.component.js.map