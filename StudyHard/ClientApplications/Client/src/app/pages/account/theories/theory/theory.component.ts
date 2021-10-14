import { Component, Input, OnChanges  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { Theory } from 'src/app/models/theories/theory.model';

@Component({
    selector: 'theory',
    templateUrl: './theory.component.html',
    styleUrls: ['./theory.component.css']
})
export class TheoryComponent {
    isLoading: boolean;
    theory: Theory;
    @Input() theoryId: number;
    subjectId: number;

    constructor(private http: HttpClient, activateRoute: ActivatedRoute) {
        this.ngOnChanges();
    }

    ngOnChanges() {
        this.isLoading = true;
        this.http.get(`/api/Theories/${this.theoryId}/theory`).subscribe((res: Theory) => {
            this.theory = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
}