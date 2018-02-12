<template>
  <button v-on:click.prevent='submit'>Push me</button>
</template>

<script>
import axios from 'axios'

export default {
  methods: {
    submit: () => {
      // This is not a correct path... Please fix when available.
      axios({
        method: 'GET',
        url: 'https://localhost/registration/SayHello',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true
        }
      })
        .then(response => console.log('It worked!'))
        .catch(response => console.log(response))
    }
  }
}
</script>
