<template>
  <div class="container">
    <div v-if="showSongs" class="test2">
      <v-overlay>
        <v-btn fab depressed text x-small @click="showSongs = false">
          <v-icon>mdi-close</v-icon>
        </v-btn>
        <div>
          <v-card v-for="song in this.$store.state.allplaylistmusic.playlistArr" :key="song.path" color="rgb(201, 190, 170)" outlined class="song">
            <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <v-flex md1>
                <div>
                  <v-btn x-small fab depressed>
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
      <v-card v-for="(list,index) in playlist" :key="list.playlistContent.title" color="rgb(201, 190, 170)" outlined>
        <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <v-flex md2>
            <div class="caption white--text">
              <br>
              Title
            </div>
            <div>{{ list.playlistContent.title }}</div>
          </v-flex>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <v-flex md4>
            <div class="caption white--text">
              <br>
              Description
            </div>
            <div>{{ list.playlistContent.description }}</div>
          </v-flex>
          <v-flex md2>
            <div class="caption white--text">
              <br>
              Creator
            </div>
            <div> {{ list.playlistContent.user }} </div>
          </v-flex>
          <v-flex md1>
            <div><br></div>
            <div>
              <v-btn x-small @click="load()">
                Load playlist
              </v-btn>
            </div>
          </v-flex>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <v-flex md1>
            <div><br></div>
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
            class="px-3"
            width="600px"
            height="500px"
          >
            <div class="playlistCreateForm">
              <v-text-field
                class="title"
                light
                label="Please enter your playlist name:"
                prepend-icon="mdi-text"
                counter
                solo
              />
              <v-text-field
                class="description"
                light
                prepend-icon="mdi-text"
                label="Please enter your playlist description"
                solo
              />
              <v-btn>
                <v-icon left>
                  mdi-plus-box
                </v-icon>Create
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
export default {
  middleware: 'auth-isUser',
  data () {
    return {
      overlay: false,
      allPlaylistSongs: this.$store.state.allMusic.allMusic,
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
    showPlaylistSongs (index) {
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
    height: 250px;
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
</style>
