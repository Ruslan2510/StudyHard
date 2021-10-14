import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Config } from "src/app/models/shared/Config";

@Injectable({
    providedIn: 'root'
})

export class ConfigService {
    public config: Config;

    constructor(private http: HttpClient) { }

    loadConfig() {
        /**
        return this.http
            .get<Config>('/config.json')
            .toPromise()
            .then(config => {
                this.config = config;
            });
        */
    }
}