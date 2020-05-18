<template>
  <div>
    <Titulo txtTitulo="Aluno"/>
    <div>
      <input type="text" placeholder="Nome do Aluno" v-model="nome" 
      @keyup.enter="adicionarAluno()">
      <button class="btn btnInput" @click="adicionarAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Indice</th>
        <th>Nome</th>
        <th>Ações</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}}</td>
          <td>
            <button class="btn" @click="removerAluno(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="alunos.length == 0">
          Não há nenhum aluno
      </tfoot>      
    </table>
  </div>
</template>

<script>
import Titulo from '../share/Titulo'
export default {
  components: {
    Titulo
  },
  data(){
    return {
      titulo: 'Aluno',
      nome: '',
      alunos: []
    }
  },

  created() {
    this.$http
    .get('http://localhost:3000/alunos')
    .then(res => res.json())
    .then((alunos => this.alunos = alunos));
  },

  props: {
  
  },
  methods: {
    adicionarAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: ''
      }

      this.$http
        .post('http://localhost:3000/alunos', _aluno)
        .then(res => res.json())
        .then(retornoAuno => {
          this.alunos.push(retornoAuno);
          this.nome = '';
        });
    },
    removerAluno(aluno){
      this.$http
        .delete(`http://localhost:3000/alunos/${aluno.id}`)
        .then(() => {
          let indice = this.alunos.indexOf(aluno);
          this.alunos.splice(indice, 1);
        });
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input {
    border: 0px;
    padding: 20px;
    font-size: 1.3em;
    color: dimgray;
    display: inline;
  }
  .btnInput {
    width: 150px;
    border: 0px;
    padding: 20px;
    font-size: 1.3em;
    background-color: rgb(9, 4, 20);
  }
  .btnInput:hover {
    padding: 20px;
    margin: 0px;
    border: 0px;
  }
</style>
