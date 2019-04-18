<template>
  <div class="col-12">
    <!--modal form to add vault(s)-->
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