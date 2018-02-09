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
      axios.get('https://localhost:44313/registration/sayHello', {
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
