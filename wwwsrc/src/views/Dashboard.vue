<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <div class="col-12">
        <h1>create keep</h1>
        <form @submit.prevent="addKeep">
          <input v-model="newKeep.name" name="name" type="text" placeholder="name">
          <input v-model="newKeep.description" name="description" type="text" placeholder="description">
          <input v-model="newKeep.img" name="img" type="url" placeholder="image url">
          <input v-model="newKeep.isPrivate" name="isPrivate" type="checkbox">
          <label for="checkbox">Private: {{newKeep.isPrivate}}</label>
          <button>create keep</button>
        </form>
      </div>
      <div class="col-12">
        <h1>create vault</h1>
        <form @submit.prevent="addVault">
          <input v-model="newVault.name" name="name" type="text" placeholder="name">
          <input v-model="newVault.description" name="description" type="text" placeholder="description">
          <button>create vault</button>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        <h1>All My Keeps</h1>
        <ul>
          <li v-for="myKeep in myKeeps" :key="myKeep.Id">{{myKeep.name}}  
          <i @click="deleteKeep(myKeep)" class="fas fa-trash-alt"></i>
          <i @click="viewKeep(myKeep)" class="fas fa-eye"></i>
          </li>
        </ul>
      </div>
      <div class="col-6">
        <h1>Vaults</h1>
        <ul>
          <li v-for="vault in vaults" :key="vault.Id">{{vault.name}}  
          <i @click="deleteVault(vault)" class="fas fa-trash-alt"></i>
          <i @click="viewVault(vault)" class="fas fa-eye"></i>
          </li>
        </ul>
      </div>
    </div>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
export default {
  data() {
    return {
      newKeep:{
        name: "",
        description: "",
        img: "",
        isPrivate: false,
        views: 0,
        shares: 0,
        keeps: 0
      },
      newVault:{
        name: "",
        description: ""
      }
    }
  },
  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    vaults(){
      return this.$store.state.vaults;
    },
    myKeeps(){
      return this.$store.state.privateKeeps;
    }
  },
  methods: {
    addKeep(){
      let keep = {...this.newKeep};
      this.$store.dispatch("addKeep", keep);
      this.newKeep = {
        name: "",
        description: "",
        img: "",
        isPrivate: false,
        views: 0,
        shares: 0,
        keeps: 0
      }
    },
    addVault(){
      let vault = {...this.newVault};
      this.$store.dispatch("addVault", vault);
      this.newVault = {
        name: "",
        description: ""
      }
    },
    deleteKeep(myKeep){
      this.$store.dispatch("deleteKeep", myKeep)
    },
    deleteVault(vault){
      this.$store.dispatch("deleteVault", vault)
    },
    viewKeep(myKeep){
      this.$store.dispatch("setActiveKeep", myKeep);
      this.$router.push({path: '/keep'});
    },
    viewVault(vault){
      this.$store.commit("setActiveVault", vault);
      this.$router.push({path: '/vault'});
    }
  }

};
</script>

<style></style>
