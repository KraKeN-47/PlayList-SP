<template>
  <div class="container">
    <ul>
      <li v-for="item in music">
        {{ item.song.title }} <v-spacer />  {{ item.song.description }}  <v-spacer />   {{ item.song.artist }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data () {
    return {
      music: [
        {
          song: {
            title: 'First song title',
            description: 'First song desc',
            path: 'C:\\Users\\Dom\\Desktop\\PlayList-SP\\frontend\\assets\\YES.mp3',
            artist: 'Dom'
          }
        },
        {
          song: {
            title: 'Second song title',
            description: 'Second song desc',
            path: 'C:\\Users\\Dom\\Desktop\\PlayList-SP\\frontend\\assets\\Astronomical.mp3',
            artist: 'Domas'
          }
        }
      ]
    }
  }
}
</script>

<style>
.container{
    margin: auto;
}
</style>
