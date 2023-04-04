<template>
    <form @submit.prevent="CreateVault()">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create Vault</h1>
            <button type="reset" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <div class="form-floating mb-3">
                <input maxlength=25 v-model="editable.name" type="text" class="form-control" id="floatingInput" placeholder="title" required>
                <label for="floatingInput">Title</label>
            </div>
            <div class="form-floating">
                <input maxlength=255 v-model="editable.img" type="text" class="form-control" id="floatingPassword" placeholder="image" required>
                <label for="floatingPassword">Image URL</label>
            </div>
            <div class="form-floating mt-3">
                <textarea maxlength=500 v-model="editable.description" class="form-control" placeholder="Leave a comment here" id="floatingTextarea" required></textarea>
                <label for="floatingTextarea">Description</label>
            </div>
            <div class="form-check mt-3">
                <input v-model="editable.isPrivate" class="form-check-input" type="checkbox" id="flexCheckDefault">
                <label class="form-check-label" for="flexCheckDefault">
                    Make It Private?
                </label>
            </div>
        </div>
        <div class="modal-footer">
            <button type="reset" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Create Vault</button>
        </div>
    </form>
</template>


<script>
import { ref } from 'vue';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({
            isPrivate: false
        })
        return {
            editable,
            async CreateVault() {
                try {
                    await vaultsService.CreateVault(editable.value)
                    editable.value = {isPrivate: false}
                } catch (error) {
                    Pop.error(error, '[Creating Vault]')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>