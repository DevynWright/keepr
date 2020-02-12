<template>
  <div class="ActiveKeep container-fluid">
      <div class="row">
          <div class="col-12">
              {{activeKeep}}
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
    activeKeep(){
        return this.$store.state.activeKeep;
    }
}
}
</script>

<style>

</style>