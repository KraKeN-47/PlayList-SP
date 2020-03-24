<template>
  <v-app id="test">
    <transition
      name="view"
    >
      <router-view />
    </transition>
    <v-navigation-drawer
      v-model="drawer"
      :clipped="$vuetify.breakpoint.lgAndUp"
      app
      hidden:true
    />
    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      dark
      src="https://wallpaper-mania.com/wp-content/uploads/2018/09/High_resolution_wallpaper_background_ID_77701253455.jpg"
    >
      <v-app-bar-nav-icon id="nav-icon" @click.stop="drawer = !drawer" />
      <v-toolbar-title
        style="width: 300px"
        class="ml-0 pl-4"
      >
       <nuxt-link to="/default">
       <div class="container">
  <img src="C:\Users\Justas\source\repos\PlayList-SP2\frontend\layouts\img\logo.png" alt="Avatar" class="image">
  <div class="overlay">
    <a href="#" class="icon" title="User Profile">
      <i class="fa fa-user"></i>
    </a>
  </div>
</div>
       </nuxt-link>
      </v-toolbar-title>

      <v-text-field
        id="searchbar"
        flat
        solo
        hide-details
        prepend-inner-icon="mdi-magnify"
        label="Search for artists or music"
        class="hidden-sm-and-down"
        rounded=""
      />
      <v-spacer />
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
    </v-app-bar>
    <v-btn id="scroll-to-top-btn" fab color="pink" @click="scrollToTop">
      <v-icon>mdi-arrow-up-bold-outline</v-icon>
    </v-btn>
  </v-app>
</template>

<script>

export default {
  props: {
    // eslint-disable-next-line vue/require-default-prop
    source: String
  },
  data: () => ({
    dialog: false,
    drawer: false
  }),
  methods: {
    scrollToTop () {
      window.scroll({
        top: 0,
        left: 0,
        behavior: 'smooth'
      })
    }
  }
}
</script>

<style>
.routerLink{
    text-decoration: none;
}
#test{
  background: url('https://wallpapercave.com/wp/0l0kzYB.jpg');
}
#searchbar{
  color: white;
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
#scroll-to-top-btn:hover{
  color: aqua;
}
#scroll-to-top-btn{
  box-shadow: 0px  0px 40px skyblue;
}
#scroll-to-top-btn{
  position: fixed;
  bottom: 20px;
  right: 20px;
}
#Layout-Register-BTN:hover,#Layout-Login-BTN:hover,#nav-icon:hover{
  color: aqua;
}
.container {
  position: relative;
  width: 100%;
  max-width: 400px;
}

/* Make the image to responsive */
.image {
  width: 100%;
  height: auto;
}

/* The overlay effect (full height and width) - lays on top of the container and over the image */
.overlay {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  height: 100%;
  width: 100%;
  opacity: 0;
  transition: .3s ease;
  background-color: red;
}
</style>
