<template>
  <div class="ActiveVault container-fluid">
      <div class="row">
          <div class="col-12">
              {{activeVault}}
              <img src="" alt="">
          </div>
      </div>
      <div class="row"></div>
      <div class="row"></div>
  </div>
</template>

<script>
export default {
computed: {
    activeVault(){
        return this.$store.state.activeVault;
    }
}
}
</script>

<style>

</style>