<template>
  <div class="home container">
    <div class="row">
      <div class="col-12">
        <input type="text">
        <i class="fas fa-search"></i>
      </div>
    </div>
    <div class="row">
      <div class="col-3">
        <div class="card" style="width: 18rem;">
          <img class="card-img-top" src="" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text"></p>
            <a href="#" class="btn btn-primary">Go somewhere</a>
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
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  }
};
</script>
<style>
</style>