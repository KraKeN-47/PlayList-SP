<template>
  <div class="container">
    <div v-if="showSongs" class="test2">
      <ul>
        <li v-for="song in allPlaylistSongs" v-model="showSongs">
          {{ song.song.name }} &nbsp&nbsp
        </li>
      </ul>
    </div>
    <div class="test1">
      <ul>
        <li v-for="item in playlist">
          {{ item.playlistContent.title }}
          <v-spacer />  {{ item.playlistContent.description }}
          <v-spacer />   {{ item.playlistContent.user }}
          <v-spacer /> <v-btn x-small @click="test()">
            Show songs
          </v-btn>
          <v-spacer /> <v-btn x-small @click="load()">
            Load
          </v-btn>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      allPlaylistSongs: [
        {
          song: {
            name: 'YES',
            path: require('assets/YES.mp3')
          }
        }, {
          song: {
            name: 'Astronomical',
            path: require('assets/Astronomical.mp3')
          }
        }, {
          song: {
            name: 'Maskva magadan',
            path: require('assets/dd576edb-64ae-4554-8ba4-33ec09e5773f.mp3')
          }
        }, {
          song: {
            name: 'Dr.Dre ',
            path: require('assets/dd576edb-64ae-4554-8ba4-33ec09e5773f.mp3')
          }
        }
      ],
      playlist: [
        {
          playlistContent: {
            title: 'First playlist title',
            description: 'First playlist desc',
            user: 'Creator 1'
          }
        },
        {
          playlistContent: {
            title: 'Second playlist title',
            description: 'Second playlist desc',
            user: 'Creator 2'
          }
        }
      ],
      showSongs: false
    }
  },
  methods: {
    test () {
      this.showSongs === true ? this.showSongs = false : this.showSongs = true
    },
    load () {
      this.$store.commit('allplaylistmusic/addArray', this.allPlaylistSongs)
    }
  }
}
</script>

<style>
.container{
    margin: auto
}
.test1{
    margin: left
}
.test2{
    float: right;
    background-color: black;
}
</style>
