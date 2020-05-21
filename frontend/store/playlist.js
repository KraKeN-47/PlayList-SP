export const state = () => ({
  isPlaylistDisp: false
})

export const mutations = {
  changePlaylistDisp (state) {
    state.isPlaylistDisp = !state.isPlaylistDisp
  }
}
