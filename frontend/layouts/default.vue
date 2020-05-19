<template>
  <v-app id="test">
    <transition
      name="view"
    >
      <router-view />
    </transition>

    <v-navigation-drawer
      v-model="drawer"
      height="21.5%"
      dark
      :clipped="$vuetify.breakpoint.lgAndUp"
      app
      hidden:true
    >
      <div v-if="$auth.loggedIn === true">
        <nav-bar-options :is-artist="this.$auth.user.isArtist" />
      </div>
      <nuxt-link class="routerLink" to="/music">
        <v-btn block>
          Music
        </v-btn>
      </nuxt-link>
    </v-navigation-drawer>
    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="rgb(201, 190, 170)"
    >
      <v-app-bar-nav-icon id="nav-icon" @click.stop="drawer = !drawer" />
      <v-toolbar-title
        style="width: 300px"
        class="ml-0 pl-4"
      >
        <nuxt-link class="routerLink" to="/">
          <v-img id="logo" src="https://i.imgur.com/YKhKjkg.png" />
        </nuxt-link>
      </v-toolbar-title>

      <v-text-field
        id="searchbar"
        flat
        solo
        light
        hide-details
        prepend-inner-icon="mdi-magnify"
        label="Search for artists or music"
        class="hidden-sm-and-down"
        rounded=""
      />
      <v-spacer />
      <!-- Not Logged In -->
      <div v-if="!$auth.loggedIn">
        <nuxt-link class="routerLink" to="/register">
          <v-btn id="Layout-Register-BTN" outlined>
            <v-icon left>
              mdi-account-plus
            </v-icon>
            Register
          </v-btn>
        </nuxt-link>
          &nbsp;&nbsp;&nbsp;&nbsp;
        <nuxt-link class="routerLink" to="/login">
          <v-btn id="Layout-Login-BTN" outlined>
            <v-icon left>
              mdi-login
            </v-icon>
            Log-In
          </v-btn>
        </nuxt-link>
      </div>
      <!-- Logged In navbar -->
      <div v-if="$auth.loggedIn">
        <v-label>
          Hello, {{ this.$auth.user.userName }}
        </v-label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <nuxt-link class="routerLink" to="/upload">
          <v-btn v-if="$auth.user.isArtist" id="Upload-Music" outlined>
            <v-icon> mdi-cloud-upload </v-icon>
          </v-btn>
        </nuxt-link>
        <v-btn id="Layout-Logout-BTN" outlined :loggedout="true" @click="logout">
          <v-icon left>
            mdi-logout
          </v-icon>
          Log-out
        </v-btn>
      </div>
    </v-app-bar>
    <v-btn class="scroll-to-top-btn" fab color="pink" @click="scrollToTop">
      <v-icon>mdi-arrow-up-bold-outline</v-icon>
    </v-btn>
    <v-slider
      v-if="$auth.loggedIn && this.$store.state.volume.isVolumeDisp"
      id="audioSlider"
      v-model="volume"
      vertical
      class="Audio-Slider"
      min="0"
      step="0.05"
      max="1"
      prepend-icon="mdi-volume-high"
      thumb-color="black"
      color="black"
    />
    <div v-if="$auth.loggedIn && this.$store.state.playlist.isPlaylistDisp" class="playlist">
      <ul>
        <li v-for="item in this.$store.state.allplaylistmusic.playlistArr">
          {{ item.song.name }} &nbsp&nbsp&nbsp
        </li>
      </ul>
    </div>
    <music-player v-if="$auth.loggedIn" />
  </v-app>
</template>
<script>
import MusicPlayer from '@/components/MusicPlayer.vue'
import NavBarOptions from '@/components/NavBarOptions.vue'
// eslint-disable-next-line no-unused-vars
export default {
  name: 'DefaultTemp',
  components: {
    'music-player': MusicPlayer,
    'nav-bar-options': NavBarOptions
  },
  data: () => ({
    dialog: false,
    drawer: false,
    volume: 70
  }),
  computed: {
    songs () {
      return this.$store.state.allplaylistmusic.playlistArr
    }
  },
  watch: {
    volume (newVal) {
      this.$store.commit('volume/changeVolume', newVal)
    },
    songs () {}
  },
  methods: {
    scrollToTop () {
      window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
      })
    },
    logout () {
      this.$auth.logout()
      this.$store.commit('login/LOGGED_OUT')
      this.$store.commit('allplaylistmusic/LOGGED_OUT')
    }
  }
}
</script>

<style>
.routerLink{
    text-decoration: none;
}
.logo{
  height: 56px;
  width: 300px;
}
#test{
  background: url('https://images.unsplash.com/photo-1496293455970-f8581aae0e3b?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1901&q=80.png');
  background-position-y: -150px;
  background-attachment: fixed;
}
#audio{
    position: fixed;
    bottom: 50px;
    left: 20px;
}
#logo{
  height: 56px;
}
#searchbar{
  color: black;
}
.view-enter-active, .view-leave-active{
  transition: all 0.7s;
}
.view-enter-active{
  transition-delay: 0.7s;
}
.view-enter, .view-leave-active{
  opacity: 0;
  transform: scale(0);
}
.scroll-to-top-btn:hover{
  color: black;
  box-shadow: 0px  0px 20px black;
}
.scroll-to-top-btn{
  box-shadow: 0px  0px 20px rgb(255, 194, 159);
  position: fixed;
  bottom: 70px;
  right: 20px;
}
#Layout-Register-BTN:hover,#Layout-Login-BTN:hover,#nav-icon:hover,#Layout-Logout-BTN:hover,#Upload-Music:hover{
  color: black;
}
.Audio-Slider{
  left: 62.2%;
  bottom: 8%;
  position: fixed;
}
.playlist{
  left: 72%;
  bottom: 8%;
  position: fixed;
  background: black;
}
</style>
