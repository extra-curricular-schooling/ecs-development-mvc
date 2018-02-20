<template>
  <div id="app">
    <img src="./assets/images/logo.png" width= "15%" height= "15%">
    <navbar/>
    <router-view/>
  </div>
</template>

<script>
/* eslint-disable */
import Vue from "vue";
import FontAwesomeIcon from "@fortawesome/vue-fontawesome";

Vue.component("navbar", {
  template:
    '<nav class="navbar is-transparent">\
  <div class="navbar-brand">\
    <div class="navbar-burger burger" data-target="navbarExampleTransparentExample">\
      <span></span>\
      <span></span>\
      <span></span>\
    </div>\
  </div>\
  \
  <div id="navbarExampleTransparentExample" class="navbar-menu">\
    <div class="navbar-start">\
      <a class="navbar-item" href="https://bulma.io/">\
        Home\
      </a>\
      <div class="navbar-item has-dropdown is-hoverable">\
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
    </div>\
    \
    <div class="navbar-end">\
      <div class="navbar-item">\
        <div class="field is-grouped">\
          <p class="control">\
            <a class="bd-tw-button button" data-social-network="Twitter" data-social-action="tweet" data-social-target="http://localhost:4000" target="_blank" href="https://twitter.com/intent/tweet?text=Bulma: a modern CSS framework based on Flexbox&amp;hashtags=bulmaio&amp;url=http://localhost:4000&amp;via=jgthms">\
              <span class="icon">\
                <i class="fab fa-twitter"></i>\
              </span>\
            </a>\
          </p>\
          <p class="control">\
            <a class="button is-primary" href="">\
              <span>Get Started</span>\
            </a>\
          </p>\
        </div>\
      </div>\
    </div>\
  </div>\
</nav>'
});

export default {
  // eslint-disable-next-line
  name: "App",
  // eslint-disable-next-line
  components: {
    FontAwesomeIcon
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
</style>
