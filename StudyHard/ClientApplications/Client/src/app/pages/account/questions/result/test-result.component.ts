import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { SimpleQuestion } from 'src/app/models/tests/question.model';

@Component({
    selector: 'test-result',
    templateUrl: './test-result.component.html',
    styleUrls:['./../questions.component.css']
})
export class TestResultComponent {

    isLoading: boolean;
    questions: SimpleQuestion[];
    categoryId: number;
    variants: string[] = ["А)", "Б)", "В)", "Г)"];
    constructor(private http: HttpClient, activateRoute: ActivatedRoute) {
        this.isLoading = true;
        activateRoute.params.subscribe(params => this.categoryId = params['id']);
    }

    ngOnInit() {
        this.http.get(`/api/Tests/testsresult/${this.categoryId}`).subscribe((res: SimpleQuestion[]) => {
            this.questions = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
}