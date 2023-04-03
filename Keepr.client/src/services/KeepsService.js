import { AppState } from "../AppState";
import { api } from "./AxiosService";

class KeepsService {
    async GetKeeps() {
        const res = await api.get('api/keeps')
        AppState.keeps = res.data
    }

    async CreateKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        AppState.keeps.push(res.data)
    }

    async ActiveKeep(keepId) {
        AppState.activeKeep = {}
        const res = await api.get('api/keeps/'+ keepId)
        AppState.activeKeep = res.data
    }

    async DeleteKeep(keepId) {
        const res = await api.delete('api/keeps/' + keepId)
        const keepIndex = AppState.keeps.findIndex(k => k.id == keepId)
        AppState.keeps.splice(keepIndex, 1)
    }
}

export const keepsService = new KeepsService();