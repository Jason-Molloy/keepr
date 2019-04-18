<template>
  <div class="row">
    <div class="col-12 d-flex justify-content-center">
      <div class="card">
        <div class="container">
          <img class="card-img-top" :src="keep.img">
          <div class="img-info bottom-left">{{keep.name}}</div>
          <div class="img-info bottom-right">{{keep.description}}</div>
        </div>
        <li class="list-group-item bg-warning text-center">
          Add to your vaults
        </li>
        <div class="d-flex justify-content-center">
          <div v-for="vault in vaults" class="mb-2 mt-2">
            <li class="list-group-item">
              {{vault.name}}
              <i class="fas fa-folder-plus" @click="createVaultKeep(vault.id)"></i>
            </li>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'keep',
    props: ["keepid"],
    data() {
      displayVaults: false
      return {}
    },
    computed: {
      keep() {
        return this.$store.state.publicKeeps.find(k => k.id == this.keepId) || {}
      },
      keeps() {
        return this.$store.state.publicKeeps
      },
      vaults() {
        return this.$store.state.activeUserVaults
      }
    },
    mounted() {
      this.editKeepViews()
    },
    methods: {
      createVaultKeep(vaultId) {
        let payload = { vaultId, keepId: this.keep.id }
        this.$store.dispatch('addVaultKeep', payload)
      },
      editKeepViews() {
        let payload =
        {
          name: this.keep.name,
          description: this.keep.description,
          id: this.keep.id,
          img: this.keep.img,
          Private: this.keep.Private,
          views: this.keep.views + 1,
          keeps: this.keep.keeps
        }
        this.$store.dispatch("editKeep", payload)
      },
      countKeeps() {
        let payload =
        {
          name: this.keep.name,
          description: this.keep.description,
          id: this.keep.id,
          img: this.keep.img,
          Private: this.keep.Private,
          views: this.keep.views,
          keeps: this.keep.keeps + 1
        }
        this.$store.dispatch("editKeep", payload)
      }
    }
  }
</script>

<style>

</style>