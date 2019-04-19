<template>
  <div class="row d-flex justify-content-center">
    <!-- <div class="col-12 pop-up-modal"> -->
    <!--modal for keeps - header - not sure?-->
    <h1>Keepry</h1>
    <form @submit.prevent="addKeep">
      <h5>New Keep</h5>
      <div class="md-form">
        <input type="text" v-model="newKeep.name" id="formOne" class="form-control validate">
        <label data-error="required" data-success="approved" for="formOne">Keep Name</label>
      </div>
      <div class="md-form">
        <input type="text" v-model="newKeep.img" id="formTwo" class="form-control validate">
        <label data-error="required" data-success="approved" for="formTwo">Image link(address)</label>
      </div>
      <div class="md-form">
        <input type="text" v-model="newKeep.description" id="formTwo" class="form-control validate">
        <label data-error="required" data-success="approved" for="formTwo">Description</label>
      </div>
      <div class="Col-12 d-flex justify-content-center mt-3">
        <div class="card d-flex justify-content-center">
          <p>Private</p>
          <input type="checkbox" id="checkbox" v-model="newKeep.Private">
          <label for="checkbox"></label>
        </div>
      </div>

      <!--modal footer-->
      <div class="d-flex justify-content-center">
        <button class="btn btn-success close-on-create" type="submit">Add</button>
      </div>
    </form>

    <div class="home">
      <div class="d-flex justify-content-center">
        <div class="card-columns">
          <div v-for="keep in keeps" class="d-flex justify-content-around">
            <div class="col">
              <div class="card">
                <div class="container">
                  <img class="card-img-top" :src="keep.img" @click="viewKeep(keep.id)">
                  <div class="img-info bottom-left">
                    <button class='btn btn-danger' @click='deleteKeep(keep.id)'>Delete</button>
                  </div>
                  </li>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'keeps',
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          Private: false
        }
      }
    },
    computed: {
      keeps() {
        return this.$store.state.activeUserKeeps
      }
    },
    mounted() {
      this.$store.dispatch('getUsersKeeps');
    },
    methods: {
      viewKeep(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      },
      addKeep() {
        if (this.newKeep.Private) {
          this.newKeep.Private = 1
        } else {
          this.newKeep.Private = 0
        }
        this.$store.dispatch('addKeep', this.newKeep);
      },
      deleteKeep(keepid) {
        this.$store.dispatch('deleteKeep', keepid)
      }
    }
  }
</script>

<style>

</style>