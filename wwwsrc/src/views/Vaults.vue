<template>
  <div class="row d-flex justify-content-center">
    <div class="col-12">
      <!--modal form to add vault(s)-->
      <form @submit.prevent="addVault" id="modal">
        <h5 class="modal-title">New Vault</h5>
        <div class="modal-body">
          <div class="md-form">
            <input type="text" v-model="newVault.name" id="defaultForm-email" class="form-control validate">
            <label data-error="required" data-success="approved" for="defaultForm-email">Vault Name</label>
          </div>
          <div class="md-form">
            <input type="text" v-model="newVault.description" id="defaultForm-email" class="form-control validate">
            <label data-error="required" data-success="approved" for="defaultForm-email">Vault Description</label>
          </div>
        </div>
        <div class="d-flex justify-content-center">
          <button class="btn btn-primary" type="submit">Create</button>
        </div>
      </form>
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
          <td><button @click="deleteVault(vault.id)">delete</button></td>
          <td>
            <router-link :to="{name: 'vaultKeeps', params:{vaultId: vault.id}}">
              <i class="fas fa-folder-open">Open Vault</i>
            </router-link>
          </td>
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
      this.$store.dispatch('getUserVaults');
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