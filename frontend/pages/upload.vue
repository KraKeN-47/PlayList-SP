<template>
  <div id="content" class="container" name="view">
    <v-form
      ref="submit"
      v-model="valid"
      class="px-3"
      width="600px"
      height="500px"
    >
      <div id="Upload">
        <v-text-field
          id="Title"
          v-model="Title"
          light
          label="Title"
          prepend-icon="mdi-comment"
          counter="20"
          :rules="[requiredField('Title','')]"
          solo
        />
        <v-text-field
          id="Description"
          v-model="Description"
          light
          prepend-icon="mdi-comment"
          label="Description"
          :rules="[requiredField('Description','')]"
          solo
        />
        <v-text-field
          id="File"
          v-model="File"
          light
          label="File"
          prepend-icon="mdi-file"
          counter
          solo
        />
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
      file: '',
      valid: true
    }
  },
  methods: {
    // validation below
    requiredField (property, re) { // finds out if field is not empty, else returns an error message.
      return field =>
        (field && field.length > 0) || `Please ${re}enter your ${property}.`
    },
    requiredLength (property, minLength) { // measures input strings length and compares it with minimum length, else returns an error message.
      return field =>
        (field && field.length >= minLength) ||
          `${property} Must be atleast ${minLength} characters long.`
    },
    maxLength (property, maxLength) { // measures input strings length and compares it with maximum length, else returns an error message.
      return field => (field && field.length <= maxLength || `${property} is too long, max ${maxLength} characters long.`)
    },
    upload () {
       title = this.title;
       description = this.description;
       file = this.file;
    }
  }
}
</script>
<style>

 #content{
    width:600px;
    height: 300px;
    border-radius: 40px;
    margin: auto;
    margin-top: 170px;
    background: rgb(201, 190, 170);
}
#register-form{
  margin-top: 35px;
}
#title,#description,#file{
  color: black;
}
</style>
