<template>
  <header class="elevation-5">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
   <!-- <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer> -->
</template>

<script>
import { computed, watchEffect } from 'vue'
import { AppState } from './AppState'
import {vaultsService} from './services/VaultsService'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    async function GetMyVaults() {
      try {
        await vaultsService.GetMyVaults();
      } catch (error) {
        Pop.error(error, '[Getting my vaults]')
      }
    }
    watchEffect(() => {
      if (AppState.account.id) {
        GetMyVaults();
      }
    })
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
