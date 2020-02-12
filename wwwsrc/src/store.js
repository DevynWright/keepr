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
    privateKeeps: []
  },
  mutations: {
    setPublicKeeps(state, keeps){
      state.publicKeeps = keeps
    },
    setPrivateKeeps(state, keeps){
      state.privateKeeps = keeps
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
      console.log("vaults", res.data);
      
    },
    async addKeep({commit, dispatch}, keep){
      let res = await api.post("keeps", keep);
      console.log("posting new keeps", res.data);
      
    },
    async addVault({commit, dispatch}, vault){
      let res = await api.post("vaults", vault);
      console.log("posting new vaults", res);
      
    }
  }
});
