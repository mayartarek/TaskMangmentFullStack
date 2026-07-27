import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectUpdateComponent } from './project-update.component';

describe('ProjectUpdateComponent', () => {
  let component: ProjectUpdateComponent;
  let fixture: ComponentFixture<ProjectUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ProjectUpdateComponent]
    });
    fixture = TestBed.createComponent(ProjectUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
