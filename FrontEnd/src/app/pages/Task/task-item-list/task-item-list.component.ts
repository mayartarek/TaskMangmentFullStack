import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService } from 'src/Core/Services/data.service';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { deleteTaskItem, getTaskItemList } from 'src/Core/constant/api.constant';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-task-item-list',
  standalone: true,
  imports: [CommonModule,NgxPaginationModule,FormsModule],
  templateUrl: './task-item-list.component.html',
  styleUrls: ['./task-item-list.component.scss']
})
export class TaskItemListComponent {

 page=1;
 size=10;
 TaskItemItems: any[] = [];
count = 0;

constructor(private router: Router,private dataService: DataService) { } 
     httpOptions = {
        headers: new HttpHeaders({ "Content-Type": "application/json" }),
    };
    
  ngOnInit() {  
    this.getTaskItems();
  }
  getTaskItems(){
    this.dataService.getList(getTaskItemList +"?page="+this.page+"&pageSize="+this.size,this.httpOptions).subscribe((res:any)=>{
      this.TaskItemItems = res.list;
      this.count = res.count;
    });
  }
  addItem(){
    this.router.navigate(['task-item/create']);
  }
    deleteItem(id: string) { 
      this.dataService.delete(`${deleteTaskItem}?id=${id}`,{}).subscribe((res: any) => {
        this.getTaskItems();
      });
    } 
     
  editItem(id: string) { 
    this.router.navigate(['task-item/update', id]);
   }
}
