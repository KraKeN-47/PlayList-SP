export const state = () => ({
  isVolumeDisp: false,
  volume: 50,
  CurrentTime: 0
})

export const mutations = {
  changeVolumeDisp (state) {
    state.isVolumeDisp = !state.isVolumeDisp
  },
  changeVolume (state, value) {
    state.volume = value
  },
  changeCurrentTime (state, value) {
    state.CurrentTime = value
  }
}

export const actions = {
  VolumeDispAction (state) {
    state.commit('changeVolumeDisp')
  }
}
