export const state = () => ({
  allMusic: []
})

export const mutations = {
  addArray (state, newVal) {
    state.allMusic = newVal
  },
  LOGGED_OUT (state) {
    state.allMusic = []
  }
}
