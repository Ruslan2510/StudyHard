import { Component, Input } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Subject } from 'src/app/models/tests/subject.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'subjects',
    templateUrl: './subjects.component.html'
})

export class SubjectsComponent {
    isLoading: boolean;
    packageId: number;
    subjects: Subject[];
    constructor(private http: HttpClient, activateRoute: ActivatedRoute) {        
        activateRoute.params.subscribe(params => { this.packageId = params['id']; this.ngOnInit(); });
    }

    ngOnInit() {
        this.isLoading = true;
        this.http.get(`/api/Tests/${this.packageId}/subjects`).subscribe((res: Subject[]) => {
            this.subjects = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
}