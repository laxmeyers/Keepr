<template>
<div class="container my-3">
  <div class="bricks">
    <div v-for="k in keeps">
    <KeepsCard :keep="k"/>
    </div>
  </div>
</div>
</template>

<script>
import Pop from '../utils/Pop';
import {keepsService} from '../services/KeepsService'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import KeepsCard from '../components/KeepsCard.vue';

export default {
    setup() {
        async function GetKeeps() {
            try {
                await keepsService.GetKeeps();
            }
            catch (error) {
                Pop.error(error, "[getting keeps]");
            }
        }
        onMounted(() => {
            GetKeeps();
        });
        return {
            keeps: computed(() => AppState.keeps)
        };
    },
    components: { KeepsCard }
}
</script>

<style scoped lang="scss">
.bricks {
  columns: 300px;
  column-gap:1em;
}
</style>
