import { Routes } from '@angular/router';
import { AuthGuard } from 'src/Core/Guard/auth.gurd';

export const PagesRoutes: Routes = [
  { path: '', redirectTo: 'project', pathMatch: 'full' },
 

  {
    path: 'project',
    loadChildren: () =>
      import('./Project/project-module').then((m) => m.ProjectRoutes),
  },
  
]