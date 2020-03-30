<template>
<div class="test">
  <v-btn @click="konc"/>
  <audio controls preload="metadata" style=" width:300px;">
	<source src="" type="audio/mpeg">
	Your browser does not support the audio element.
</audio><br />
<a href="http://scriptgenerator.net/really-simple-embed-audio-player-script/" style="text-align: right;display: block"></a>
</div>
</template>
<script>
  export default{
    methods:{
      konc(){
      const pav= new Audio("http://www.hochmuth.com/mp3/Haydn_Cello_Concerto_D-1.mp3")
      pav.play();
      }
    }
  }
</script>
<style>
.test{
  margin: auto;

}
</style>