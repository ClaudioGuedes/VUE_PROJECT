import Vue from 'vue';
import Router from 'vue-router';

import Alunos from './components/Aluno/Alunos.vue';
import AlunoDetalhe from './components/Aluno/AlunoDetalhe';
import Professores from './components/Professor/Professores';
import Sobre from './components/Sobre/Sobre';

Vue.use(Router);

export default new Router (
  {
    routes: [
      {
        path: '/Professores',
        nome: 'professores',
        component: Professores
      },
      {
        path: '/TodosAlunos',
        nome: 'alunos',
        component: Alunos
      },
      {
        path: '/Alunos/:profid',
        nome: 'alunos',
        component: Alunos
      },
      {
        path: '/alunoDetalhe/:id',
        nome: 'AlunoDetalhe',
        component: AlunoDetalhe
      },
      {
        path: '/Sobre',
        nome: 'sobre',
        component: Sobre
      }  
    ]  
  }
);