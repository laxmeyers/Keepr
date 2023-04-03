import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class VaultsService {
    async GetMyVaults() {
        const res = await api.get('account/vaults');
        AppState.myVaults = res.data
        logger.log(AppState.myVaults)
    }

    async CreateVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log(res.data)
        AppState.myVaults.push(res.data)
    }
}

export const vaultsService = new VaultsService();