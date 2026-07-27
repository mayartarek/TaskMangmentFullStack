import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SweetAlertServices } from 'src/Core/Services/sweetAlert.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataService } from 'src/Core/Services/data.service';
import { createTaskItem, getProjectLookup } from 'src/Core/constant/api.constant';

@Component({
  selector: 'app-task-item-create',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './task-item-create.component.html',
  styleUrls: ['./task-item-create.component.scss']
})
export class TaskItemCreateComponent {
 constructor(private router: Router,private sweetAlert:SweetAlertServices,private fb :FormBuilder,private dataService: DataService) { }
  projects:any=[];
form: FormGroup=new FormGroup({});
ngOnInit(){
  this.getProjects();
  this.form = this.fb.group({
    title: ['',Validators.required],
    description: ['',Validators.required],  
    dueDate: ['',Validators.required],  
    projectId: ['',Validators.required],
  });

}

  createTaskItem(){
     this.dataService.post(`${createTaskItem}`,this.form.value).subscribe((res:any)=>{
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
}
