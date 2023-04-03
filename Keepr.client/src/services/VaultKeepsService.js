import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class VaultKeepsService{
    async CreateVaultKeep(keepId, vaultId) {
        const res = await api.post('api/vaultkeeps', { keepId, vaultId })
        AppState.activeKeep.kept++
    }

    async RemoveFromVault(vaultKeepId) {
        const res = await api.delete('api/vaultkeeps/' + vaultKeepId)
        const index = AppState.keeps.findIndex(k => k.vaultKeepId == vaultKeepId)
        AppState.keeps.splice(index,1)
    }
}

export const vaultKeepsService = new VaultKeepsService();