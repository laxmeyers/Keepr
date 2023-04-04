<template>
  <div class="container my-4">
    <div class="row">
      <div class="col-12 text-center">
        <img :src="profile.coverImg" class="elevation-4 rounded cover-image" alt="">
      </div>
      <div class="col-md-6 m-auto text-center">
        <img :src="profile.picture" class="rounded-circle profile-image elevation-5" alt="">
      </div>
      <div class="col-12 text-center">
        <h1>{{ profile.name }}</h1>
        {{ numberKeeps }} Keeps || {{ numberVaults }} Vaults
      </div>
    </div>
    <div class="row mb-5">
      <div class="col-12">
        <h2>Vaults</h2>
      </div>
      <div class="col-md-3" v-for="v in vaults">
        <VaultCard :vault="v" />
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2>Keeps</h2>
      </div>
      <div class="bricks">
        <div v-for="k in keeps">
          <KeepsCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
import { accountService } from '../services/AccountService';
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService';
import VaultCard from '../components/VaultCard.vue';
import { vaultsService } from '../services/VaultsService';

export default {
  setup() {
    const route = useRoute();
    async function GetProfile() {
      try {
        const profileId = route.params.profileId;
        await accountService.GetProfile(profileId);
      }
      catch (error) {
        Pop.error(error, "[Getting profile]");
      }
    }
    async function GetKeeps() {
      try {
        const profileId = route.params.profileId;
        await keepsService.GetProfilesKeeps(profileId);
      }
      catch (error) {
        Pop.error(error, "[Getting keeps]");
      }
    }
    async function GetVaults() {
      try {
        const profileId = route.params.profileId;
        await vaultsService.GetProfilesVaults(profileId);
      }
      catch (error) {
        Pop.error(error, "[Getting keeps]");
      }
    }
    onMounted(() => {
      GetProfile();
      GetKeeps();
      GetVaults();
    });
    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      numberKeeps: computed(() => AppState.keeps.length),
      numberVaults: computed(() => AppState.vaults.length)
    };
  },
  components: { VaultCard }
}
</script>

<style scoped lang="scss">
.bricks {
  columns: 250px;
  column-gap: 1em;
}

.cover-image {
  max-width: 70vw;
  min-width: 50vw;
  min-height: 50vh;
  max-height: 60vh;
}

.profile-image {
  transform: translateY(-60px);
  height: 25vh;
  width: 25vh;
  object-fit: cover;
}
</style>
