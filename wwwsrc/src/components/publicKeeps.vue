<template>
  <div class="d-flex justify-content-center" style="margin-top: 80px;">
    <div class="card-columns" style="width:90%">
      <div v-for="keep in keeps" class="d-flex justify-content-center">
        <div class="col">
          <div class="card">
            <div class="container">
              <img class="card-img-top" :src="keep.img" @click="viewKeep(keep.id)">
              <div class="img-info bottom-left">Keeps: {{keep.keeps}}</div>
              <div class="img-info bottom-right">Views: {{keep.views}}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'publicKeeps',
    data() {
      return {

      }
    },
    computed: {
      keeps() {
        // console.log(this.$store.state.publicKeeps);
        return this.$store.state.publicKeeps.sort(() => Math.random());
      }
    },
    methods: {
      addKeep(id) {
        console.log(id)
      },
      viewKeep(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      }
    }
  }
</script>