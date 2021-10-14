import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { Theory } from 'src/app/models/theories/theory.model';

@Component({
    selector: 'theories',
    templateUrl: './theories.component.html',
    styleUrls: ['./theories.component.css']
})
export class TheoriesComponent {
    isLoading: boolean;
    theories: Theory[];
    caregoryId: number;
    subjectId: number;
    selectedTheoryId: number;
    selectedCategoryName: string;
    isOpen: boolean;
    isScrolling: boolean;
    isZmist: boolean;
    constructor(private http: HttpClient, activateRoute: ActivatedRoute) {
        this.isLoading = true;
        this.isZmist = false;
        activateRoute.params.subscribe(params => {
            this.subjectId = params['subjectId'];
            this.caregoryId = params['categoryId'];
        });
    }

    toggleMobile() {
        this.isOpen = !this.isOpen;
    }

    ngOnInit() {
        this.http.get(`/api/Theories/${this.caregoryId}/theories`).subscribe((res: Theory[]) => {
            this.theories = res;
            this.selectedTheoryId = this.theories[0].id;
            this.selectedCategoryName = this.theories[0].categoryName;
            this.isLoading = false;

        }, error => {
            console.log(error);
        });
    }

    selectTheory(id) {
        this.selectedTheoryId = id;
        this.isZmist = false;
    }

    scrollElement() {
        this.isScrolling = true;
        setTimeout(() => { this.isScrolling = false; console.log('scroll-end') }, 500);
    }

    toggleMenu() {
        this.isZmist = !this.isZmist;
    }
}