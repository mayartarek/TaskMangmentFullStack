import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { DataService } from 'src/Core/Services/data.service';
import { HttpHeaders } from '@angular/common/http';
import { deleteProject, getProjectList } from 'src/Core/constant/api.constant';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [CommonModule,    FormsModule,
    NgxPaginationModule
],
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent {

 page=1;
 size=10;
 projectItems: any[] = [];
count = 0;

constructor(private router: Router,private dataService: DataService) { } 
     httpOptions = {
        headers: new HttpHeaders({ "Content-Type": "application/json" }),
    };
    
  ngOnInit() {  
    this.getProjects();
  }
  getProjects(){
    this.dataService.getList(getProjectList +"?page="+this.page+"&pageSize="+this.size,this.httpOptions).subscribe((res:any)=>{
      this.projectItems = res.list;
      this.count = res.count;
    });
  }
  addItem(){
    this.router.navigate(['project/create']);
  }
    deleteItem(id: string) { 
      this.dataService.delete(deleteProject + `?id=${id}`,{}).subscribe((res: any) => {
        this.getProjects();
      });
    } 
     
  editItem(id: string) { 
    this.router.navigate(['project/update', id]);
   }
}
