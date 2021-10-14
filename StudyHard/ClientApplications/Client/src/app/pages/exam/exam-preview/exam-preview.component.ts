import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { ExamPlot } from '../../../models/exam/examplot.model';
import { ExamRating } from '../../../models/exam/examrating.model';
import ExamUserCheckDto from '../../../models/exam/examUserCheck.model';

@Component({
    selector: 'exam-preview',
    templateUrl: './exam-preview.component.html'
})

export class ExamPreviewComponent {
    isRatingLoading = false;
    isPlotLoading = false;
    subjectId = 2;
    subjectRating: ExamRating[];
    lastResult: number = 0;
    isAvailableForUser: boolean;
    isLimitReached: boolean;

    constructor(private http: HttpClient) {
        this.isPlotLoading = true;
        this.isRatingLoading = true;
        this.isAvailableForUser = false;
    }

    ngOnInit() {
        this.checkUser();
        this.getRating();
    }

    checkUser() {
        this.http.get(`api/exam/usercheck`).subscribe((res: ExamUserCheckDto) => {
            this.isAvailableForUser = res.isProfileFilled;
            this.isLimitReached = res.isLimitReached;
            this.lastResult = res.lastResult;
        }, error => {
            console.log(error);
        });
    }

    getRating() {
        this.http.get(`api/exam/rating/${this.subjectId}`).subscribe((res: ExamRating[]) => {
            this.subjectRating = res;
            this.isRatingLoading = false;
        }, error => {
            console.log(error);
        });
    }
}