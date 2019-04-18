<template>
  <div class="row d-flex justify-content-center">
    <div class="col-12 pop-up-modal">
      <!--modal for keeps - header - not sure?-->
      <form @submit.prevent="addKeep" id="modal">
        <div class="modal-content">
          <div class="modal-head text-center">
            <h3>Keepry</h3>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            </button>
          </div>
          <h5 class="modal-title">New Keep</h5>
          <!--modal body - insert form to add keep-->
          <!--modal footer-->
          <div class="d-flex justify-content-center">
            <button class="btn btn-success close-on-create" @click="submitKeep">Add</button>
          </div>
        </div>
      </form>
      <div class="col-12">
        <div class="text-center">
          <!--button to open modal and create a keep to add-->
        </div>
      </div>
    </div>
    <div class="home">
      <div class="d-flex justify-content-center">
        <div class="card-columns">
          <div v-for="keep in keeps" class="d-flex justify-content-around">
            <div class="col">
              <div class="card">
                <div class="container">
                  <img class="card-img-top" :src="keep.img" @click="viewKeep(keep.id)">
                  <div class="img-info bottom-left" <i class="fas fa-trash-alt" @click="deleteKeep(keep.id)"></i></div>
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