import { Injectable } from "@angular/core";
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from 'rxjs/operators';
import { Router } from "@angular/router";
import { ConfigService } from "./ConfigService";
import { AlertifyService } from "./alertify/alertify.service";

@Injectable()
export class PravoInterceptor implements HttpInterceptor {

    constructor(private router: Router, private config: ConfigService, private alertify: AlertifyService) {
    }

    intercept(req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {

        const idToken = localStorage.getItem("access_token");
        let request: HttpRequest<any>;
        if (idToken) { 
            request = req.clone({
                headers: req.headers.set("Authorization",
                    "Bearer " + idToken)
            });
        }
        
        return next.handle(idToken ? request : req).pipe(
            tap(
                event => {
                    if (event instanceof HttpResponse) { }
                },
                err => {
                    this.alertify.error(err.message);
                    if (err instanceof HttpErrorResponse) {
                        if (err.status == 401) {
                            console.log('Unauthorized')
                            this.router.navigate(['/account/login']);
                        }
                    }
                }
            )
        );
    }
}