<template>
  <div>
    <button class="button is-primary submit-button" v-on:click="showAlert">
    Submit
    </button>
  </div>
  <!-- NOT A FAN OF ALERT().. -->
  <!-- I like Bulma's notifiacation components better... will implement in future -->
  <!-- <div class="notification is-primary">
    <button class="delete"></button>
    <strong>Congratulations!</strong><br>
    You've successfully registered your information.  Log back in to start learning!
  </div> -->
</template>

<script>
export default {
  name: 'RegistrationAlert',
  methods: {
    showAlert: function () {
      alert('Congratulations!  You have successfully registered your information.  You will now be redirected to the main page.')
      this.$router.push('/')
    }
  }
}
</script>

<style>
button {
  width: 175px;
}
</style>
