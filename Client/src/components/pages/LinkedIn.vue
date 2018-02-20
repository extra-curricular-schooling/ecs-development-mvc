<template>
  <div id='example'>
    <share-on-linkedin></share-on-linkedin>
    <get-token></get-token>
  </div>
</template>

<script>
/* eslint-disable */
import Bulma from "bulma";
import Vue from "vue";
import Axios from "axios";

// register navigation menu
Vue.component("get-token", {
  template:
    '<button v-on:click="requestCookie" class="button is-primary">Get Validation Cookie</button>',
  methods: {
    requestCookie: function() {
      Axios({
        method: "GET",
        url: "https://localhost:44313/Auth/GenerateCookie"
      });
    }
  }
});

Vue.component("share-on-linkedin", {
  template:
    '<button v-on:click="redirectToLinkedIn" class="button is-primary">Share On LinkedIn!</button>',
  methods: {
    redirectToLinkedIn: function() {
      window.location.assign(
        "https://localhost:44313/OAuth/RedirectToLinkedIn"
      );
    }
  }
});

new Vue({
  el: "#example"
});

export default {
  name: "LinkedIn"
};
</script>