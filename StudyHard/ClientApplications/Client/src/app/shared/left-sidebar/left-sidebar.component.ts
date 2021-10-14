import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { PackageNavigation } from 'src/app/models/navigation/packageNavigation.model';
import { SubjectNavigation } from '../../models/navigation/subjectNavigation.model';


@Component({
    selector: 'left-sidebar',
    templateUrl: './left-sidebar.component.html'
})

export class LeftSidebarComponent {

    packagesNav: PackageNavigation[]

    examsNav: SubjectNavigation[]

    constructor(private http: HttpClient, private router: Router) {
        this.router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                this.getPackagesNav();
            }
        });
    }

    getPackagesNav() {
        this.http.get(`/api/Navigation/navigation`).subscribe((res: PackageNavigation[]) => {
            this.packagesNav = res;
        }, error => {
            console.log(error);
        });
    }

    ngOnInit() {
        this.getPackagesNav();

        this.http.get('/api/Navigation/examnavigation').subscribe((res: SubjectNavigation[]) => {
            this.examsNav = res;
        }, error => {
            console.log(error);
        });
    }
}