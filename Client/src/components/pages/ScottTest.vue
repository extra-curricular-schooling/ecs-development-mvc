<template>
  <div>
    <button v-on:click="submitRegistration">Send Post to SSO/Registration</button>
    <button v-on:click="submitResetPassword">Send Post to SSO/ResetPassword</button>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  methods: {
    submitRegistration: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/SSO/Registration',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        data: {
          'userName': 'Scott',
          'password': 'Blob',
          'securityQuestions': [
            'Hello'
          ],
          'securityAnswers': [
            'Friend'
          ]
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    },
    submitResetPassword: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/SSO/ResetPassword',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true,
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        data: {
          'userName': 'Scott',
          'password': 'Blob'
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
  }
}
</script>

<style>

</style>
