<template>
  <div class="artistPage">
    <v-card
      v-for="(song, index) in visibleSongs"
      :key="song.path"
      color="rgb(201, 190, 170)"
      outlined
      class="song"
    >
      <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
</template>

<script>
export default {
  data: () => {
    return {
      allArtists: []
    }
  }
}
</script>

<style>
.artistPage{
    margin:auto;
}
</style>
