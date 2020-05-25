<template>
  <div id="music-player-span" class="music-span">
    <div id="music-player">
      <v-btn id="previous-song" rounded="" :disabled="songs.length === 0" @click="previousSong">
        <v-icon>
          mdi-skip-previous
        </v-icon>
      </v-btn>
      <v-btn
        v-if="!isPlaying"
        id="play-btn"
        color="indigo"
        fab
        depressed
        large=""
        :disabled="songs.length === 0"
        @click="playMusic();"
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
        :disabled="songs.length === 0"
        @click="pauseMusic()"
      >
        <v-icon>
          mdi-pause
        </v-icon>
      </v-btn>
      <v-btn id="next-song" rounded="" :disabled="songs.length === 0" @click="nextSong">
        <v-icon>
          mdi-skip-next
        </v-icon>
      </v-btn>
      <v-btn
        id="Volume-BTN"
        fab
        depressed
        x-small
        :disabled="songs.length === 0"
        @click="changeVolumeDisp"
      >
        <v-icon>
          mdi-volume-high
        </v-icon>
      </v-btn>
      <div class="Time-Slider-Div" :disabled="songs.length === 0">
        <v-slider
          id="TESTINGSLIDER"
          v-model="currentTime"
          class="Time-Slider"
          min="0"
          :max="duration"
          value="0"
          @end="setTime"
        />
      </div>
      <v-snackbar v-if="songs.length === 0 ? testas = true : testas = false" v-model="testas" color="success" :timeout="10000">
        In order to use the music player, you must load the playlist first from your Playlist page
      </v-snackbar>
      <!-- eslint-disable-next-line vue/valid-v-on -->
      <div class="Time-Div">
        <label @timeupdate>
          {{ TimeMinutes }}:{{ TimeSeconds }} / {{ DurationMinutes }}:{{ DurationSeconds }}
        </label>
      </div>
      <v-btn depressed small class="Repeat-Btn" :disabled="songs.length === 0" @click="repeatSong">
        <v-icon v-if="repeat===false">
          mdi-repeat
        </v-icon>
        <v-icon v-if="repeat===true">
          mdi-repeat-once
        </v-icon>
      </v-btn>
      <v-btn depressed small class="PlayList" :disabled="songs.length === 0" @click="changePlayListDisp">
        PlayList
      </v-btn>
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
      DurationSeconds: '00',
      repeat: false,
      currentTime: 0,
      duration: 0,
      test: false,
      testsongs: [],
      currentSong: null
    }
  },
  computed: {
    volume () {
      return this.$store.state.volume.volume
    },
    songs () {
      return this.$store.state.allplaylistmusic.playlistArr
    }
  },
  watch: {
    volume (newVal) {
      if (sound) {
        sound.volume = newVal
      }
    },
    currentTime (newVal) {
      const index = this.songs.indexOf(this.currentSong)
      if (newVal === this.duration && index !== (this.songs.length - 1)) {
        this.nextSong()
      } else if (index === this.songs.length - 1 && newVal === this.duration && this.repeat === false) {
        this.nextSong()
        this.pauseMusic()
      }
    },
    songs (newVal) {
      // console.log(newVal)
    }
  },
  methods: {
    playSong (song, isPaused) {
      this.isPlaying = true
      sound = new Audio(require(`assets/${song.musicId}.mp3`))
      this.currentSong = song
      sound.volume = this.volume
      // const index = this.songs.indexOf(this.currentSong)
      // this.$emit('currentSong-update', index)
      sound.play()
      sound.addEventListener('timeupdate', (update) => {
        this.updateTime(sound)
        if (this.$store.state.auth.loggedIn === false) {
          this.pauseMusic()
        }
      })
    },
    playMusic () {
      if (!sound) {
        this.currentSong = this.songs[0]
        this.playSong(this.currentSong)
      } else if (this.currentTime !== 0) {
        sound.play()
        this.isPlaying = true
      } else {
        this.playSong(this.currentSong)
      }
    },
    pauseMusic () {
      if (sound) {
        sound.pause()
      }
      this.isPlaying = false
    },
    nextSong () {
      this.repeat = false
      const index = this.songs.indexOf(this.currentSong)
      if (sound) {
        if (index > -1) {
          if ((this.songs.length - 1) === index) {
            this.pauseMusic()
            this.playSong(this.songs[0])
          } else {
            this.pauseMusic()
            this.playSong(this.songs[index + 1])
          }
        }
      }
    },
    previousSong () {
      this.repeat = false
      const index = this.songs.indexOf(this.currentSong)
      // console.log(index)
      if (sound) {
        if (this.isPlaying && sound.currentTime > 5) {
          sound.currentTime = 0
        } else if (index === 0) {
          this.pauseMusic()
          this.playSong(this.songs[this.songs.length - 1])
        } else {
          this.pauseMusic()
          this.playSong(this.songs[index - 1])
        }
      }
    },
    updateTime (sound) {
      this.currentTime = sound.currentTime - 1
      this.duration = sound.duration
      const duration = sound.duration || 0
      let timeMinutes = Math.floor(sound.currentTime / 60).toFixed()
      const timeSeconds = (sound.currentTime - timeMinutes * 60).toFixed()
      if (timeSeconds === '60') {
        this.TimeSeconds = '00'
        timeMinutes = parseInt(timeMinutes) + 1
        this.TimeMinutes = (timeMinutes >= 10) ? timeMinutes.toString() : '0' + timeMinutes.toString() // Current time Minutes toString
      } else {
        this.TimeSeconds = (timeSeconds >= 10) ? timeSeconds.toString() : '0' + timeSeconds.toString() // Current time Seconds toString
        this.TimeMinutes = (timeMinutes >= 10) ? timeMinutes.toString() : '0' + timeMinutes.toString() // Current time Minutes toString
      }
      const durationMinutes = Math.floor(duration / 60).toFixed()
      const durationSeconds = (duration - durationMinutes * 60).toFixed()
      this.DurationMinutes = (durationMinutes >= 10) ? durationMinutes.toString() : '0' + durationMinutes.toString() // Duration minutes toString
      this.DurationSeconds = (durationSeconds >= 10) ? durationSeconds.toString() : '0' + durationSeconds.toString() // Duration seconds toString
    },
    changeVolumeDisp () {
      this.$store.commit('volume/changeVolumeDisp')
    },
    changePlayListDisp () {
      this.$store.commit('playlist/changePlaylistDisp')
    },
    repeatSong () {
      if (sound) {
        this.repeat = !this.repeat
        sound.loop = this.repeat
      }
    },
    setTime (newVal) {
      sound.currentTime = newVal
    }
  }
}
</script>

<style>
#music-player-span{
    background: rgb(201, 190, 170);
    width: 100%;
    position: -webkit-sticky;
    position: sticky;
    bottom: 0;
}
#music-player{
  width: 100%;
  background: transparent;
}
#play-btn,#next-song,#previous-song,#pause-btn{
  left: 20%;
}
#Volume-BTN{
  left:50%;
}
.Time-Slider-Div{
  left: 35%;
  position: absolute;
  bottom: 25%;
  width: 20%;
  height: 50%;
}
.Time-Slider{
  width: 100%;
}
.Time-Div{
  left:55.7%;
  bottom: 30%;
  position: absolute;
}
.Repeat-Btn{
  left:50%;
}
.PlayList{
  left:55%;
}
/* .v-input__control {
  height: 1px;
} */
</style>
