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
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from "@angular/common/http";
let ExamComponent = class ExamComponent {
    constructor(http, activateRoute, router) {
        this.http = http;
        this.router = router;
        this.examStarted = false;
        this.currentTestIndex = 0;
        this.variants = ["А)", "Б)", "В)", "Г)"];
        this.answers = [];
        this.showResults = false;
        this.correctAnswers = '';
        this.result = {
            SubjectId: 0, AnswersId: [3, 2]
        };
        this.isLoading = true;
        activateRoute.params.subscribe(params => {
            this.subjectId = params['id'];
            this.ngOnInit();
        });
    }
    ngOnInit() {
        this.http.get(`api/exam/subjects/${this.subjectId}/tests`).subscribe((res) => {
            this.categories = res;
            this.isLoading = false;
            this.examStarted = false;
            this.showResults = false;
            this.currentTestIndex = 0;
            this.answers = [];
            this.correctAnswers = '';
        }, error => {
            console.log(error);
        });
    }
    startExam() {
        this.examStarted = true;
    }
    createAnswer(a, testIndex) {
        if (this.answers[testIndex]) {
            this.answers.splice(testIndex, 1);
            this.answers[testIndex] = a;
        }
        else {
            this.answers[testIndex] = a;
        }
    }
    nextTest() {
        this.currentTestIndex++;
    }
    finishExam() {
        this.showResults = true;
        this.examStarted = false;
        this.result.AnswersId = this.answers.map(x => x.id);
        this.result.SubjectId = Number(this.subjectId);
        if (this.answers.length) {
            this.http.post("/api/Exam/finish", this.result).subscribe(x => {
                this.router.navigate([`/platform/user`]);
            });
        }
        else {
            this.router.navigate([`/platform/user`]);
        }
    }
};
ExamComponent = __decorate([
    Component({
        selector: 'exam',
        templateUrl: './exam.component.html',
        styleUrls: ['./exam.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute, Router])
], ExamComponent);
export { ExamComponent };
//# sourceMappingURL=exam.component.js.map