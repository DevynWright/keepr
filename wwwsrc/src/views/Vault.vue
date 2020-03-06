<template>
  <div id="bg" :style="{ 'background-image': 'url(https://yiworks.com/wp-content/uploads/2016/11/Cool-Light-Grey-background-fantastic-imago-creative-studio-video-production.jpg)' }" class="ActiveVault container-fluid">
      <div class="row">
          <div class="col-12">
              <h1>{{activeVault.name}}</h1>
              <button @click="getKeepsFromVaults">get</button>
              <ul>
                  <li v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">{{vaultKeep.name}}<i @click="deleteVK(vaultKeep)" class="fas fa-trash-alt"></i></li>
              </ul>
          </div>
      </div>
      <div class="row"></div>
      <div class="row"></div>
  </div>
</template>

<script>
export default {
    data(){
        return {
            vk: {
                keepId: 0,
                vaultId: 0
            }
        }
    },
computed: {
    activeVault(){
        return this.$store.state.activeVault;
    },
    vaultKeeps(){
        return this.$store.state.vaultKeeps;
    }
},
methods: {
    getKeepsFromVaults(){
        var vaultId = this.$store.state.activeVault.id;
        console.log("vaultId for getting keeps", vaultId);
        this.$store.dispatch("getKeepsFromVaults", vaultId);
    },
    deleteVK(vaultKeep){
        var vaultId = this.$store.state.activeVault.id;
        this.vk.keepId = vaultKeep.id;
        this.vk.vaultId = vaultId;
        this.$store.dispatch("deleteVK", this.vk)
        
        console.log("what were removing", this.vk);
        
    }
}
}
</script>

<style>

</style>