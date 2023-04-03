<template>
    <div v-if="!vault.isPrivate || account?.id == vault.creatorId " class="my-2 position-relative">
        <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}">
            <img :src="vault.img" class="img-fluid rounded" alt="">
        </router-link>
        <div class="position-absolute vault-title">
            <h1 class="fs-5">{{ vault.name }}</h1>
        </div>
        <div class="position-absolute locked" v-if="vault.isPrivate">
            <i class="mdi mdi-lock"></i>
        </div>
    </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState';

export default {
    props:{vault: {type:Object, required: true}},
    setup(){
        return {
            account: computed(() => AppState.account)
        }
    }
}
</script>


<style lang="scss" scoped>
.vault-title{
    bottom: 0px;
    left: 10px;
    color: white;
    text-shadow: 2px 2px 3px black;
}
.locked{
    top: 0px;
    right: 5px;
    color: red;
}
</style>