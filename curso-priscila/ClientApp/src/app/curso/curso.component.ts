import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Curso } from '../curso';
import { FormBuilder, Validators } from '@angular/forms';
import { CursoService } from '../curso.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent implements OnInit {
  dataSaved = false;
  cursoForm: any;
  allCursos: Observable<Curso[]>;
  cursoIdUpdate = null;
  message = null;
  constructor(private formbulider: FormBuilder, private cursoService: CursoService) { }
  ngOnInit() {
    this.cursoForm = this.formbulider.group({
      Nome: ['', [Validators.required]],
      Data: ['', [Validators.required]]
    });
    this.loadAllCursos();
  }
  loadAllCursos() {
    this.allCursos = this.cursoService.getAllCursos();
  }
  onFormSubmit() {
    this.dataSaved = false;
    const curso = this.cursoForm.value;
    this.CreateCurso(curso);
    this.cursoForm.reset();
  }
  CreateCurso(curso: Curso) {
    if (this.cursoIdUpdate == null) {
      this.cursoService.createCurso(curso).subscribe(
        () => {
          console.log("criado curso");
          this.dataSaved = true;
          this.message = 'Curso salvo com sucesso';
          this.loadAllCursos();
          this.cursoIdUpdate = null;
          this.cursoForm.reset();
        }
      );
    } else {
      curso.cursoId = this.cursoIdUpdate;
      this.cursoService.updateCurso(this.cursoIdUpdate, curso).subscribe(() => {
        this.dataSaved = true;
        this.message = 'Curso atualizado com sucesso';
        this.loadAllCursos();
        this.cursoIdUpdate = null;
        this.cursoForm.reset();
      });
    }
  }
  loadCursoToEdit(cursoid: string) {
    this.cursoService.getCursoById(cursoid).subscribe(curso => {
      this.message = null;
      this.dataSaved = false;
      this.cursoIdUpdate = curso.cursoId;
      this.cursoForm.controls['Nome'].setValue(curso.nome);
      this.cursoForm.controls['Data'].setValue(curso.data);
    });
  }
  deleteCurso(cursoid: string) {
    if (confirm("Deseja realmente deletar este curso ?")) {
      this.cursoService.deleteCursoById(cursoid).subscribe(() => {
        this.dataSaved = true;
        this.message = 'Registro deletado com sucesso';
        this.loadAllCursos();
        this.cursoIdUpdate = null;
        this.cursoForm.reset();
      });
    }
  }
  resetForm() {
    this.cursoForm.reset();
    this.message = null;
    this.dataSaved = false;
  }
}
