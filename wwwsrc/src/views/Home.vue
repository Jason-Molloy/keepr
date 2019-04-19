<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <publicKeeps></publicKeeps>
  </div>
</template>

<script>
  import publicKeeps from '@/components/publicKeeps.vue'
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    components: {
      publicKeeps
    }
  };
</script>