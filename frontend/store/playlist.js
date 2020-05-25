export const state = () => ({
  isPlaylistDisp: false,
  myPlaylists: []
})

export const mutations = {
  changePlaylistDisp (state) {
    state.isPlaylistDisp = !state.isPlaylistDisp
  },
  Playlists (state, newVal) {
    console.log(newVal)
    state.myPlaylists = newVal
  }
}
