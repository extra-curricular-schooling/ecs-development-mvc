<template>
  <div>
    <h1> {{msg}} </h1>
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
      msg: 'This is a request'
    }
  },
  created () {
  },
  methods: {
  }
}
</script>
