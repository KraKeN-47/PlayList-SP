<template>
  <div
    id="resetPassword"
    name="view"
    class="container"
  >
    <v-form v-model="valid">
      <div id="resetPass-form">
        <v-text-field
          id="resetPass1"
          v-model="resetPass"
          label="Please enter your new password"
          prepend-icon="mdi-account"
          :type="'password'"
          solo
          :rules="[comparePasswords(),requiredField('password',''),requiredLength('password',8)]"
        />
        <v-text-field
          id="resetPass2"
          v-model="reResetPass"
          label="Please re-enter your new password"
          prepend-icon="mdi-lock-reset"
          solo
          :type="'password'"
          :rules="[comparePasswords(),requiredField('password','re-'),requiredLength('password',8)]"
        />
        <v-btn id="submit-btn-reset" :disabled="!valid" @click="submit()">
          Submit
        </v-btn>
      </div>
    </v-form>
  </div>
</template>

<script>
export default {
  data () {
    return {
      resetPass: '',
      reResetPass: '',
      valid: true
    }
  },
  methods: {
    comparePasswords () {
      return (this.reResetPass === this.resetPass) || 'Passwords do not match.' // compares if passwords match, else returns an error message.
    },
    requiredField (property, re) { // finds out if field is not empty, else returns an error message.
      return field =>
        (field && field.length > 0) || `Please ${re}enter your ${property}.`
    },
    requiredLength (property, minLength) { // measures input strings length and compares it with minimum length, else returns an error message.
      return field =>
        (field && field.length >= minLength) ||
          `${property} Must be atleast ${minLength} characters long.`
    },
    submit () {
      // eslint-disable-next-line no-console
      return console.log({ password: this.resetPass })
    }
  }
}
</script>

<style >
#resetPassword{
    width:600px;
    height: 300px;
    border-radius: 40px;
    margin: auto;
    margin-top: 250px;
    background: black;
    box-shadow: 0px  15px 40px lightskyblue;
}
#resetPass-form{
    margin: 45px;
}
#submit-btn-reset{
    margin: auto;
}
</style>
