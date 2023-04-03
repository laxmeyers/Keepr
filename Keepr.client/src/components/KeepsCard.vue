<template>
    <div class="mb-3 position-relative">
        <img :src="keep.img" class="img-fluid rounded selectable elevation-5" alt="">
        <div class="position-absolute keep-title">
            <h5>{{ keep.name }}</h5>
        </div>
        <div class="position-absolute keep-creator">
            <img :src="keep.creator.picture" class="rounded-circle profile-img selectable" :title="keep.creator.name"
                alt="">
        </div>
        <div v-if="account.id == keep.creatorId"
            class="position-absolute delete-button bg-danger rounded-circle text-center selectable" title="delete keep">
            <i class="mdi mdi-close"></i>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';


export default {
    props: { keep: { type: Object, required: true } },
    setup() {
        return {
            account: computed(() => AppState.account)
        }
    }
}
</script>


<style lang="scss" scoped>
.keep-title {
    color: white;
    bottom: 8px;
    left: 10px;
    text-shadow: 2px 1.5px 2px black;
}

.keep-creator {
    bottom: 8px;
    right: 10px;

    .profile-img {
        height: 6vh;
        width: 6vh;
    }
}

.delete-button {
    top: 1px;
    right: 0px;
    height: 3vh;
    width: 3vh;
}</style>