<template>
  <div id="app">
    <Nav></Nav>
    <div class="margemPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Nav from './components/_nav/Nav'

export default {
  name: 'App',
  components: {
    Nav,
  }
}
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body{
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}
body, html {
  margin: 0;
  height: 100%;
}
.margemPrincipal {
  width: 50%;
  margin: auto;
}
#app {
  width: 100%;
}
.btn {
  background-color: blue;
  padding: 10px 20px;
  cursor: pointer;
  border: 1px solid #3e5252;
  color: white;
  font-weight: bold;
  border-radius: 20px;
  font-size: 1.3em;
}
.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}
table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}
table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: aquamarine;
  margin-bottom: 2px;
  color: #3e5252;
}
table thead th{
  background-color: aqua;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}
.colPequeno {
  width: 5%;
}
</style>
