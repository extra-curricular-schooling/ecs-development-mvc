<template>
  <div class="this-form">
    <p class="msg-to-user">Please provide your information to get started!</p>
    <registration-form></registration-form>
  </div>
</template>

<script>
import registrationForm from '@/components/RegistrationForm'
// import eventHub from '@/components/EventHub'

export default {
  name: 'RegAppToPortalRequest',
  components: {
    registrationForm
  },
  data () {
    return {
    }
  },
  created () {
  },
  methods: {
  }
}
</script>

<style>
.this-form {
  padding-left: 90px;
  padding-right: 90px;
  padding-bottom: 50px;
}
</style>
