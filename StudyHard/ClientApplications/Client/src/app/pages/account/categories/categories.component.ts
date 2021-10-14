import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { Category } from 'src/app/models/tests/category.model';
declare var $

@Component({
    selector: 'categories',
    templateUrl: './categories.component.html',
    styleUrls: ['./categories.component.css']
})

export class CategoriesComponent {

    categories: Category[];
    subjectId: number;
    isLoading: boolean;
    constructor(private http: HttpClient, activateRoute: ActivatedRoute, private router: Router) {
        this.isLoading = true;
        activateRoute.params.subscribe(params => {
            this.subjectId = params['id'];
            this.ngOnInit();
        });
    }

    ngOnInit() {
        this.http.get(`/api/Tests/${this.subjectId}/category`).subscribe((res: Category[]) => {
            this.categories = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }


    cleanResults(category: Category) {
        this.http.get(`/api/Tests/category/clean/${category.id}`).subscribe(() =>
        {
            category.correctAnswers = 0;
        }, error => {
            console.log(error);
        });
    }
}