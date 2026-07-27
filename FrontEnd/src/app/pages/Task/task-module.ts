import { Routes } from "@angular/router";

export const TaskRoutes: Routes = [


    {
        path: 'task-item',
        loadComponent: () =>
          import('./task-item-list/task-item-list.component').then(     
(m) => m.TaskItemListComponent
          ),
      },
      {
        path: 'create',
        loadComponent: () =>
          import('./task-item-create/task-item-create.component').then( 
(m) => m.TaskItemCreateComponent),
      },{
        path: 'update/:id',
        loadComponent: () =>
          import('./task-item-update/task-item-update.component').then(
            (m) => m.TaskItemUpdateComponent
          ),
      }
    
];