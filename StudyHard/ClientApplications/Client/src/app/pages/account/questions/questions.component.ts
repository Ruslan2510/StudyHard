import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { Question } from 'src/app/models/tests/question.model';
import { Answer } from 'src/app/models/tests/answer.model';
import { UserAnswer } from 'src/app/models/tests/userAnswer.model';
import { Category } from '../../../models/tests/category.model';

@Component({
    selector: 'questions',
    templateUrl: './questions.component.html',
    styleUrls: ['./questions.component.css']
})
export class QuestionsComponent {
    categories: Category[];
    isLoading: boolean;
    questions: Question[];
    categoryId: number;
    subjectId: number;
    queIdForUI: number;
    userAnswer: UserAnswer;
    selectedCategoryName: string;
    variants: string[] = ["А)", "Б)", "В)", "Г)"];
    isZmist: boolean;
    constructor(private http: HttpClient, activateRoute: ActivatedRoute) {
        this.isLoading = true;
        activateRoute.params.subscribe(params => {
            this.categoryId = parseInt(params['categoryId'], 10), this.subjectId = params['subjectId']
            this.ngOnInit();
        });
    }

    ngOnInit() {
        this.isLoading = true;
        this.isZmist = true;
        this.http.get(`/api/Tests/${this.subjectId}/category`).subscribe((res: Category[]) => {
            this.categories = res;
            this.selectedCategoryName = this.categories.find(x => x.id == this.categoryId).name;
        }, error => {
            console.log(error);
        });
        this.http.get(`/api/Tests/${this.categoryId}/question`).subscribe((res: Question[]) => {
            this.questions = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
        this.userAnswer = new UserAnswer();
        this.showAnswers = false;
        this.queIdForUI = 0;
    }
    showAnswers: boolean;
    createAnswer(answer: Answer) {
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
}