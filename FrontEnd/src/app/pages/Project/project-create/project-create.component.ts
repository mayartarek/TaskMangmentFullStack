import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SweetAlertServices } from 'src/Core/Services/sweetAlert.service';
import { DataService } from 'src/Core/Services/data.service';
import { createProject } from 'src/Core/constant/api.constant';

@Component({
  selector: 'app-project-create',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './project-create.component.html',
  styleUrls: ['./project-create.component.scss']
})
export class ProjectCreateComponent {
  constructor(private router: Router,private sweetAlert:SweetAlertServices,private fb :FormBuilder,private dataService: DataService) { }
  
form: FormGroup=new FormGroup({});
ngOnInit(){
  this.form = this.fb.group({
    name: ['',Validators.required],
    description: ['',Validators.required],  
  });

}

  createProject(){
    this.dataService.post(`${createProject}`,this.form.value).subscribe((res:any)=>{
      this.sweetAlert.successMessage();
      this.router.navigate(['project']);
    },(error:any)=>{
      this.sweetAlert.errorMessage();
    });
  }
}
