import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { TelegramQuestionResult } from 'src/app/models/tests/telegram.question.model';
import MemberDetailsModel from "../../../models/memberDetails.model";
import PaginatedData from "../../../models/pagination/paginatedData.model";
import PaginationData from "../../../models/pagination/paginationData.model";
import BlogNews from "../../../models/blogNews.model";
import { Package } from 'src/app/models/packages/package.model';

@Component({
    selector: 'user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})

export class UserComponent {

    isLoading: boolean;
    isLoadingPackages: boolean;
    isLoadingNews: boolean;
    constructor(private http: HttpClient, private router: Router) {
        this.isLoading = true;
        this.isLoadingPackages = true;
        this.isLoadingNews = true;
    }

    user: MemberDetailsModel = new MemberDetailsModel();
    userpackages: Package[];
    blogNews: BlogNews[];
    question: TelegramQuestionResult;
    isZmist: boolean;
    ngOnInit() {
        // this.http.get('/api/memberdetails/user').subscribe((res: MemberDetailsModel) => {
        //     this.user = res;
        //     this.isLoading = false;
        // }, error => {
        //     console.log(error);
        // });
        // this.http.get("/api/Packages/userpackages").subscribe((res: Package[]) => {
        //     this.userpackages = res;
        //     this.isLoadingPackages = false;
        // }, error => {
        //     console.log(error);
        // });

        const pagination: PaginationData = {
            page: 0,
            pagesize: 10
        };

        this.http.post("/api/Blog/bloglist", pagination).subscribe((res: PaginatedData) => {
            this.blogNews = res.paginatedList;
            console.log("LIST: ", res.paginatedList)
            this.isLoadingNews = false;
        }, error => {
            console.log(error);
        });
    }

    findTest(testId) {
        this.http.get(`/api/Tests/checktelegramresult/${testId}`).subscribe((res: TelegramQuestionResult) => {
            this.question = res;
            if(this.question.isCanBeShown) {
                this.router.navigate([`/platform/telegramresult/${testId}`]);
            }
        }, error => {
            console.log(error);
        });
    }
}