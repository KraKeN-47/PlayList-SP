export const state = () => ({
  playlistArr: [],
  currentSong: null
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
  },
  setCurrentSong (state, newVal) {
    state.currentSong = newVal
  }
}
