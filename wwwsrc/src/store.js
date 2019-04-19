import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: [],
    activeUserKeeps: [],
    ActiveKeep: {},
    ActiveVault: {},
    activeUserVaults: {},
    activeVaultKeeps: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps
    },
    setAllUserKeeps(state, activeKeeps) {
      state.activeUserKeeps = activeKeeps;
    },
    setActiveKeep(state, ActiveKeep) {
      state.ActiveKeep = ActiveKeep
    },
    setUserVaults(state, activeUserVaults) {
      state.activeUserVaults = activeUserVaults
    },
    setActiveVaultKeeps(state, activeVaultKeeps) {
      state.activeVaultKeeps = activeVaultKeeps
    },
    setActiveVault(state, activeVault) {
      state.ActiveVault = activeVault
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    //get public keeps
    getPublicKeeps({ commit, dispatch }) {
      api.get('/keeps/')
        .then(res => {
          commit("setPublicKeeps", res.data)
        })
        .catch(err => console.log('Cannot get public keeps'))
    },
    getUserVaults({ commit, dispatch }) {
      api.get('/vaults/')
        .then(res => {
          commit("setUserVaults", res.data)
        })
        .catch(err => console.log('Cannot get vaults'))
    },
    goToVaults() {
      router.push({ name: 'vaults' })
    },
    goHome() {
      router.push({ name: 'home' })
    },
    goLogin() {
      router.push({ name: 'login' })
    },
    getVaultKeeps({ commit, dispatch }, vaultid) {
      api.get('/vaultKeeps/' + vaultid)
        .then(res => {
          commit("setActiveVaultKeeps", res.data)
        })
      router.push({ name: 'vaultKeeps', params: { vaultid: vaultid } })
    },
    getMyKeeps({ commit }) {
      api.get('/keeps/user')
        .then(res => {
          commit("setAllUserKeeps", res.data)
        })
      router.push({ name: 'keeps' })
    },
    addKeep({ commit, dispatch }, payload) {
      api.post('/keeps/', payload)
        .then(res => {
          dispatch('getUserKeeps')
        })
    },
    addVault({ commit, dispatch }, payload) {
      api.post('/vaults/', payload)
        .then(res => {
          dispatch('getUserVaults')
        })
    },
    deleteKeep({ commit, dispatch }, keepid) {
      api.delete('/keeps/' + keepid)
        .then(res => {
          console.log('Keep was deleted')
          dispatch('getMyKeeps')
        })
    },
    deleteVault({ commit, dispatch }, vaultid) {
      api.delete('/vaults/' + vaultid)
        .then(res => {
          console.log('Vault was deleted')
        })
    },
    deleteVaultKeep({ commit, dispatch }, vaultkeep) {
      api.delete('/keeps/' + vaultkeep)
        .then(res => {
          console.log('VaultKeep was deleted')
        })
    },
    getUsersKeeps({ commit, dispatch }) {
      api.get('/keeps/user')
        .then(res => {
          commit("setAllUserKeeps", res.data)
        })
    },
    getSelectedVault({ commit, dispatch }, payload) {
      commit("setActiveVault", payload)
    },
    editKeep({ commit, dispatch }, payload) {
      api.put('/keeps/', payload)
        .then(res => {
          console.log('edited')
        })
    },
    postVaultKeep({ commit, dispatch }, payload) {
      api.post('/vaultkeeps', payload)
        .then(res => {
          console.log("vaultkeep has been added")
          dispatch('getVaultKeeps', payload.vaultId)
        })
    }
  }
})
