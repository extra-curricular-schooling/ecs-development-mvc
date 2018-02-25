<!-- Ideally, I wanted to contain the entire modal in here,
    while RegistrationForm just references its vue component,
    instead of just the content.... Up for future revision  -->
<template>
  <div class="container">
    <h1>Terms and Conditions</h1><br>
    <p>{{ body }}</p>
  </div>
</template>

<script>
/* eslint-disable */
import Vue from 'vue'

export default {
  name: 'AgreementModal',
  data () {
    return {
      body: 'By using this Site, you agree to be bound by, and to comply with, these Terms and Conditions. If you do not agree to these Terms and Conditions, please do not use this site.'
    }
  }
}
</script>

<style scoped>
.container {
    width: 500px;
}

h1 {
    text-align: center;
}

p {
    text-align: justify;
}
</style>
