import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Keeps from './views/Keeps.vue'
// @ts-ignore
import Keep from './views/Keep.vue'
// @ts-ignore
import VaultKeeps from './views/VaultKeeps.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/Keeps',
      name: 'keeps',
      component: Keeps
    },
    {
      path: '/Vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/Vaults/:vaultId',
      name: 'vaultKeeps',
      component: VaultKeeps
    },
    {
      path: '/Keeps/:keepId',
      name: 'keep',
      component: Keep
    }
  ]
})
