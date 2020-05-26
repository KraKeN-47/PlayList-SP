export const state = () => ({
  isPlaylistDisp: false,
  myPlaylists: []
})

export const mutations = {
  changePlaylistDisp (state) {
    state.isPlaylistDisp = !state.isPlaylistDisp
  },
  Playlists (state, newVal) {
    state.myPlaylists = newVal
  }
}
