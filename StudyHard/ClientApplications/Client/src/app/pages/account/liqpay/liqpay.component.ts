import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Window } from 'src/app/services/Window';
import { LiqpayData } from 'src/app/models/liqpay/liqpayData.model';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { NgZone } from '@angular/core'; 

@Component({
    selector: 'liqpay',
    templateUrl: './liqpay.component.html'
})
export class LiqpayComponent {

    packageId: string;
    isLoading: boolean;
    liqpayData:  LiqpayData;

    constructor(private http: HttpClient, activateRoute: ActivatedRoute,private winRef: Window,private router: Router,private ngZone: NgZone) {
        activateRoute.params.subscribe(params => this.packageId = params['id']);
        this.isLoading = true;
    }

    ngOnInit() {
        window['angularComponentReference'] = 
        {
            component: this,
            zone: this.ngZone, 
            goToSubjects: () => this.goToSubjects(),
            goToNewPostDetails: () => this.goToNewPostDetails(),
        }; 
        this.http.get(`/api/Liqpay/data/${this.packageId}`)
        .subscribe((result: LiqpayData) => {
            this.isLoading = false;
            this.liqpayData = result;
            this.winRef.current.initAngularLiqpay(this.liqpayData.data, this.liqpayData.signature, this.router);
        });
    }

    goToSubjects() {
        this.router.navigate([`/platform/subjects/${this.packageId}`]);
    }

    goToNewPostDetails() {
        this.router.navigate([`/platform/user/profile/newpost`]);
    }
}