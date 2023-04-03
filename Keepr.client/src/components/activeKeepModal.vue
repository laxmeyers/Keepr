<template>
    <button class="btn-close text-end" data-bs-dismiss="modal" aria-label="Close" title="close"></button>
    <div class="modal-body" v-if="keep.id">
        <div class="row">
            <div class="col-md-6">
                <img :src="keep.img" class="active-img" alt="">
            </div>
            <div class="col-md-6">
                <div class="row h-100 align-items-between">
                    <div class="col-12 text-center">
                        {{keep.views}}<i class="mdi mdi-eye"></i> {{ keep.kept }} vault
                    </div>
                    <div class="col-12 d-flex flex-column justify-content-center">
                        <h2 class="text-center">{{ keep.name }}</h2>
                        <p>{{ keep.description }}</p>
                    </div>
                    <div class="col-12 d-flex align-items-end justify-content-between">
                        <form v-if="account.id" class="d-flex justify-content-around"
                            @submit.prevent="CreateVaultKeep(keep.id)">
                            <select required v-model="editable.vaultId" class="border-0 border-bottom border-3 border-dark"
                                aria-label="Default select example">
                                <option :value="v.id" v-for="v in vaults">{{ v.name }}</option>
                            </select>
                            <button type="submit" class="btn btn-outline-success ms-1">save</button>
                        </form>
                        <div>
                            <img :src="keep.creator.picture" class="profile-pic rounded-circle" :alt="keep.creator">
                            {{ keep.creator.name }}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import { vaultKeepsService } from '../services/VaultKeepsService'
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            keep: computed(() => AppState.activeKeep),
            account: computed(() => AppState.account),
            vaults: computed(() => AppState.myVaults),

            async CreateVaultKeep(keepId) {
                try {
                    await vaultKeepsService.CreateVaultKeep(keepId, editable.value.vaultId)
                    Pop.success("Added the keep to your vault")
                    editable.value = {}
                } catch (error) {
                    Pop.error(error.message, '[creating vaultkeep]')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.active-img {
    max-height: 100%;
    max-width: 100%;
    min-width: 100%;
    min-height: 100%;
}

.profile-pic {
    height: 6vh;
}
</style>