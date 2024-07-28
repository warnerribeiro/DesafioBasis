import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { Subject } from 'src/app/interfaces/subject';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent {

  private readonly formBuilder = inject(FormBuilder);
  private readonly subjectService = inject(SubjectService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);

  private id!: number;

  protected form: any = this.formBuilder.group(
    {
      description: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
    }
  );

  ngOnInit(): void {

    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (id) {
      this.subjectService.get(id).subscribe({
        next: (response: Subject) => {
          this.form.get('description')?.setValue(response.description);
          this.id = response.subjectId;
        },
        error: (error: any) => {
          console.log('Error getting the subject!', error);
        },
        complete: () => { }
      });
    }
  }

  onSubmit() {
    var subject: Subject = this.form.value;
    subject.subjectId = this.id ?? 0;

    if (this.id) {
      this.update(subject);
    } else {
      this.add(subject);
    }
  }

  add(subject: Subject) {
    this.subjectService.post(subject).subscribe({
      next: (response: Subject) => {
        console.log('Subject Saved!', response);
        //this.assuntos = response;
        this.router.navigateByUrl("/subjectlist");
      },
      error: (error: any) => {
        console.log('Error saving the subject!', error);
      },
      complete: () => { }
    });
  }

  update(subject: Subject) {
    this.subjectService.put(this.id, subject).subscribe({
      next: (response: Subject) => {
        console.log('Subject Update!', response);
        //this.assuntos = response;
        this.router.navigateByUrl("/subjectlist");
      },
      error: (error: any) => {
        console.log('Error updating the subject!', error);
      },
      complete: () => { }
    });
  }
}
