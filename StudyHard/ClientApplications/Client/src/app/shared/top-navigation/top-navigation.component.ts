import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Auth } from 'src/app/services/Auth';
import MemberDetailsModel from "../../models/memberDetails.model";

@Component({
    selector: 'top-navigation',
    templateUrl: './top-navigation.component.html'
})

export class TopNavigationComponent {

    user: MemberDetailsModel;
    constructor(private auth: Auth, private http: HttpClient) {
    }

    ngOnInit() {
        this.http.get('/api/memberdetails/user').subscribe((res: MemberDetailsModel) => {
            this.user = res;
        }, error => {
            console.log(error);
        });
    }

    logout() {
        this.auth.logout();
    }  
}