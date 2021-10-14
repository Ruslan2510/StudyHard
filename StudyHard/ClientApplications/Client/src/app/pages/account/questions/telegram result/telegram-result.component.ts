import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { SimpleQuestion } from 'src/app/models/tests/question.model';

@Component({
    selector: 'telegram-result',
    templateUrl: './telegram-result.component.html',
    styleUrls:['./../questions.component.css']
})
export class TelegramResultComponent {

    isLoading: boolean;
    question: SimpleQuestion;
    questionId: number;
    variants: string[] = ["А)", "Б)", "В)", "Г)"];

    constructor(private http: HttpClient, activateRoute: ActivatedRoute) {
        this.isLoading = true;
        activateRoute.params.subscribe(params => this.questionId = params['id']);
    }

    ngOnInit() {
        this.http.get(`/api/Tests/telegramresult/${this.questionId}`).subscribe((res: SimpleQuestion) => {
            this.question = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
}