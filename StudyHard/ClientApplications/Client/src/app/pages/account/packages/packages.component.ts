import { Component, Input } from '@angular/core';
import { Package } from 'src/app/models/packages/package.model';
import { Router } from "@angular/router";

@Component({
    selector: 'packages',
    templateUrl: './packages.component.html'
})

export class PackagesComponent {

    @Input() package: Package;
    @Input() index: number;

    arrayColors = ['bg-blue-grey-600', 'bg-blue-600', 'bg-red-600', 'bg-orange-600'];
    colorSet;

    constructor(private router: Router) {
    }

    ngOnInit() {
        if (this.index >= this.arrayColors.length) {
            this.index = this.index % this.arrayColors.length;
        }
        this.colorSet = JSON.parse(`{"` + this.arrayColors[this.index] + `": true }`);
    }

    goToLiqpay(packageId){
        this.router.navigate([`/platform/buy/${packageId}`]);
    }
}