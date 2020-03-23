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
          id="username"
          v-model="username"
          label="Please enter your Username:"
          prepend-icon="mdi-account"
          counter="20"
          :rules="[requiredField('Username',''), requiredLength('UserName', 5), maxLength('Username',20)]"
          solo
        />
        <v-text-field
          id="email"
          v-model="email"
          prepend-icon="mdi-email"
          label="Please enter your E-Mail address"
          :rules="[requiredField('Email',''),isEmailValid()]"
          solo
        />
        <v-text-field
          id="password"
          v-model="password"
          label="Please enter your password"
          :type="'password'"
          :rules="[requiredField('password',''),requiredLength('password',8)]"
          prepend-icon="mdi-lock"
          counter
          solo
        />
        <v-text-field
          id="REpassword"
          v-model="REpassword"
          label="Re-enter your password"
          :type="'password'"
          prepend-icon="mdi-lock-reset"
          :rules="[requiredField('password','re-'),requiredLength('password',8),comparePasswords()]"
          counter
          solo
        />
        <v-label>Are you an artist?</v-label>
        <v-checkbox v-model="isArtist" label="Yes" color="teal accent-4" />
        <v-btn :disabled="!valid" @click="signUp">
          Sign Up
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
export default {
  data () {
    return {
      // Validation of email, crashes if put into methods or computed...
      reg: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/,
      isEmailValid () {
        return (this.email === '') ? '' : (this.reg.test(this.email)) || 'Invalid E-Mail address'
      },
      // variables
      username: '',
      email: '',
      isArtist: false,
      password: '',
      REpassword: '',
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
    comparePasswords () {
      return (this.password === this.REpassword) || 'Passwords do not match.' // compares if passwords match, else returns an error message.
    },
    signUp () {
      console.log({ username: this.username, email: this.email, password: this.password, isArtist: this.isArtist }) // logs input data
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
    box-shadow:0px  15px 40px lightskyblue;
    background: black;
}
#register-form{
  margin-top: 35px;
}
#username,#email,#password,#REpassword{
  color: aquamarine;
}

</style>
