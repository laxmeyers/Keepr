<template>
    <div class="mb-3 position-relative">
        <img :src="keep.img" class="img-fluid rounded selectable" alt="">
        <div class="position-absolute keep-title">
            <h5>{{ keep.name }}</h5>
        </div>
        <div class="position-absolute keep-creator">
            <img :src="keep.creator.picture" class="rounded-circle profile-img selectable" :title="keep.creator.name" alt="">
        </div>
    </div>
</template>


<script>

export default {
    props: { keep: { type: Object, required: true } },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.keep-title{
    color: white;
   bottom:8px;
   left: 10px;
}

.keep-creator{
    bottom: 8px;
    right: 10px;
    .profile-img{
        height: 6vh;
        width: 6vh;
    }
}
</style>