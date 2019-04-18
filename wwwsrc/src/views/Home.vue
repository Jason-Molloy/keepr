<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <public></public>
  </div>
</template>

<script>
  import public from '@/components/public.vue'
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    components: {
      public
    }
  };
</script>