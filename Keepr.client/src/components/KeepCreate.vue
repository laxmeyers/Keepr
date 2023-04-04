<template>
    <form @submit.prevent="CreateKeep()">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create Keep</h1>
            <button type="reset" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <div class="form-floating mb-3">
                <input maxlength=50 v-model="editable.name" type="text" class="form-control" id="floatingInput" placeholder="title" required>
                <label for="floatingInput">Title</label>
            </div>
            <div class="form-floating">
                <input maxlength=500 v-model="editable.img" type="text" class="form-control" id="floatingPassword" placeholder="image" required>
                <label for="floatingPassword">Image URL</label>
            </div>
            <div class="form-floating mt-3">
                <textarea maxlength=500 v-model="editable.description" class="form-control" placeholder="Leave a comment here" id="floatingTextarea" required></textarea>
                <label for="floatingTextarea">Description</label>
            </div>
        </div>
        <div class="modal-footer">
            <button type="reset" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Add Keep</button>
        </div>
    </form>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async CreateKeep() {
                try {
                    await keepsService.CreateKeep(editable.value)
                    Pop.success("Creating Keep was successful!")
                    editable.value = {}
                } catch (error) {
                    Pop.error(error, '[creating keep]')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>