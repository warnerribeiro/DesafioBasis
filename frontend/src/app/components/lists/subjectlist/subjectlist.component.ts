import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'src/app/interfaces/subject';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subjectlist',
  templateUrl: './subjectlist.component.html',
  styleUrls: ['./subjectlist.component.css']
})
export class SubjectlistComponent {

  public loading!: boolean;
  public assuntos!: Subject[];
  /**
   *
   */
  constructor(private subjectService: SubjectService, private router: Router) { }

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.loading = true;
    this.subjectService.getAll().subscribe({
      next: (response: Subject[]) => {
        console.log('response===>', response);
        this.assuntos = response;
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => { this.loading = false }
    });
  }

  delete(subject: Subject) {
    this.subjectService.delete(subject.subjectId).subscribe({
      next: (response: Subject[]) => {
        console.log('delete===>', response);
      },
      error: (error: any) => {
        console.log('delteerror===>', error);
      },
      complete: () => { this.getList(); }
    });
  }

  update(subject: Subject) {
    this.router.navigateByUrl("/subject/" + subject.subjectId)
  }
}
