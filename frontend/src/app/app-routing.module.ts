import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeGuard } from './core/guards/home.guard';

const routes: Routes = [
  { path: '',
    loadChildren: () =>
      import('./modules/landing-page/landing-page.module')
        .then(m => m.LandingPageModule),
    canActivate: [HomeGuard]
  },
  // { path: 'signin', component: SignInComponent, canActivate: [HomeGuard] },
  // { path: 'signup', component: SignUpComponent, canActivate: [HomeGuard] },
  // {
  //   path: 'portal',
  //   canActivate: [AuthGuard],
  //   resolve: {
  //     auth: AuthResolver
  //   },
  //   loadChildren: () => import('./modules/work-space/work-space.module')
  //     .then(m => m.WorkSpaceModule),
  // },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
