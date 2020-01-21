import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CursoComponent } from './curso/curso.component';
import { AlunoComponent } from './aluno/aluno.component';

const routes: Routes = [
  {path: 'curso', component:CursoComponent},
  {path: 'aluno', component:AlunoComponent},
  {path:'', redirectTo:'/', pathMatch:'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
