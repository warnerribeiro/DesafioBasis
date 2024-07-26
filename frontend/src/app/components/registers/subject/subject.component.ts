import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'src/app/interfaces/subject';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent {

  private readonly formBuilder = inject(FormBuilder);
  private subjectService = inject(SubjectService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  public assuntos!: Subject;
  private id!: number;

	show = false;

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
          console.log('Subject GetId!', response);
          this.form.get('description')?.setValue(response.description);
          this.id = response.subjectId;
        },
        error: (error: any) => {
          console.log('Subject GetId Error!', error);
        },
        complete: () => { }
      });
    }
  }

  onSubmit() {
    if (this.id) {
      this.update();
    } else {
      this.add();
    }
  }

  add() {

    var subject: Subject = this.form.value;
    subject.subjectId = this.id;

    this.subjectService.post(subject).subscribe({
      next: (response: Subject) => {
        console.log('Subject Saved!', response);
        //this.assuntos = response;
        this.router.navigateByUrl("/subjectlist");
      },
      error: (error: any) => {
        console.log('Subject error!', error);
      },
      complete: () => { }
    });
  }

  update() {

    var subject: Subject = this.form.value;
    subject.subjectId = this.id;

    this.subjectService.put(this.id, subject).subscribe({
      next: (response: Subject) => {
        console.log('Subject Update!', response);
        //this.assuntos = response;
        this.router.navigateByUrl("/subjectlist");
      },
      error: (error: any) => {
        console.log('Subject error!', error);
      },
      complete: () => { }
    });
  }

  // save(assunto: NgForm) {
  //   this.subjectService.post(assunto.value).subscribe({
  //     next: (response: Subject) => {
  //       console.log('Salvo!!===>', response);
  //       this.assuntos = response;
  //       this.router.navigateByUrl("/subjectlist")
  //     },
  //     error: (error: any) => {
  //       console.log('error===>', error);
  //     },
  //     complete: () => { }
  //   });
  // }
}
