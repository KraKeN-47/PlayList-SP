<template>
  <div id="music-player-span" class="music-span">
    <div id="music-player">
      <v-btn id="previous-song" rounded="" @click="previousSong">
        <v-icon>
          mdi-skip-previous
        </v-icon>
      </v-btn>
      <v-btn
        v-if="!isPlaying"
        id="play-btn"
        color="indigo"
        fab
        large=""
        @click="playMusic()"
      >
        <v-icon>
          mdi-play
        </v-icon>
      </v-btn>
      <v-btn
        v-if="isPlaying"
        id="pause-btn"
        color="indigo"
        fab
        large=""
        @click="pauseMusic()"
      >
        <v-icon>
          mdi-pause
        </v-icon>
      </v-btn>
      <v-btn id="next-song" rounded="" @click="nextSong">
        <v-icon>
          mdi-skip-next
        </v-icon>
      </v-btn>
      <v-btn id="Volume-BTN" fab x-small @click="changeVolumeDisp">
        <v-icon>
          mdi-volume-high
        </v-icon>
      </v-btn>
      <!-- eslint-disable-next-line vue/valid-v-on -->
      <label id="Time" @timeupdate>
        {{ TimeMinutes }}:{{ TimeSeconds }} / {{ DurationMinutes }}:{{ DurationSeconds }}
      </label>
      <!-- <div id="player">
        <div id="volume" />
      </div> -->
    </div>
    <!-- <input v-show="isVolumeDisp" id="Audio-Slider" type="range"> -->
  </div>
</template>

<script>
let sound = null
export default {
  data () {
    return {
      isPlaying: false,
      TimeMinutes: '00',
      TimeSeconds: '00',
      DurationMinutes: '00',
      DurationSeconds: '00'
    }
  },
  methods: {
    playMusic () {
      if (!sound) {
        sound = new Audio(require('assets/YES.mp3'))
      }
      this.isPlaying = true
      sound.play()
      sound.addEventListener('timeupdate', (update) => {
        this.updateTime(sound)
        // if (this.$store.state.login.logged === false) {
        if (this.$store.state.auth.loggedIn === false) {
          this.pauseMusic()
        }
      })
    },
    pauseMusic () {
      if (sound) {
        sound.pause()
      }
      this.isPlaying = false
    },
    nextSong () {
      if (sound) {
        sound.pause()
        sound = new Audio(require('assets/Astronomical.mp3'))
        this.playMusic()
      }
    },
    previousSong () {
      if (sound) {
        if (this.isPlaying && sound.currentTime > 5) {
          sound.currentTime = 0
        } else {
          sound.pause()
          sound = new Audio(require('assets/YES.mp3'))
          this.playMusic()
        }
      }
    },
    updateTime (sound) {
      const timeMinutes = Math.floor(sound.currentTime / 60).toFixed()
      const duration = sound.duration || 0
      const timeSeconds = (sound.currentTime - timeMinutes * 60).toFixed()
      this.TimeMinutes = (timeMinutes >= 10) ? timeMinutes.toString() : '0' + timeMinutes.toString()
      this.TimeSeconds = (timeSeconds >= 10) ? timeSeconds.toString() : '0' + timeSeconds.toString()
      const durationMinutes = Math.floor(duration / 60).toFixed()
      const durationSeconds = (duration - durationMinutes * 60).toFixed()
      this.DurationMinutes = (durationMinutes >= 10) ? durationMinutes.toString() : '0' + durationMinutes.toString()
      this.DurationSeconds = (durationSeconds >= 10) ? durationSeconds.toString() : '0' + durationSeconds.toString()
    },
    changeVolumeDisp () {
      this.$store.commit('volume/changeVolumeDisp')
      console.log(this.$store.state.volume.isVolumeDisp)
    }
  }
}
</script>

<style>
 #play-btn,#pause-btn{
  margin: auto;
  margin-top: auto;
  margin-left: auto;
}
#music-player-span{
    background: rgb(201, 190, 170);
    width: 100%;
    height: 7%;
    position: -webkit-sticky;
    position: sticky;
    bottom:0
}
#music-player{
  width: 50%;
  background: transparent;
}
#play-btn,#next-song,#previous-song,#pause-btn{
  left: 50%;
}
#Time{
  left: 10%;
  top: 50%;
}
#Audio-Slider{
  -webkit-appearance: slider-vertical;
}
#Volume-BTN{
  left:100%;
}
</style>
