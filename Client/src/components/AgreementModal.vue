<template>
  <div>
    <input type="checkbox">
    I agree to the <a v-on:click="showModal">Terms and Conditions</a>.
    <!-- Agreement Modal -->
    <div class="modal" v-bind:class="{ 'is-active' : isActive }">
      <div class="modal-background">
        <div class="modal-content">
          <div class="box">
            <h1>Terms and Conditions</h1><br>
            <p>{{ body }}</p>
          </div>
        </div>
      </div>
      <button v-on:click="hideModal" class="modal-close"></button>
    </div>
    <!-- End Modal -->
  </div>
</template>

<script>
/* eslint-disable */
import content from '!!raw-loader!@/assets/raw/agreement-content.txt'

export default {
  name: 'AgreementModal',
  data () {
    return {
      isActive: false,
      body: content
    }
  },
  methods: {
    showModal: function () {
      this.isActive = !this.isActive
    },
    hideModal: function () {
      this.isActive = !this.isActive
    }
  }
}
</script>

<style scoped>
h1 {
    text-align: center;
}

p {
    text-align: justify;
}
</style>
