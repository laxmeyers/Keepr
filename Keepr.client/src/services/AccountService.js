import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async GetProfile(profileId) {
    const res = await api.get('api/profiles/' + profileId)
    logger.log(res.data)
    AppState.profile = res.data
  }

  async EditAccount(accountData) {
    const res = await api.put('account', accountData)
    logger.log(res.data)
  }
}

export const accountService = new AccountService()
