<template>
  <div class="NavBarOptions">
    <v-btn
      id="b5"
      block
    >
      MAIN
    </v-btn>
    <v-btn
      id="b1"
      block
    >
      MY PLAYLIST
    </v-btn>
    <v-btn
      v-if="isArtist"
      id="b2"
      block
    >
      MY SONGS
    </v-btn>
    <v-btn
      id="b3"
      block
    >
      ARTISTS
    </v-btn>
    <v-btn
      id="b4"
      block
    >
      SETTINGS
    </v-btn>
  </div>
</template>

<script>
export default {
  props: ['isArtist']
}
</script>

<style>
.b1{
  top: 15%;
}
.b2{
  top: 6%;
}
.b3{
  top: 9%;
}
.b4{
  top: 12%;
}
.b5{
  top: 3%;
}
.NavBarOptions{
    background: transparent;
}
</style>
