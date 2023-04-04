<template>
  <div class="about text-center text-light text-shadow" :style="{backgroundImage: `url(${account.coverImg})`}">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <div class="container-fluid">
    <div class="row">
      <form class="col-lg-5 m-auto" @submit.prevent="EditAccount()">
        <div class="mb-3">
          <label for="exampleInputEmail1" class="form-label">Name</label>
          <input required maxlength=255 v-model="editable.name" type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
        </div>
        <div class="mb-3">
          <label for="exampleInputPassword1" class="form-label">Picture</label>
          <input required maxlength=255 v-model="editable.picture" type="text" class="form-control" id="exampleInputPassword1">
        </div>
        <div class="mb-3">
          <label for="exampleInputPassword1" class="form-label">Cover Image</label>
          <input required maxlength=255 v-model="editable.coverImg" type="text" class="form-control" id="exampleInputPassword1">
        </div>
        <div class="text-end">
          <button type="submit" class="btn btn-primary">Save changes</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { computed, ref, watchEffect } from 'vue'
import { AppState } from '../AppState'
import Pop from '../utils/Pop'
import { accountService } from '../services/AccountService'
export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      if (AppState.account) {
        editable.value = AppState.account
      }
    })
    return {
      editable,
      account: computed(() => AppState.account),

      async EditAccount() {
        try {
          const accountData = editable.value
          await accountService.EditAccount(accountData)
        } catch (error) {
          Pop.error(error,'[Editing account]')
        }
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.text-shadow{
  text-shadow: 2px 1px 1px black;
  background-size: cover;
}
</style>
