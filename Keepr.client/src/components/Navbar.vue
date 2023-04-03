<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h1 class="fs-5">the keeper co.</h1>
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <div class="btn-group w-25">
          <button type="button" class="btn text-light dropdown-toggle" data-bs-toggle="dropdown"
            data-bs-display="static" aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu dropdown-menu-end dropdown-menu-lg-start">
            <li><button class="dropdown-item border-bottom border-dark" data-bs-toggle="modal" data-bs-target="#vaultModal">Vault</button></li>
            <li><button class="dropdown-item" data-bs-toggle="modal" data-bs-target="#keepModal">Keep</button></li>
          </ul>
        </div>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>

  <Modal id="vaultModal">
    <CreateVault/>
  </Modal>
  <Modal id="keepModal">
    <KeepCreate/>
  </Modal>
</template>

<script>
import CreateVault from './CreateVault.vue';
import KeepCreate from './KeepCreate.vue';
import Login from './Login.vue'
import Modal from './Modal.vue';
export default {
  setup() {
    return {}
  },
  components: { Login, Modal, CreateVault, KeepCreate }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
