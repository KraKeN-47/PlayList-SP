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
      <div class="NOTLOGGEDIN">
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
      <!-- Logged In -->
      <div class="LOGGEDIN">
        <v-btn outlined>
          <v-icon left>
            mdi-logout
          </v-icon>
          Log-out
        </v-btn>
      </div>
    </v-app-bar>
    <v-btn id="scroll-to-top-btn" fab color="pink" @click="scrollToTop">
      <v-icon>mdi-arrow-up-bold-outline</v-icon>
    </v-btn>
  </v-app>
</template>
<script>
// eslint-disable-next-line no-unused-vars
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
.logo{
  height: 56px;
  width: 300px;
}
#test{
  background: url('https://images.unsplash.com/photo-1496293455970-f8581aae0e3b?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1901&q=80.png');
  background-position-y: -150px;
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
#scroll-to-top-btn:hover{
  color: orange;
}
#scroll-to-top-btn{
  box-shadow: 0px  0px 40px orange;
}
#scroll-to-top-btn{
  position: fixed;
  bottom: 70px;
  right: 20px;
}
#Layout-Register-BTN:hover,#Layout-Login-BTN:hover,#nav-icon:hover{
  color: orange;
}

</style>
