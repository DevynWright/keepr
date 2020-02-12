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
          <i @click="setActive(myKeep)" type="button" data-toggle="modal" data-target="#myModal" class="fab fa-korvue"></i>
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
    <div class="modal fade" id="myModal">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title">Where would you like to keep this?</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        <div class="modal-body">
            <select id="options" name="vault">
              <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
            </select>
            <button @click="cvk">submit</button>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
        </div>
      </div>
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
      },
      newVaultKeep:{
        keepId: "",
        vaultId: ""
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
    },
    setActive(myKeep){
      this.$store.commit("setActiveKeep", myKeep);
    },
    cvk(){
      var o = document.getElementById("options");
      var vaultId = o.options[o.selectedIndex].value;
      var id = parseInt(vaultId, 10)
      this.newVaultKeep.keepId = this.$store.state.activeKeep.id;
      this.newVaultKeep.vaultId = id;
      console.log("newVaultKeep vaultId", this.newVaultKeep);
      this.$store.dispatch("addVaultKeep", this.newVaultKeep)
    }
  }

};
</script>

<style></style>
