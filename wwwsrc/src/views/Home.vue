<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>HOME</h1>
        <input type="text">
        <i class="fas fa-search"></i>
      </div>
    </div>
    <div id="cards" class="row">
      <div  v-for="keep in keeps" :key="keep.Id" class="col-sm-3">
        <div class="card" style="width: 18rem;">
          <img class="card-img-top" :src="keep.img" alt="Card image cap">
          <button class="btn btn-danger">x</button>
          <div class="card-body">
            <h5 class="card-title">k:{{keep.keeps}} s:{{keep.shares}} v:{{keep.views}}</h5>
            <p class="card-text">{{ keep.description }}</p>
            <a href="#" class="btn btn-primary">K</a>
            <a href="#" class="btn btn-primary">S</a>
            <a href="#" class="btn btn-primary">V</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps(){
      return this.$store.state.publicKeeps;
    }
  },
  mounted() {
      this.$store.dispatch("getPublicKeeps");
      console.log(this.$auth.user.sub,);
      
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

  }
};
</script>
<style>
#cards{
  display: flexbox;
  justify-content: space-between;
}
</style>