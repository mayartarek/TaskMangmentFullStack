import { Routes } from "@angular/router";
import { ProjectListComponent } from "./project-list/project-list.component";
import { ProjectCreateComponent } from "./project-create/project-create.component";

export const ProjectRoutes: Routes = [
  { path: '', redirectTo: 'project', pathMatch: 'full' },

  {
    path: 'project',
    component: ProjectListComponent,
  },
  {
    path: 'create',
    component: ProjectCreateComponent,
  },
  {
    path: 'update/:id',
    loadComponent: () =>
      import('./project-update/project-update.component').then(
        (m) => m.ProjectUpdateComponent
      ),
  }
]