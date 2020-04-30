export const state = () => ({
  logged: Boolean
})

export const mutations = {
  LOGGED_IN (state) {
    state.logged = true
  },
  LOGGED_OUT (state) {
    state.logged = false
  }
}

export const actions = {
  loginAction (state) {
    state.commit('LOGGED_IN')
  },
  logoutAction (state) {
    state.commit('LOGGED_OUT')
  }
}

export const getters = {
  loggedState (state) {
    return state.logged
  }
}
