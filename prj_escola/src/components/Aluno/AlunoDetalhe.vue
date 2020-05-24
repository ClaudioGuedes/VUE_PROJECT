<template>
  <div v-if="!carregando">
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
            <label>{{aluno.alunoId}}</label>
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
            <label v-if="visualizacao" >{{aluno.dtNascimento}}</label>
            <input v-else v-model="aluno.dtNascimento" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizacao" >{{aluno.professor.nome}}</label>
            <select v-else v-model="aluno.professor.professorId">
              <option v-for="(item, index) in professores" 
                :key="index" :value="item.professorId">
                {{item.nome}}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!this.visualizacao">
        <button class="btn btnSalvar" @click="salvar(aluno)">
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
        visualizacao: true,
        carregando: true
      }
    },
    created() {
      this.carregarProfessor();
    }, 
    methods: {
      carregarAluno(){
        var url = `http://localhost:5000/api/aluno/${this.idParametro}`;
        this.$http
          .get(url)
          .then(res => res.json())
          .then(retorno => {
            this.aluno = retorno;
            this.carregando = false;            
          });
        },
      carregarProfessor(){
        var url = `http://localhost:5000/api/professor`;
        this.$http
          .get(url)
          .then(res => res.json())
          .then(retorno => {
            this.professores = retorno;
            this.carregarAluno();
          });
      },
      editar() {
        this.visualizacao = !this.visualizacao;
      },
      salvar(_aluno) {
        let _alunoAlterado = {
          alunoId: _aluno.alunoId,
          nome: _aluno.nome,
          sobrenome: _aluno.sobrenome,
          dtnascimento: _aluno.dtNascimento,
          professorId: _aluno.professor.professorId
        };
        var url = `http://localhost:5000/api/aluno/${_alunoAlterado.alunoId}`;
        console.log(_alunoAlterado);
        this.$http
          .put(url, _alunoAlterado).then(resp => resp.json()
          ).then(alunoResp => this.aluno = alunoResp)
          .then(() => this.visualizacao = true);
        //this.visualizacao = !this.visualizacao;
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