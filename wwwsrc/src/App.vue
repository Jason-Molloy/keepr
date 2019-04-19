<template>
  <div id="app">
    <navigation-bar></navigation-bar>
    <div style="margin-top: 55px;"></div>
    <router-view />
  </div>
</template>

<script>
  import navigationBar from '@/components/navigationBar.vue'

  export default {
    name: 'app',
    mounted() {
      this.$store.dispatch("authenticate");
      this.$store.dispatch("getPublicKeeps");
    },
    components: {
      navigationBar
    }
  }

</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>