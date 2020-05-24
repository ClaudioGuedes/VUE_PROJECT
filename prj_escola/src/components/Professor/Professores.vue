<template>
  <div>
    <Titulo txtTitulo="Professores" />
    <div>
      <input type="text" placeholder="Nome do Professor" v-model="nome" 
      @keyup.enter="adicionarProfessor()">
      <button class="btn btnInput" @click="adicionarProfessor()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Indice</th>
        <th>Nome</th>
        <th>Qtd. Alunos</th>
        <th>Ações</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td>{{professor.professorId}}</td>
          <router-link :to="`/alunos/${professor.professorId}`" tag="td" style="cursor: pointer">
            {{professor.nome}}
          </router-link>
          <td>
            {{professor.qtdeAlunos}}
          </td>
          <td>
            <button class="btn" @click="removerProfessor(professor)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="professores.length == 0">
        <tr>
          <td colspan="4" style="text-align: center">
            <h5>Não há nenhum professor</h5>
          </td>
        </tr>
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
      titulo: 'Professor',
      nome: '',
      alunos: [],
      professores: []
    }
  },

  created() {
    this.$http
      .get('http://localhost:5000/api/aluno')
      .then(res => res.json())
      .then(
        (
          alunos => {
            this.alunos = alunos;
            this.carregarProfessores();
          }
        )
      );
  },

  props: {
  
  },

  methods: {
    adicionarProfessor() {
      let _professor = {
        nome: this.nome,
      }

      this.$http
        .post('http://localhost:5000/api/professor', _professor)
        .then(res => res.json())
        .then(retornoProfessor => {
          retornoProfessor.qtdeAlunos = 0;
          this.professores.push(retornoProfessor);
          this.nome = '';
          this.qtdeAlunos = 0;
        });
    },

    removerProfessor(professor){
      this.$http
        .delete(`http://localhost:5000/api/professor/${professor.professorId}`)
        .then(() => {
          let indice = this.professores.indexOf(professor);
          this.professores.splice(indice, 1);
        });
    },

    quantificarAlunos() {
      this.professores.forEach((professor, index) => {
        professor = {
          professorId: professor.professorId,
          nome: professor.nome,
          qtdeAlunos: this.alunos.filter(
            aluno => aluno.professor.professorId == professor.professorId
          ).length
        }
        this.professores[index] = professor;
      });
    },

    carregarAlunos() {
      this.$http
        .get('http://localhost:5000/api/aluno')
        .then(res => res.json())
        .then((alunos => this.alunos = alunos));
    },

    carregarProfessores() {
      this.$http
        .get('http://localhost:5000/api/professor')
        .then(res => res.json())
        .then(
          (
            professores => {
              this.professores = professores;
              this.quantificarAlunos();
            }
          )
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
