<template>
  <div id="content" class="container" name="view">
    <v-form
      ref="submit"
      v-model="valid"
      class="px-3"
      width="600px"
      height="500px"
    >
      <div id="register-form">
        <v-text-field
          id="title"
          v-model="title"
          light
          label="Please enter song title:"
          prepend-icon="mdi-text"
          counter="20"
          :rules="[requiredField('title','')]"
          solo
        />
        <v-text-field
          id="description"
          v-model="description"
          light
          prepend-icon="mdi-text"
          label="Please enter song description"
          :rules="[requiredField('description','')]"
          solo
        />
        <v-text-field
          id="link"
          v-model="link"
          light
          prepend-icon="mdi-text"
          label="linkas"
          :rules="[requiredField('link','')]"
          solo
        />
         <template>
          <div class ="file">
          <input type="file" @change="onFileSelected">
          </div>
         
        </template>

        <v-btn :disabled="!valid" @click="upload">
          Upload
        </v-btn>
      </div>
    </v-form>
  </div>
</template>
<script>
/* eslint-disable no-console */
/* eslint-disable no-mixed-operators */
/* eslint-disable no-useless-escape */
/* eslint-disable no-var */
/* eslint-disable no-unused-vars */
import axios from 'axios'
export default {
  data () {
    return {
      title: '',
      description: '',
      link: '',
      valid: true
    }
  },
  methods: {
     onFileSelected(event){
      this.selectedFile = event.target.files[0]
    },
    // validation below
    requiredField (property, re) { // finds out if field is not empty, else returns an error message.
      return field =>
        (field && field.length > 0) || `Please ${re}enter your ${property}.`
    },
    upload () {
      axios.post('https://localhost:5001/api/v1/identity/register', {
        title: this.title,
        description: this.description,
        link : this.link,
      }).then(response => console.log(response))
        .catch(error => console.log(error))
    }
  }
}
</script>
<style>

 #content{
    width:600px;
    height: 500px;
    border-radius: 40px;
    margin: auto;
    margin-top: 170px;
    background: rgb(201, 190, 170);
}
#register-form{
  margin-top: 35px;
}
#title,#description,#password,#REpassword{
  color: black;
}
</style>
