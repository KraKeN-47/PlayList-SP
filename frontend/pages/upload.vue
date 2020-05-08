<template>
  <div class="uploadd" name="view">
    <v-form
      ref="submit"
      v-model="valid"
      class="px-3"
      width="600px"
      height="500px"
    >
      <div class="upload-form">
        <v-text-field
          v-model="title"
          class="title"
          light
          label="Please enter your song title:"
          prepend-icon="mdi-text"
          counter="20"
          :rules="[requiredField('title','')]"
          solo
        />
        <v-text-field
          v-model="description"
          class="description"
          light
          prepend-icon="mdi-text"
          label="Please enter song description"
          :rules="[requiredField('description','')]"
          solo
        />
        <div class="file" enctype="multipart/form-data">
          <input type="file" @change="onFileSelected" ref="file">
        </div>
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
      valid: true,
      file: ''
    }
  },
  methods: {
    onFileSelected (event) {
      this.file = event.target.files[0]
      // this.file = this.$refs.file.files[0]
      console.log(this.file)
    },
    // validation below
    requiredField (property, re) { // finds out if field is not empty, else returns an error message.
      return field =>
        (field && field.length > 0) || `Please ${re}enter your ${property}.`
    },
    upload () {
      // const formData = new FormData()
      // formData.append('file', this.file)
      // console.log(formData)
      axios.post('https://localhost:5001/api/v1/upload', {
        title: this.title,
        description: this.description,
        file: this.file
      }).then(response => console.log(response))
        .catch(error => console.log(error))
    }
  }
}
</script>
<style>

 .uploadd{
    width:600px;
    height: 400px;
    border-radius: 40px;
    margin: auto;
    margin-top: 170px;
    background: rgb(201, 190, 170);
}
.upload-form{
  margin-top: 35px;
}
.title,.description{
  color: black;
}
</style>
