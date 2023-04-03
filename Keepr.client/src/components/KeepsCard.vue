<template>
    <div class="mb-3 position-relative">
        <img :src="keep.img" class="img-fluid rounded selectable elevation-5" data-bs-toggle="modal" data-bs-target="#activeKeep" @click="ActiveKeep(keep)" :alt="keep.name">
        <div class="position-absolute keep-title">
            <h5>{{ keep.name }}</h5>
        </div>
        <div class="position-absolute keep-creator">
            <img :src="keep.creator.picture" class="rounded-circle profile-img selectable" :title="keep.creator.name"
                alt="">
        </div>
        <div v-if="account.id == keep.creatorId"
            class="position-absolute delete-button bg-danger rounded-circle text-center selectable" title="delete keep" @click="DeleteKeep(keep.id)">
            <i class="mdi mdi-close"></i>
        </div>
    </div>

    <Modal id="activeKeep">
        <ActiveKeepModal/>
    </Modal>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import Modal from './Modal.vue';
import ActiveKeepModal from './activeKeepModal.vue';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';


export default {
    props: { keep: { type: Object, required: true } },
    setup() {
        return {
            account: computed(() => AppState.account),
            ActiveKeep(keep) {
                try {
                    keepsService.ActiveKeep(keep)
                } catch (error) {
                    Pop.error(error, '[Setting active keep]')
                }
            },

            async DeleteKeep(keepId) {
                try {
                    if (await Pop.confirm('Are you sure?')) {
                        await keepsService.DeleteKeep(keepId)
                        Pop.success('The keep was deleted')
                    }
                } catch (error) {
                    Pop.error(error, '[deleting a keep]')
                }
            }
        };
    },
    components: { Modal, ActiveKeepModal }
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