import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { getProjectLookup, getTaskItemById, updateTaskItem } from 'src/Core/constant/api.constant';
import { Router } from '@angular/router';
import { SweetAlertServices } from 'src/Core/Services/sweetAlert.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataService } from 'src/Core/Services/data.service';

@Component({
  selector: 'app-task-item-update',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule ],
  templateUrl: './task-item-update.component.html',
  styleUrls: ['./task-item-update.component.scss']
})
export class TaskItemUpdateComponent {
constructor(private router: Router,private sweetAlert:SweetAlertServices,private fb :FormBuilder,private dataService: DataService) { }
  projects:any=[];
form: FormGroup=new FormGroup({});
taskItem:any={};
ngOnInit(){
  this.getProjects();
  this.getTaskItemById(this.router.url.split('/')[3]);
  this.form = this.fb.group({
    id: [''],
    title: ['',Validators.required],
    description: ['',Validators.required],  
    dueDate: [ '',Validators.required],  
    projectId: ['',Validators.required],
  });

}

  updateTaskItem(){
     this.dataService.put(`${updateTaskItem}`,this.form.value).subscribe((res:any)=>{
      this.sweetAlert.successMessage();
      this.router.navigate(['task-item/task-item']);
    },(error:any)=>{
      this.sweetAlert.errorMessage();
    });
  }
  getProjects(){
    this.dataService.getList(`${getProjectLookup}`,{}).subscribe((res:any)=>{
      this.projects=res
      this.form.patchValue({projectId: res[0].id});
    });
  }
  getTaskItemById(id: string){
    this.dataService.getList(`${getTaskItemById}`+`?id=${id}`,{}).subscribe((res:any)=>{
      this.taskItem=res;
     res.dueDate=  this.taskItem.dueDate.split('T')[0]
      this.form.patchValue(res);
    });
  }
}
