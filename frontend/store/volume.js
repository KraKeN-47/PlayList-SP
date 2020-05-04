export const state = () => ({
  isVolumeDisp: true
})

export const mutations = {
  changeVolumeDisp (state) {
    state.isVolumeDisp = !state.isVolumeDisp
    console.log(state.isVolumeDisp)
  }
}

export const actions = {
  VolumeDispAction (state) {
    state.commit('changeVolumeDisp')
  }
}
