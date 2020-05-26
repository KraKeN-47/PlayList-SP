<template>
  <div class="container">
    <!-- <v-card v-for="(song, index) in this.$store.state.allMusic.allMusic" :key="song.path" color="rgb(201, 190, 170)" outlined> -->
    <pagination-component
      :music="music"
      :current-page="currentPage"
      :page-size="pageSize"
      class="pagination"
      @page:update="updatePage"
    />
    <v-card
      v-for="(song, index) in visibleSongs"
      :key="song.path"
      color="rgb(201, 190, 170)"
      outlined
      class="song"
    >
      <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <v-flex md1>
          <div class="half" />
          <div>
            <v-btn x-small @click="getSelectedSong(index)">
              <v-icon left>
                mdi-plus
              </v-icon>Add to playlist
            </v-btn>
          </div>
        </v-flex>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <v-flex md3>
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
    <pagination-component
      :music="music"
      :currentPage="currentPage"
      :pageSize="pageSize"
      class="pagination"
      @page:update="updatePage"
    />
    <div>
      <v-overlay v-if="showPlayLists">
        <v-btn fab depressed text x-small @click="showPlayLists = false">
          <v-icon>mdi-close</v-icon>
        </v-btn>
        <div class="playlists">
          <v-card v-for="(list,index) in playlists" :key="list.playlistId" color="rgb(201, 190, 170)" outlined>
            <v-layout row wrap>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <v-flex md1>
                <div class="halff" />
                <div>
                  <v-btn fab x-small @click="addToPlaylist(index)">
                    <v-icon>
                      mdi-check
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
            </v-layout>
            <br>
          </v-card>
        </div>
      </v-overlay>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import Pagination from '@/components/Pagination.vue'
export default {
  components: {
    'pagination-component': Pagination
  },
  data () {
    return {
      showPlayLists: false,
      selectedSong: {},
      currentPage: 0,
      pageSize: 5,
      visibleSongs: []
    }
  },
  computed: {
    music () {
      return this.$store.state.allMusic.allMusic
    },
    playlists () {
      return this.$store.state.playlist.myPlaylists
    }
  },
  async created () { // fetch data before rendering
    try {
      await axios.get('https://localhost:5001/api/v1/music')
        .then((response) => {
          this.$store.commit('allMusic/addArray', response.data.musicList)
        })
    } catch (error) {
      alert(error)
      // console.log(error)
    }
    this.updatePageSongs()
    try {
      await axios.get('https://localhost:5001/api/v1/playlist').then((response) => {
        this.$store.commit('playlist/Playlists', response.data.playlists)
      })
    } catch (error) {
      alert(error)
    }
  },
  methods: {
    getSelectedSong (index) {
      this.showPlayLists = true
      if (this.currentPage !== 0) {
        const pageIndex = (this.pageSize * (this.currentPage + 1))
        const songIndex = index === 0 ? pageIndex - (this.pageSize - 1) : pageIndex - (this.pageSize - (index + 1)) - 1
        this.selectedSong = this.music[songIndex]
      } else if (this.currentPage === 0) {
        this.selectedSong = this.music[index]
      }
      console.log(this.selectedSong)
    },
    updatePage (pageNumber) {
      this.currentPage = pageNumber
      this.updatePageSongs()
    },
    updatePageSongs () {
      this.visibleSongs = this.music.slice(this.currentPage * this.pageSize, (this.currentPage * this.pageSize) + this.pageSize)
    },
    async addToPlaylist (index) {
      try {
        await axios.post('https://localhost:5001/api/v1/playlist/music', {
          MusicId: this.selectedSong.musicId,
          PlaylistId: this.playlists[index].playlistId
        })
          .then((response) => {
            this.$store.commit('allMusic/addArray', response.data.musicList)
          })
      } catch (error) {
        alert(error)
      // console.log(error)
      }
      window.location.href = 'http://localhost:3000/music'
    }
  }
}
</script>

<style>
.container{
    margin: auto;
}
.pagination{
  display: flex;
  justify-content: center;
  align-items: center;
}
.song{
  width: 1500px;
  padding: 10px
}
.half{
  height: 10px;
}
</style>
