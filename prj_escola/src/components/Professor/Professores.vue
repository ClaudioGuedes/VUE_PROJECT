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
          <td>{{professor.id}}</td>
          <router-link :to="`/alunos/${professor.id}`" tag="td" style="cursor: pointer">
            {{professor.nome}}
          </router-link>
          <td>
            {{professor.qtdealunos}}
          </td>
          <td>
            <button class="btn" @click="removerProfessor(professor)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-if="professores.length == 0">
          Não há nenhum professor
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
      .get('http://localhost:3000/alunos')
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
        sobrenome: '',
        qtdealunos: 0
      }

      this.$http
        .post('http://localhost:3000/professores', _professor)
        .then(res => res.json())
        .then(retornoProfessor => {
          this.professores.push(retornoProfessor);
          this.nome = '';
          this.qtdealunos = 0;
        });
    },

    removerProfessor(professor){
      this.$http
        .delete(`http://localhost:3000/professores/${professor.id}`)
        .then(() => {
          let indice = this.professores.indexOf(professor);
          this.professores.splice(indice, 1);
        });
    },

    quantificarAlunos() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdealunos: this.alunos.filter(
            aluno => aluno.professor.id == professor.id
          ).length
        }
        this.professores[index] = professor;
      });
    },

    carregarAlunos() {
      this.$http
        .get('http://localhost:3000/alunos')
        .then(res => res.json())
        .then((alunos => this.alunos = alunos));
    },

    carregarProfessores() {
      this.$http
        .get('http://localhost:3000/professores')
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
