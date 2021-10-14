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
import { UserAnswer } from 'src/app/models/tests/userAnswer.model';
let QuestionsComponent = class QuestionsComponent {
    constructor(http, activateRoute) {
        this.http = http;
        this.variants = ["А)", "Б)", "В)", "Г)"];
        this.isLoading = true;
        activateRoute.params.subscribe(params => {
            this.categoryId = parseInt(params['categoryId'], 10), this.subjectId = params['subjectId'];
            this.ngOnInit();
        });
    }
    ngOnInit() {
        this.isLoading = true;
        this.isZmist = true;
        this.http.get(`/api/Tests/${this.subjectId}/category`).subscribe((res) => {
            this.categories = res;
            this.selectedCategoryName = this.categories.find(x => x.id == this.categoryId).name;
        }, error => {
            console.log(error);
        });
        this.http.get(`/api/Tests/${this.categoryId}/question`).subscribe((res) => {
            this.questions = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
        this.userAnswer = new UserAnswer();
        this.showAnswers = false;
        this.queIdForUI = 0;
    }
    createAnswer(answer) {
        this.showAnswers = true;
        this.userAnswer = new UserAnswer();
        this.userAnswer.simpleTestAnswerId = answer.id;
        this.userAnswer.simpleTestQuestionId = answer.simpleTestQuestionId;
        this.userAnswer.testCategoryId = this.categoryId;
    }
    next() {
        if (this.userAnswer && this.userAnswer.simpleTestAnswerId) {
            this.http.post('/api/Tests/questionsave', this.userAnswer)
                .subscribe(x => {
                this.queIdForUI++;
            });
        }
        else {
            this.queIdForUI++;
        }
        this.userAnswer = new UserAnswer();
        this.showAnswers = false;
    }
    toggleMenu() {
        this.isZmist = !this.isZmist;
    }
};
QuestionsComponent = __decorate([
    Component({
        selector: 'questions',
        templateUrl: './questions.component.html',
        styleUrls: ['./questions.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute])
], QuestionsComponent);
export { QuestionsComponent };
//# sourceMappingURL=questions.component.js.map