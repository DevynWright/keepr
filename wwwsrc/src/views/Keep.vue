<template>
    <div class="ActiveKeep container-fluid">
        <div class="row">
            <div class="col-12">
                <img :src="activeKeep.img" alt="">
            </div>
            <div class="col-12">
                <h1>{{activeKeep.description}}</h1>
            </div>
            <div class="col-12">
                <h1>Keeps:  {{activeKeep.keeps}}</h1>
                <h1>Views:  {{activeKeep.viewss}}</h1>
                <h1>shares:  {{activeKeep.sharess}}</h1>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    mounted(){
        
        },
    computed: {
        activeKeep(){
            return this.$store.state.activeKeep.data;
            
        }
    },
    methods: { 
        }
    
}
</script>

<style>

</style>