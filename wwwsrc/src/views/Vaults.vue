<template>
  <div class="row d-flex justify-content-center">
    <div class="col-12">
      <!--modal form to add vault(s)-->
      <form @submit.prevent="addVault" id="modal">
        <div class="modal fade" id="modalForm" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
          <div class="modal-dialog d-flex justify-content-center" role="document">
            <div class="modal-content">
              <div class="modal-header text-center">
                <h3>Keepery</h3>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <h5 class="modal-title">New Vault</h5>
              <div class="modal-body">
                <div class="md-form">
                  <input type="text" v-model="newVault.name" id="defaultForm-email" class="form-control validate">
                  <label data-error="required" data-success="approved" for="defaultForm-email">Vault Name</label>
                </div>
                <div class="md-form">
                  <input type="text" v-model="newVault.description" id="defaultForm-email"
                    class="form-control validate">
                  <label data-error="required" data-success="approved" for="defaultForm-email">Vault Description</label>
                </div>
              </div>
              <div class="d-flex justify-content-center">
                <button class="btn btn-primary" type="submit">Create</button>
              </div>
            </div>
          </div>
        </div>
      </form>
      <div class="text-center">
        <a href="" class="btn btn-success" data-toggle="modal" data-target="#modalForm">Create a Vault</a>
      </div>
    </div>
    <!--End of modal-->
    <table class="table table-bordered">
      <thead>
        <tr>
          <th scope="col">Vault Name</th>
          <th scope="col">Open Vault</th>
          <th scope="col">Delete Vault</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="vault in Vaults">
          <td>{{vault.name}}</td>
          <td><i class="fas fa-trash-alt" @click="deleteVault(vault.id)"></i></td>
          <td><i class="fas fa-folder-open" @click="seeVaultKeeps(vault.id)">Open Vault</i></td>
        </tr>
      </tbody>
    </table>
  </div>
  </div>
</template>

<script>
  export default {
    name: 'vaults',
    data() {
      return {
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      Vaults() {
        return this.$store.state.activeUserVaults;
      }
    },
    mounted() {
      this.$store.dispatch('getUsersVaults');
    },
    methods: {
      seeVaultKeeps(vaultid) {
        this.$store.dispatch('seeVaultKeeps', vaultid);
        this.$store.dispatch('getThisVault', vaultid);
      },
      addVault() {
        this.$store.dispatch('addVault', this.newVault);
        this.$router.push({ name: 'vaults' })
      },
      deleteVault(vaultid) {
        this.$store.dispatch('deleteVault', vaultid);
      }
    }
  }

</script>