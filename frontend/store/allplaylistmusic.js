export const state = () => ({
  playlistArr: [],
  index: -1
})

export const mutations = {
  addSong (state, newVal) {
    state.index += 1
    state.playlistArr[state.index] = newVal
  },
  addArray (state, newVal) {
    state.playlistArr = newVal
  },
  LOGGED_OUT (state, newVal) {
    state.playlistArr = []
  }
}
