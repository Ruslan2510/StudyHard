var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
let TelegramResultComponent = class TelegramResultComponent {
    constructor(http, activateRoute) {
        this.http = http;
        this.variants = ["А)", "Б)", "В)", "Г)"];
        this.isLoading = true;
        activateRoute.params.subscribe(params => this.questionId = params['id']);
    }
    ngOnInit() {
        this.http.get(`/api/Tests/telegramresult/${this.questionId}`).subscribe((res) => {
            this.question = res;
            this.isLoading = false;
        }, error => {
            console.log(error);
        });
    }
};
TelegramResultComponent = __decorate([
    Component({
        selector: 'telegram-result',
        templateUrl: './telegram-result.component.html',
        styleUrls: ['./../questions.component.css']
    }),
    __metadata("design:paramtypes", [HttpClient, ActivatedRoute])
], TelegramResultComponent);
export { TelegramResultComponent };
//# sourceMappingURL=telegram-result.component.js.map