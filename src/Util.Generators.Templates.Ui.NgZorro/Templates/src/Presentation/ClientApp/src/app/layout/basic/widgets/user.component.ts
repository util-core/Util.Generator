import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { I18nPipe, SettingsService, User } from '@delon/theme';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { AuthService } from "util-angular";

@Component({
    selector: 'header-user',
    template: `
    <div class="alain-default__nav-item d-flex align-items-center px-sm" nz-dropdown nzPlacement="bottomRight" [nzDropdownMenu]="userMenu">
      <nz-avatar [nzSrc]="user.avatar" nzSize="small" class="mr-sm" />
      {{ user.name }}
    </div>
    <nz-dropdown-menu #userMenu="nzDropdownMenu">
      <div nz-menu class="width-sm">
        <div nz-menu-item routerLink="/pro/account/center">
          <i nz-icon nzType="user" class="mr-sm"></i>
          {{ 'menu.account.center' | i18n }}
        </div>
        <div nz-menu-item routerLink="/pro/account/settings">
          <i nz-icon nzType="setting" class="mr-sm"></i>
          {{ 'menu.account.settings' | i18n }}
        </div>
        <li nz-menu-divider></li>
        <div nz-menu-item (click)="logout()">
          <i nz-icon nzType="logout" class="mr-sm"></i>
          {{ 'menu.account.logout' | i18n }}
        </div>
      </div>
    </nz-dropdown-menu>
  `,
    changeDetection: ChangeDetectionStrategy.OnPush,
    standalone: true,
    imports: [RouterLink, NzDropDownModule, NzMenuModule, NzIconModule, I18nPipe, NzAvatarModule]
})
export class HeaderUserComponent {
    /**
     * 设置服务
     */
    private readonly settings = inject(SettingsService);
    /**
     * 授权服务
     */
    private authService = inject(AuthService);

    /**
     * 获取用户信息
     */
    get user(): User {
        return this.settings.user;
    }

    /**
     * 注销
     */
    logout() {
        this.authService.logout();
    }
}
