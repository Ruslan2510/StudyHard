import { Component, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { ExamResult } from '../../models/exam/examresult.model';

declare var $

@Component({
    selector: 'exam',
    templateUrl: './exam.component.html',
    styleUrls: ['./exam.component.css']
})

export class ExamComponent {
    categories: any[];
    subjectId: number;
    isLoading: boolean;
    examStarted: boolean = false;
    currentTestIndex: number = 0;
    variants: string[] = ["А)", "Б)", "В)", "Г)"];
    answers: any[] = [];
    showResults: boolean = false;
    correctAnswers: string = '';
    result: ExamResult = {
        SubjectId: 0, AnswersId: [3, 2]
    };
    constructor(private http: HttpClient, activateRoute: ActivatedRoute, private router: Router) {
        this.isLoading = true;
        activateRoute.params.subscribe(params => {
            this.subjectId = params['id'];
            this.ngOnInit();
        });
    }

    ngOnInit() {
        this.http.get(`api/exam/subjects/${this.subjectId}/tests`).subscribe((res: any[]) => {
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
            this.answers[testIndex] = a
        } else {
            this.answers[testIndex] = a
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
}