import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskItemUpdateComponent } from './task-item-update.component';

describe('TaskItemUpdateComponent', () => {
  let component: TaskItemUpdateComponent;
  let fixture: ComponentFixture<TaskItemUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [TaskItemUpdateComponent]
    });
    fixture = TestBed.createComponent(TaskItemUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
