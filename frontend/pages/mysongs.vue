<template>
  <div class="mySongsPage">
    <v-card
      v-for="song in mySongs"
      :key="song.musicId"
      color="rgb(201, 190, 170)"
      outlined
      class="mysongs"
    >
      <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <v-flex md2>
          <div class="caption black--text">
            Artist
          </div>
          <div class="black--text">
            {{ song.userName }}
          </div>
        </v-flex>
        <v-flex md4>
          <div class="caption black--text">
            Song Title
          </div>
          <div class="black--text">
            {{ song.title }}
          </div>
        </v-flex>
        <v-flex md4>
          <div class="caption black--text">
            Description
          </div>
          <div class="black--text">
            {{ song.desc }}
          </div>
        </v-flex>
      </v-layout>
    </v-card>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  middleware: 'auth-artist',
  data: () => {
    return {
      mySongs: []
    }
  },
  async created () {
    try {
      await axios.get('https://localhost:5001/api/v1/music/users',
        { params: { username: this.$auth.user.userName } }
      ).then((response) => { this.mySongs = response.data.musicList })
    } catch (error) {
      // alert(error)
      console.log(error)
    }
  }
}
</script>

<style>
.mySongsPage{
    margin:auto;
}
.mysongs {
    width: 1000px;
    padding: 10px;
}
</style>
