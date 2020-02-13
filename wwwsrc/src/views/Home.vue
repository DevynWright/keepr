<template>
  <div id="bg" :style="{ 'background-image': 'url(https://yiworks.com/wp-content/uploads/2016/11/Cool-Light-Grey-background-fantastic-imago-creative-studio-video-production.jpg)' }" class="home container-fluid">
    <div class="row">
      <div id="search" class="col-12" style="text-align: center">
        <input id="searchbar" type="text">
        <i class="fas fa-search"></i>
      </div>
    </div>
    <div id="cards" class="row">
      <div  v-for="keep in keeps" :key="keep.Id" class="col-sm-3">
        <div id="card" class="card" style="width: 18rem;">
          <img class="card-img-top" :src="keep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">k:{{keep.keeps}} s:{{keep.shares}} v:{{keep.views}}</h5>
            <p class="card-text">{{ keep.description }}</p>
            <a class="btn btn-transparent"><i class="fab fa-korvue"></i></a>
            <a href="#" class="btn btn-transparent"><i @click="deleteKeep(keep)" class="fas fa-trash-alt"></i></a>
            <a @click="viewKeep(keep)" class="btn btn-transparent"><i class="fas fa-eye"></i></a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  data(){
    return {
      newVaultKeep:{
        keepId: "",
        vaultId: ""
      }
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps(){
      return this.$store.state.publicKeeps;
    },
    vaults(){
      return this.$store.state.vaults;
    }
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
    console.log(this.$auth.user.sub,);
    console.log(this.$store.state.vaults);
      
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    deleteKeep(keep){
      this.$store.dispatch("deleteKeep", keep);
    },
    viewKeep(keep){
      this.$store.dispatch("setActiveKeep", keep);
      this.$router.push({path: '/keep'});
    },
  }
};
</script>
<style>
#bg{
  background-size: cover;
  height: 100vh;
}
#search{
  height: 10vh;
  padding: 40px 40px;
}
#searchbar{
  height: 4vh;
  width: 70vw;
}
#cards{
  display: flexbox;
  justify-content: space-between;
}
#card{
  border-radius: 5%;
}
</style>