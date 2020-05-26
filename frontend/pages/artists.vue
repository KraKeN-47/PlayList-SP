<template>
  <div class="artistPage">
    <v-card
      v-for="artist in allArtists"
      :key="artist.id"
      color="rgb(201, 190, 170)"
      outlined
      class="artist"
    >
      <v-layout row wrap>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <v-flex class="artistFlex">
          <div class="caption black--text">
            Artist
          </div>
          <div class="black--text">
            {{ artist.userName }}
          </div>
        </v-flex>
      </v-layout>
    </v-card>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data: () => {
    return {
      allArtists: []
    }
  },
  async created () {
    try {
      await axios.get('https://localhost:5001/api/v1/identity/artists').then((response) => { this.allArtists = response.data.artistsList })
    } catch (error) {
      alert(error)
      console.log(error)
    }
  }
}
</script>

<style>
.artistPage{
    margin:auto;
}
.artist {
    width: 200px;
    padding: 5px;
}
</style>
