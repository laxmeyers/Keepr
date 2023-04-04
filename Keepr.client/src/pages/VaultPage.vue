<template>
    <div class="container my-3">
        <div class="row justify-content-end position-absolute delete-vault" v-if="account.id == vault.creatorId">
            <div class="col-1">
                <i class="mdi mdi-delete text-danger selectable fs-5" title="Delete Vault" @click="DeleteVault(vault.id)"></i>
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center">
                <img :src="vault.img" class="rounded elevation-1 img-fluid" alt="">
            </div>
            <div class="col-12 d-flex justify-content-center my-3">
                <div class="bg-secondary rounded-pill text-center w-25">
                    <h1 class=" fs-2">{{keeps.length}} KEEPS</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-12 mb-3">
                    <h2>Keeps</h2>
                </div>
                <div class="bricks">
                    <div v-for="k in keeps">
                        <KeepsCard :keep="k" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, onMounted, onUnmounted, popScopeId, watchEffect } from 'vue';
import { AppState } from '../AppState';
import { useRoute, useRouter } from 'vue-router';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';
import { keepsService } from '../services/KeepsService';
import { router } from '../router';

export default {
    setup() {
        const route = useRoute();
        const router = useRouter();
        async function GetVault() {
            try {
                const vaultId = route.params.vaultId
                await vaultsService.getVault(vaultId)
            } catch (error) {
                Pop.error(error, '[getting vault]')
                router.push({name:'Home'})
            }
        }

        async function GetKeeps() {
            try {
                const vaultId = route.params.vaultId
                await keepsService.GetVaultKeeps(vaultId)
            } catch (error) {
                Pop.error(error, '[Getting keeps]')
            }
        }
        watchEffect(() => {
            if (route.params.vaultId) {
                GetVault();
                GetKeeps();
            }
        })
        onUnmounted(() => {
            AppState.activeVault = {}
        })
        return {
            vault: computed(() => AppState.activeVault),
            keeps: computed(() => AppState.keeps),
            account: computed(() => AppState.account),

            async DeleteVault(vaultId) {
                try {
                    if (await Pop.confirm('Are you sure?')) {
                        await vaultsService.DeleteVault(vaultId)
                        Pop.success('Vault was deleted.')
                        router.push({name:'Home'})
                    }
                } catch (error) {
                    Pop.error(error,'[deleting vault]')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.bricks {
  columns: 250px;
  column-gap: 1em;
}

.delete-vault{
    right: 50px;
}
</style>