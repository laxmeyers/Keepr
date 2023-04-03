import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class VaultKeepsService{
    async CreateVaultKeep(keepId, vaultId) {
        const res = await api.post('api/vaultkeeps', { keepId, vaultId })
    }
}

export const vaultKeepsService = new VaultKeepsService();