<template>
  <div>
    <Titulo :txtTitulo="this.professorid != undefined ? 'Professor: ' + this.professor.nome : 'Todos os Alunos'" :btnVoltarVisivel="false"/>
    <div v-if="this.professorid != undefined">
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
          <router-link :to="`/alunodetalhe/${aluno.id}`" tag="td" style="cursor: pointer" >
            {{aluno.nome}} {{aluno.sobrenome}}
          </router-link>
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
import Titulo from '../_share/Titulo'
export default {
  components: {
    Titulo
  },
  data(){
    return {
      titulo: 'Aluno',
      professor: {},
      professorid: this.$route.params.profid,
      nome: '',
      alunos: []
    }
  },

  created() {
    var url = '';
    if (this.professorid) {
      this.carregarProfessor()
      url = `http://localhost:3000/alunos?professor.id=${this.professorid}`;
    } else {
     url = 'http://localhost:3000/alunos';
    }
    this.$http
      .get(url)
      .then(res => res.json())
      .then((alunos => this.alunos = alunos));     
  },

  props: {
  
  },
  methods: {
    adicionarAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: '',
        professor: {
          id: this.professor.id,
          nome: this.professor.nome,
          sobrenome: this.professor.sobrenome
        }
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
    },
    carregarProfessor() {
      this.$http
        .get(`http://localhost:3000/professores/${this.professorid}`)
        .then(res => res.json())
        .then((professor => this.professor= professor)
        );
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input {
    width: calc(100% - 195px);
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
