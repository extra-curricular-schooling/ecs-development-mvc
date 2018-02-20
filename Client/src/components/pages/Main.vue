<template>
  <section class="hero is-light">
    <div class="hero-body">
      <nav class="level">
        <div class="level-left">
          <div class="box">
            <figure class="image is-128x128">
              <img src="https://bulma.io/images/placeholders/128x128.png">
            </figure>
          </div>
        </div>
        <span class="level-item has-text-centered">
          <div class="box">
            <div class="content">
              <h1>What we are about.</h1>
              <p>
                We the People of the United States, in Order to form a more perfect Union, establish Justice, insure domestic Tranquility, provide for the common defense, promote the general Welfare, and secure the Blessings of Liberty to ourselves and our Posterity, do ordain and establish this Constitution for the United States of America.
              </p>
            </div>
          </div>
        </span>
      </nav>
    </div>
  </section>
</template>

<script>
/* eslint-disable */
// import DefaultLayout from '@/layouts/Default'
export default {
  name: "Main",
  components: {
    loginBox
    // DefaultLayout
    // This is causing an ambiguous root error when rendering.
  },
  data() {
    return {
      msg: "Welcome to Your Vue.js App"
    };
  },
  methods: {
    // this.$router will talk to the vue-router (which is linked to the vue instance) to navigate to different pages.
    // this.$store will talk to the vuex store (which is linked to the vue instance) to get global data
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
