export const state = () => ({
  selectedSong: {},
  selectedPlaylist: {},
  allPlaylistSongs: []
})

export const mutations = {
  addSelectedSong (state, newVal) {
    state.selectedSong = newVal
  },
  addSelectedPlaylist (state, newVal) {
    state.selectedPlaylist = newVal
  },
  addPlaylistSongs (state, newVal) {
    state.allPlaylistSongs = newVal
  }
}
