import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import MemberDetailsModel from '../../../../models/memberDetails.model';
import { Router } from "@angular/router";
import { University } from '../../../../models/unvercity.model';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html'
})

export class ProfileComponent {
    user: MemberDetailsModel;
    isLoading: boolean;
    universities: University[];
    constructor(private http: HttpClient, private router: Router) {
        this.isLoading = true;
    }

    ngOnInit() {
        this.http.get('/api/memberdetails/universities').subscribe((uni: University[]) => {
            this.universities = uni;
        });

        this.http.get('/api/memberdetails/user').subscribe((res: MemberDetailsModel) => {
            this.user = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }

    save() {
        this.isLoading = true;
        console.log(this.user);
        this.http.post('/api/memberdetails/user', this.user).subscribe(x => {
            this.router.navigate([`/platform/user/`]);
        }, error => {
            console.log(error);
            this.isLoading = false;
        });
    }
}