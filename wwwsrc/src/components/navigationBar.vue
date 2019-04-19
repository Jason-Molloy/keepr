<template>
  <div class="row container-fluid no-gutters">
    <div class="col-12">
      <nav class="navbar" fixed="top">
        <div class="d-flex justify-content-start">
          <a href="#" @click="goHome()">Keepry<i class="fas fa-home"></i></a>
        </div>
        <div class="d-flex justify-content-center">
          <router-link :to='{name: "vaults"}'>Vaults</router-link>
          <!-- <a href="#" @click="goToUserVaults()">Your Vaults<i class="fas fa-university"></i></a> -->
        </div>
        <div class="d-flex justify-content-end">
          <a href="#" @click="goToMyKeeps()">Your Keeps<i class="fas fa-folder"></i></a>
        </div>
      </nav>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'navigationBar',
    data() {
      return {
        loggedIn: false
      }
    },
    methods: {
      goToUserVaults() {
        console.log(this.$store.state.user.id);
        this.$store.dispatch("goToVaults");
      },
      goToMyKeeps() {
        this.$store.dispatch("getMyKeeps")
      },
      goHome() {
        this.$store.dispatch("goHome");
      },
    }
  }
</script>