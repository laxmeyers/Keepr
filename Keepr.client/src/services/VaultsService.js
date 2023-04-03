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

    async GetProfilesVaults(profileId) {
        AppState.vaults = []
        const res = await api.get('api/profiles/' + profileId + '/vaults')
        logger.log('fun',res.data)
        if (AppState.account.id == profileId) {
            AppState.vaults = res.data
        } else {
            AppState.vaults = res.data.filter(v => v.isPrivate != true)
        }
    }

    async getVault(vaultId) {
        const res = await api.get('api/vaults/' + vaultId)
        AppState.activeVault = res.data
    }
}

export const vaultsService = new VaultsService();