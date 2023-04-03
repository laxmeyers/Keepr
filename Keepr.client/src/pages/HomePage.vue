<template>
{{ keeps }}
</template>

<script>
import Pop from '../utils/Pop';
import {keepsService} from '../services/KeepsService'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {
    async function GetKeeps() {
      try {
        await keepsService.GetKeeps();
      } catch (error) {
        Pop.error(error, '[getting keeps]')       
      }
    } 

    onMounted(() => {
      GetKeeps()
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
