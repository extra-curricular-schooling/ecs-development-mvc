<template>
  <div id='RegAppToPortalRequest'>
    <button v-on:click='submit'>
      Hit me!
    </button>
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
      axios.post('/registration-response', {
        // hello world
      })
        // Not sure on the naming for this path...
        .then(response => {
          console.log(response)
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>
