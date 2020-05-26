<template>
  <div class="container">
    <div v-if="showSongs" class="test2">
      <v-overlay>
        <v-btn fab depressed text x-small @click="showSongs = false">
          <v-icon>mdi-close</v-icon>
        </v-btn>
        <div>
          <v-card v-for="(song, index) in allPlaylistSongs" :key="song.path" color="rgb(201, 190, 170)" outlined class="song">
            <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <v-flex md1>
                <div class="half" />
                <div>
                  <v-btn x-small fab depressed @click="removeFromPlaylist(index)">
                    <v-icon>mdi-minus</v-icon>
                  </v-btn>
                </div>
              </v-flex>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <v-flex md2>
                <div class="caption black--text">
                  Title
                </div>
                <div class="black--text">
                  {{ song.title }}
                </div>
              </v-flex>
              <v-flex md5>
                <div class="caption black--text">
                  Description
                </div>
                <div class="black--text">
                  {{ song.desc }}
                </div>
              </v-flex>
              <v-flex>
                <div class="caption black--text">
                  Artist
                </div>
                <div class="black--text">
                  {{ song.userName }}
                </div>
              </v-flex>
            </v-layout>
          </v-card>
        </div>
      </v-overlay>
    </div>
    <div class="playlists">
      <v-card v-for="(list,index) in playlists" :key="list.playlistId" color="rgb(201, 190, 170)" outlined>
        <v-layout row wrap>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <v-flex md1>
            <div class="halff" />
            <div>
              <v-btn fab x-small @click="deletePlaylist(index)">
                <v-icon>
                  mdi-minus
                </v-icon>
              </v-btn>
            </div>
          </v-flex>
          <v-flex md2>
            <div class="caption white--text">
              <br>
              Title
            </div>
            <div>{{ list.title }}</div>
          </v-flex>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <v-flex md4>
            <div class="caption white--text">
              <br>
              Description
            </div>
            <div>{{ list.desc }}</div>
          </v-flex>
          <v-flex md1>
            <div class="halff" />
            <div>
              <v-btn x-small @click="load(index)">
                Load playlist
              </v-btn>
            </div>
          </v-flex>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <v-flex md1>
            <div class="halff" />
            <div>
              <v-btn x-small @click="showPlaylistSongs(index)">
                Show songs
              </v-btn>
            </div>
          </v-flex>
        </v-layout>
        <br>
      </v-card>
    </div>
    <div class="testingbtn">
      <v-btn fab x-small @click="overlay = !overlay">
        <v-icon>mdi-plus</v-icon>
      </v-btn>
      <v-overlay v-model="overlay">
        <div class="playlistForm">
          <v-form
            ref="submit"
            v-model="valid"
            class="px-3"
            width="600px"
            height="500px"
          >
            <div class="playlistCreateForm">
              <v-text-field
                v-model="title"
                class="title"
                light
                label="Please enter your playlist name:"
                prepend-icon="mdi-text"
                counter
                :rules="[requiredField('Title','')]"
                solo
              />
              <v-text-field
                v-model="description"
                class="description"
                light
                prepend-icon="mdi-text"
                label="Please enter your playlist description"
                solo
                :rules="[requiredField('Description','')]"
              />
              <v-label>Is your playlist private?</v-label>
              <v-checkbox v-model="isPrivate" label="Yes" color="black" />
              <v-btn :disabled="!valid" @click="createPlaylist()">
                <v-icon left>
                  mdi-plus-box
                </v-icon>
                Create
              </v-btn>
              <v-btn class="closeBtn" @click="overlay = false">
                Close
              </v-btn>
            </div>
          </v-form>
        </div>
      </v-overlay>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  // middleware: 'auth-isUser',
  data () {
    return {
      isPrivate: false,
      overlay: false,
      allPlaylistSongs: [],
      valid: true,
      description: '',
      title: '',
      playlists: [],
      showSongs: false,
      selectedSong: null
    }
  },
  computed: {
    myPlaylists () {
      return this.$store.state.playlist.myPlaylists
    },
    playlistSongs () {
      return this.$store.state.allplaylistmusic.playlistArr
    }
  },
  async created () {
    try {
      await axios.get('https://localhost:5001/api/v1/playlist').then((response) => {
        this.$store.commit('playlist/Playlists', response.data.playlists)
      })
    } catch (error) {
      alert(error)
    }
    this.playlists = this.myPlaylists
  },
  methods: {
    async removeFromPlaylist (index) {
      this.selectedSong = this.allPlaylistSongs[index].musicId
      try {
        await axios.delete()
      } catch (error) {
      }
    },
    async showPlaylistSongs (index) {
      this.showSongs === true ? this.showSongs = false : this.showSongs = true
      const selectedPlaylist = this.myPlaylists[index]
      try {
        await axios.get(`https://localhost:5001/api/v1/music/playlists/${selectedPlaylist.playlistId}`)
          .then((response) => { this.allPlaylistSongs = response.data.musicList; console.log(this.allPlaylistSongs) })
      } catch (error) {
        alert(error)
        console.log(error)
      }
    },
    async load (index) {
      const empty = []
      this.$store.commit('allplaylistmusic/addArray', empty)
      const selectedPlaylist = this.myPlaylists[index]
      try {
        await axios.get(`https://localhost:5001/api/v1/music/playlists/${selectedPlaylist.playlistId}`)
          .then((response) => { this.allPlaylistSongs = response.data.musicList; console.log(this.allPlaylistSongs) })
      } catch (error) {
        alert(error)
        console.log(error)
      }
      this.$store.commit('allplaylistmusic/addArray', this.allPlaylistSongs)
    },
    requiredField (property, re) { // finds out if field is not empty, else returns an error message.
      return field =>
        (field && field.length > 0) || `Please ${re}enter your ${property}.`
    },
    async createPlaylist () {
      try {
        await axios.post('https://localhost:5001/api/v1/playlist',
          {
            Desc: this.description,
            Title: this.title,
            IsPrivate: this.isPrivate,
            UserId: this.$auth.user.id
          })
      } catch (error) {
        console.log(error)
      } finally {
      // eslint-disable-next-line nuxt/no-globals-in-created
        window.location.href = 'http://localhost:3000/myplaylists'
      }
    },
    async deletePlaylist (index) {
      try {
        await axios.delete(`https://localhost:5001/api/v1/playlist/${this.playlists[index].playlistId}`)
        // console.log(`${this.playlists[index].playlistId}`)
      } catch (error) {
        alert(error)
        console.log(error)
      } finally {
        window.location.href = 'http://localhost:3000/myplaylists'
      }
    }
  }
}
</script>

<style>
.container{
    margin: auto;
    width: 100%;
    height: 70%;
}
.test1{
    margin: left
}

.testingbtn{
  display: flex;
  justify-content: center;
  align-items: center;
}
.playlistForm{
    width:600px;
    height: 350px;
    border-radius: 40px;
    padding: 40px;
    margin: auto;
    background: rgb(201, 190, 170);
}
.title,.description{
  color: black;
}
.song{
  width: 1500px;
  padding: 10px
}
.closeBtn{
  float: right;
}
.halff{
  height: 30px;
}
</style>
