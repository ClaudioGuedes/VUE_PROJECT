<template>
  <div class="barraTopo">
      <Nav class="margemPrincipal">
        <router-link to="/professores">Professores</router-link>
        <router-link to="/todosalunos">Alunos</router-link>
        <router-link to="/Sobre">Sobre</router-link>      
      </Nav>
  </div>
</template>

<script>
  export default {
    
  }
</script>

<style scoped>
.barraTopo {
  background-color: rgb(230, 230, 230);
}

nav {
  padding: 20px 20px 20px 0px;
}

nav a {
  padding: 0px;
  text-decoration: none;
  background-color: white;
  border-radius: 3px;
  color: rgb(0, 110, 255);
  margin-right: 15px;
}

nav .router-link-active {
  background-color: rgb(160, 160, 230);
  color: white;
}
</style>