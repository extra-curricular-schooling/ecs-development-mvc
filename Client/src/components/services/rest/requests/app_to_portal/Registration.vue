<template>
  <div>

  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'RegAppToPortalRequest',
  data () {
    return {
      msg: 'This is a request'
    }
  },
  created () {},
  methods: {
    submit: (form) => {
      // This is not a correct path... Please fix when available.
      axios.post('/registration-response', {
        // Data posted will go in here.
      })
        .then(response => {
          // Collecting the response, do something here.
          console.log(response)
        })
        .catch(function (error) {
          // Catch and resolve any errors here.
          console.log(error)
        })
    }
  }
}
</script>
