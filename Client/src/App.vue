<template>
  <div id="app">
    <navbar/>
    <router-view/>
  </div>
</template>

<script>
/* eslint-disable */
import Bulma from 'bulma';
import Vue from "vue";
import FontAwesomeIcon from "@fortawesome/vue-fontawesome";

Vue.component("navbar", {
  template:
    '<nav class="level is-transparent">\
        <p class="level-item has-text-centered">\
            <a class="link is-info" href="/">Home</a>\
        </p>\
        <div class="navbar-item level-item has-dropdown is-hoverable">\
            <a class="navbar-link" href="/documentation/overview/start/">\
                Docs\
            </a>\
            <div class="navbar-dropdown is-boxed">\
                <a class="navbar-item" href="/documentation/overview/start/">\
                    Overview\
                </a>\
                <a class="navbar-item" href="https://bulma.io/documentation/modifiers/syntax/">\
                    Modifiers\
                </a>\
                <a class="navbar-item" href="https://bulma.io/documentation/columns/basics/">\
                    Columns\
                </a>\
                <a class="navbar-item" href="https://bulma.io/documentation/layout/container/">\
                    Layout\
                </a>\
                <a class="navbar-item" href="https://bulma.io/documentation/form/general/">\
                    Form\
                </a>\
                <hr class="navbar-divider">\
                <a class="navbar-item" href="https://bulma.io/documentation/elements/box/">\
                    Elements\
                </a>\
                <a class="navbar-item is-active" href="https://bulma.io/documentation/components/breadcrumb/">\
                    Components\
                </a>\
            </div>\
        </div>\
        <h1 class="level-item has-text-centered">\
            Extra Curricular Schooling\
        </h1>\
        <p class="level-item has-text-centered">\
            <a class="link is-info">Contact Us</a>\
        </p>\
        <p class="level-item has-text-centered">\
            <router-link to="Registration" tag="button" class="registration-button">Get Started</vue-router>\
        </p>\
    </nav>'
});

export default {
  // eslint-disable-next-line
  name: "App",
  // eslint-disable-next-line
  components: {
    'FontAwesomeIcon': FontAwesomeIcon
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #000000;
  margin-top: 10px;
}
h1 {
  font-family: "Days One";
  font-size: 24px;
  font-style: normal;
  font-variant: normal;
  font-weight: 500;
  line-height: 26.4px;
}

.registration-button {
  background-color: #209cee;
  padding: 15px 35px;
  color: white;
  font-size: 15px;
}
</style>
