import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AppAuthService } from '../../shared/auth/app-auth.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './topbar.component.html',
    selector: 'top-bar',
    encapsulation: ViewEncapsulation.None
})
export class TopBarComponent extends AppComponentBase {

    constructor(
        injector: Injector,
        private _authService: AppAuthService,
        private _router: Router,


    ) {
        super(injector);
    }

    logIn(): void {
        this._router.navigate(['/account/login-person']);

    }
}
