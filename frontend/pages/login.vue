<template>
  <div
    id="login"
    name="view"
    class="container"
  >
    <v-form v-model="valid">
      <div id="login-form">
        <v-text-field
          id="username"
          v-model="username"
          label="Username"
          prepend-icon="mdi-account"
          :type="''"
          solo
          :rules="[requiredField('username','')]"
        />
        <v-text-field
          id="password"
          v-model="password"
          label="Password"
          prepend-icon="mdi-lock-reset"
          solo
          :type="'password'"
          :rules="[requiredField('password','')]"
        />
        <v-btn id="submit-btn-reset" :disabled="!valid" @click="signin()">
          Sign in
        </v-btn>

        <nuxt-link class="routerLink" to="/resetPassword">
        <v-layout id="forgetpassword"
            >Forgot your password?
            
        </v-layout>
        </nuxt-link>
      </div>
    </v-form>
  </div>
</template>

<script>
export default {
  data () {
    return {
      username: '',
      password: '',
      valid: true
    }
  },
  methods: {
    requiredField (property, re) { // finds out if field is not empty, else returns an error message.
      return field =>
        (field && field.length > 0) || `Please ${re}enter your ${property}.`
    },
    signin () {
        console.log({ username: this.username, password: this.password})
    }
  }
}
</script>

<style >
#forgetpassword:hover{
    color: white;
    text-decoration: underline;
}
#login{
    width:600px;
    height: 300px;
    border-radius: 40px;
    margin: auto;
    margin-top: 250px;
    background: black;
    box-shadow: 0px  15px 40px lightskyblue;
}
#login-form{
    margin: 45px;
}
#submit-btn-reset{
    margin: auto;
}
</style>
