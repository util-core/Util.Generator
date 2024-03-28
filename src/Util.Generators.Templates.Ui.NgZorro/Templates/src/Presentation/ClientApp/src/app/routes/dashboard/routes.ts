import { Routes } from '@angular/router';

import { DashboardMonitorComponent } from './monitor/monitor.component';

export const routes: Routes = [
    { path: '', redirectTo: 'monitor', pathMatch: 'full' },
    { path: 'monitor', component: DashboardMonitorComponent }
];
