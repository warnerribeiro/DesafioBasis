import { Component } from '@angular/core';
import { Assunto } from 'src/app/interfaces/assunto';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subjectlist',
  templateUrl: './subjectlist.component.html',
  styleUrls: ['./subjectlist.component.css']
})
export class SubjectlistComponent {

  public loading!: boolean;
  public assuntos!: Assunto[];
  /**
   *
   */
  constructor(private subjectService: SubjectService) {

  }

  subject: any;

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.loading = true;
    this.subjectService.getAll().subscribe({
      next: (response: Assunto[]) => {
        console.log('response===>', response);
        this.assuntos = response;
      },
      error: (error: any) => {
        console.log('error===>', error);
      },
      complete: () => { this.loading = false }
    });
  }
}
