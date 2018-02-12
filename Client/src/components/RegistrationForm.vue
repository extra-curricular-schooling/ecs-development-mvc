<template>
  <form>
    First name: <input><br>
    Last name: <input><br>
    <button v-on:click='submit'>Push me</button>
  </form>
</template>

<script>
import axios from 'axios'

export default {
  methods: {
    submit: () => {
      // This is not a correct path... Please fix when available.
      axios({
        method: 'GET',
        url: 'https://localhost',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
  }
}
</script>
