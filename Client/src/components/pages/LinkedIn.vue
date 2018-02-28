<template>
  <div>
    <get-token></get-token>
    <LinkedInPostModal/>
  </div>
</template>

<script>
/* eslint-disable */
import Bulma from "bulma";
import Vue from "vue";
import Axios from "axios";
import LinkedInPostModal from '@/components/LinkedInPostModal'

// DELETE this during production, temporary token to access linkedin resource
Vue.component("get-token", {
  template:
    '<button v-on:click="requestCookie" class="button is-primary">Get Validation Cookie</button>',
  methods: {
    requestCookie: function() {
      Axios({
        method: "GET",
        url: "https://localhost:44311/Auth/GenerateCookie"
      }).then(function(response) {
        window.sessionStorage.setItem("auth_token", response.data.auth_token);
      });
    }
  }
});

// We need this global button in order to link a user to their LinkedIn account
Vue.component("connect-to-linkedin", {
  template:
    '<button v-on:click="redirectToLinkedIn" class="button is-primary">Use LinkedIn!</button>',
  methods: {
    redirectToLinkedIn: function() {
      window.location.assign(
        "https://localhost:44311/OAuth/RedirectToLinkedIn?authtoken=" +
          window.sessionStorage.auth_token
      );
    }
  }
});

// Global modal that can be used to submit post data to our server to share on LinkedIn
Vue.component("linkedin-post-modal", {
  template:
    '<div class="modal">\
      <div class="modal-background"></div>\
      <div class="modal-card">\
        <header class="modal-card-head">\
          <p class="modal-card-title">Share this article on LinkedIn!</p>\
          <button class="delete" aria-label="close"></button>\
        </header>\
        <section class="modal-card-body">\
          <!-- Content ... -->\
        </section>\
        <footer class="modal-card-foot">\
          <button class="button is-success">Post on LinkedIn</button>\
          <button class="button">Cancel</button>\
        </footer>\
      </div>\
    </div>',
  methods: {

  }
});

export default {
  name: "LinkedIn",
  components: {
    'LinkedInPostModal': LinkedInPostModal
  }
};
</script>