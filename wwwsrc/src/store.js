import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost") ? "https://localhost:5001/" : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    privateKeeps: [],
    vaults: [],
    activeKeep: {},
    activeVault: {}

  },
  mutations: {
    setPublicKeeps(state, keeps){
      state.publicKeeps = keeps;
    },
    setPrivateKeeps(state, keeps){
      state.privateKeeps = keeps;
    },
    setVaults(state, vaults){
      state.vaults = vaults;
    },
    setActiveKeep(state, keep){
      state.activeKeep = keep;
      console.log("active keep from state", this.state.activeKeep);
    },
    setActiveVault(state, vault){
      state.activeVault = vault;
      console.log("active keep from state", this.state.activeVault);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({commit, dispatch}){
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
      console.log(res.data);
    },
    async getMyKeeps({commit, dispatch}){
      let res = await api.get("keeps/myKeeps");
      commit("setPrivateKeeps", res.data);
      console.log("privatekeeps", this.state.privateKeeps);
    },
    async getVaults({commit, dispatch}){
      let res = await api.get("vaults");
      commit("setVaults", res.data);
      console.log("vaults", this.state.vaults);
      
    },
    async addKeep({commit, dispatch}, keep){
      let res = await api.post("keeps", keep);
      dispatch("getPublicKeeps");
      dispatch("getMyKeeps");
      console.log("posting new keeps", res.data);
      
    },
    async addVault({commit, dispatch}, vault){
      let res = await api.post("vaults", vault);
      dispatch("getVaults");
      console.log("posting new vaults", res);
    },
    async addVaultKeep({commit, dispatch}, vaultKeep){
      let res = await api.post("vaultkeeps", vaultKeep);
      console.log("posting new vaultkeeps", vaultKeep);
    },
    async deleteKeep({commit, dispatch}, keep){
      let res = await api.delete("keeps/" + keep.id);
      dispatch("getPublicKeeps");
      dispatch("getMyKeeps");
      console.log("keep deleted", res);
    },
    async deleteVault({commit, dispatch}, vault){
      let res = await api.delete("vaults/" + vault.id);
      dispatch("getVaults");
      console.log("keep deleted", res);
    },
    async setActiveKeep({commit, dispatch}, keep){
      let res = await api.get("keeps/" + keep.id);
      commit("setActiveKeep", res);
    }
  }
});
