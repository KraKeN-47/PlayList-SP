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
      <!-- eslint-disable-next-line vue/valid-v-on -->
      <label id="Time" @timeupdate>
        {{ TimeMinutes }}:{{ TimeSeconds }} / {{ DurationMinutes }}:{{ DurationSeconds }}
      </label>
      <!-- <div id="player">
        <div id="volume" />
      </div> -->
    </div>
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
/* #player{
  width: 350px;
  height: 50px;
  position: auto;
  margin: 0 auto;
  top: 80px;
}
#volume {
position: absolute;
left: 24px;
margin: 0 auto;
height: 5px;
width: 300px;
background: #555;
border-radius: 15px;
}
.ui-slider-range-min {
height: 5px;
width: 300px;
position: absolute;
background: $primary-color;
border: none;
border-radius: 10px;
outline: none;
}
.ui-slider-handle {
width: 20px;
height: 20px;
border-radius: 20px;
background: #FFF;
position: absolute;
margin-left: -8px;
margin-top: -8px;
cursor: pointer;
outline: none;
}
} */
</style>
