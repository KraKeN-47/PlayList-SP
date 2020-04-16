<template>
  <div id="music-player-span">
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
        @click="playMusic"
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
        @click="pauseMusic"
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
    </div>
  </div>
</template>

<script>
let sound = null
export default {
  data () {
    return {
      isPlaying: false
    }
  },
  methods: {
    playMusic () {
      if (!sound) {
        sound = new Audio(require('assets/YES.mp3'))
      }
      this.isPlaying = true
      sound.play()
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
        sound = new Audio(require('assets/t.mp3'))
        sound.play()
      }
    },
    previousSong () {
      if (sound) {
        sound.pause()
        sound = new Audio(require('assets/YES.mp3'))
        sound.play()
      }
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
}
#music-player{
  width: 50%;
  background: transparent;
}
#play-btn,#next-song,#previous-song,#pause-btn{
  left: 50%;
  top: 50%;
}
</style>
