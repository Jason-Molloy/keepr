<template>
  <div class="row d-flex justify-content-center">
    <div class="vkHome">
      <div class="col-12">
        <div style="text-align: left" class="vkHomeInfo"> Title: {{ActiveVaultName.name}}</div>
        <div style="text-align: left" class="vkHomeInfo">Description: {{ActiveVaultName.description}}</div>
      </div>
      <div class="d-flex justify-content-center">
        <div class="card-columns">
          <div v-for="vaultkeep in VaultKeeps" class="d-flex justify-content-center">
            <div class="col">
              <div class="card">
                <div class="container">
                  <img class="card-img-top" :src="vaultkeep.img" alt="Card image cap" @click="viewKeep(vaultkeep.id)">
                  <div class="img-info bottom-left"><i class="fas fa-trash-alt"
                      @click="deleteVaultKeep(vaultkeep.id)"></i></div>
                </div>
                </ul>
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
    name: 'vaultkeeps',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)
    },
    computed: {
      VaultKeeps() {
        return this.$store.state.activeVaultKeeps;
      },
      ActiveVaultName() {
        return this.$store.state.activeUserVaults.find(v => v.id == this.ActiveVault) || {}
      },
      ActiveVault() {
        return this.$store.state.ActiveVault;
      }
    },
    methods: {
      deleteVaultKeep(keepId) {
        this.$store.dipatch('deleteVaultKeep', { KeepId, vaultId: this.ActiveVault })
      },
      goToKeepView(keepid) {
        this.$router.push({ name: 'keep', params: { keepid: keepid } })
      }
    }
  }
</script>

<style>

</style>