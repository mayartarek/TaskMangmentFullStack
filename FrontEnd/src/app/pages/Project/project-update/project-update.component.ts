import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SweetAlertServices } from 'src/Core/Services/sweetAlert.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DataService } from 'src/Core/Services/data.service';
import { getProjectById, updateProject } from 'src/Core/constant/api.constant';

@Component({
  selector: 'app-project-update',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './project-update.component.html',
  styleUrls: ['./project-update.component.scss']
})
export class ProjectUpdateComponent {
  constructor(private router: Router,private sweetAlert:SweetAlertServices,private fb :FormBuilder,private dataService: DataService) { }
  
form: FormGroup=new FormGroup({});
ngOnInit(){
  this.getProjectById(this.router.url.split('/')[3]);
  this.form = this.fb.group({
    id: [''],
    name: ['',Validators.required],
    description: ['',Validators.required],  
  });

}

  updateProject(){
    this.dataService.put(`${updateProject}`,this.form.value).subscribe((res:any)=>{
      this.sweetAlert.successMessage();
      this.router.navigate(['project']);
    },(error:any)=>{
      this.sweetAlert.errorMessage();
    });
  }
  getProjectById(id: string){
    this.dataService.getList(`${getProjectById}?id=${id}`,{}).subscribe((res:any)=>{
      this.form.patchValue(res);
    });
  }
}
