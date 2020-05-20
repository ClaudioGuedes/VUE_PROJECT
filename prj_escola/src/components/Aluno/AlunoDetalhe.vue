<template>
  <div>
    <div>
      <Titulo :txtTitulo="`Aluno: ${aluno.nome}`" :btnVoltarVisivel="!this.visualizacao">
        <button v-show="this.visualizacao" class="btn btnEditar" @click="editar()">Editar</button>
      </Titulo>
    </div>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizacao" >{{aluno.nome}}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizacao" >{{aluno.sobrenome}}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="visualizacao" >{{aluno.dtnascimento}}</label>
            <input v-else v-model="aluno.dtnascimento" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizacao" >{{aluno.professor.nome}}</label>
            <select v-else v-model="aluno.professor">
              <option v-for="(item, index) in this.professores" 
                :key="index" v-bind:value="item">
                {{item.nome}}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!this.visualizacao">
        <button class="btn btnSalvar" @click="salvar()">
          Salvar
        </button>
        <button class="btn btnCancelar" @click="cancelar()">
          Cancelar
        </button>
      </div>
    </div>
  </div>
</template>

<script>
  import Titulo from '../_share/Titulo'
  export default {
    components: {
      Titulo
    },
    data() {
      return {
        aluno: {},
        professores: [],
        idParametro: this.$route.params.id,
        visualizacao: true
      }
    },
    created() {
      var url = `http://localhost:3000/alunos/${this.idParametro}`;
      this.$http
        .get(url)
        .then(res => res.json())
        .then((retorno => this.aluno = retorno));

      this.$http
        .get(`http://localhost:3000/professores`)
        .then(res => res.json())
        .then((retorno => this.professores = retorno)
        );
    }, 
    methods: {
      editar() {
        this.visualizacao = !this.visualizacao;
      },
      salvar() {
        let _aluno = {
          id: this.aluno.id,
          nome: this.aluno.nome,
          sobrenome: this.aluno.sobrenome,
          dtnascimento: this.aluno.dtnascimento,
          professor: this.aluno.professor
        };
        this.$http
          .put(`http://localhost:3000/alunos/${this.aluno.id}`, _aluno);
        this.visualizacao = !this.visualizacao;
      },
      cancelar() {
        this.visualizacao = !this.visualizacao;
      }
    },
  }
</script>

<style scoped>
  .btnEditar {
    float: right;
    background-color: rgb(24, 70, 168);
  }
  .btnSalvar {
    float: right;
    background-color: rgb(11, 100, 56);
  }
  .btnCancelar {
    float: right;
    background-color: rgb(216, 197, 29);
  }

  .colPequeno {
    width: 20%;
    text-align: right;
    background-color: aqua;
    font-weight: bold;
  }

  input, select {
    margin: 0px;
    padding: 5px 10px;
    font-size: 0.9em;
    font-family: Montserrat;
    border-radius: 5px;
    border: 1px solid silver;
    background-color: rgb(245, 245, 245);
    width: 95%;
  }

  select {
    height: 38px;
    width: 100%;
  }
</style>