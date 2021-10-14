import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import UserNewPostDetails from '../../../../models/memberNewPostDetails.model';

@Component({
    selector: 'new-post-details',
    templateUrl: './new-post-details.component.html'
})

export class NewPostComponent {

    user: UserNewPostDetails;
    isLoading: boolean;
    showSuccess: boolean;
    constructor(private http: HttpClient, private router: Router) {

    }

    ngOnInit() {
        this.isLoading = true;
        this.http.get("/api/MemberDetails/newpost").subscribe((res: UserNewPostDetails) => {
            this.user = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        })
    }


    save() {
        this.isLoading = true;
        this.http.post("/api/MemberDetails/newpost", this.user).subscribe(() => {
            this.isLoading = false;
            this.showSuccess = true;
        }, error => {
            console.log(error);
        })
    }

    navigate() {
        this.router.navigate([`/platform/user/`]);
    }
}