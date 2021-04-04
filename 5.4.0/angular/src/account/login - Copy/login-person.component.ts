import { Component, Injector } from '@angular/core';
import { AbpSessionService } from '@abp/session/abp-session.service';
import { AppComponentBase } from '@shared/app-component-base';
import { accountModuleAnimation } from '@shared/animations/routerTransition';
import { LoginPersonService } from './login-person.service';

@Component({
  templateUrl: './login-person.component.html',
  styleUrls: ['./login-person.component.less'],
  animations: [accountModuleAnimation()]
})
export class LoginPersonComponent extends AppComponentBase {
  submitting = false;

  constructor(
    injector: Injector,
      public loginService: LoginPersonService,
    private _sessionService: AbpSessionService
  ) {
      super(injector);
    
  }

  get multiTenancySideIsTeanant(): boolean {
    return this._sessionService.tenantId > 0;
  }

  get isSelfRegistrationAllowed(): boolean {
    //if (!this._sessionService.tenantId) {
    //  return false;
    //}

    return true;
  }

  login(): void {
    this.submitting = true;
    this.loginService.authenticate(() => (this.submitting = false));
  }
}
