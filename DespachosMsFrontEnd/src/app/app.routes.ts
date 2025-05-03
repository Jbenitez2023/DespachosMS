import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LayoutComponent } from './layout/layout.component';
export const routes: Routes = [
    { path: '',component: LoginComponent},
    { path: 'intern',
      component:LayoutComponent,
      children: [
        {path: 'dashboard',component:DashboardComponent}
      ]
    } 
];
