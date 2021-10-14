import { Injectable } from '@angular/core';

function _window(): any {
    return window;
}

@Injectable()
export class Window {
    get current(): any {
        return _window();
    }
}
