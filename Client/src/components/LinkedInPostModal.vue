<template>
  <div>
    <button v-on:click="toggleLinkedInModal" class="button is-primary">Share on LinkedIn!</button>
    <div class="modal" v-bind:class="{ 'is-active' : isActive }">
      <div class="modal-background"></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Share this article on LinkedIn!</p>
          <button class="delete" aria-label="close" v-on:click="toggleLinkedInModal"></button>
        </header>
        <section class="modal-card-body">
          <p class="warning field-element">* indicates a required field</p>
          <div class="is-field-group">
            <div class="field comment">
              <label class="label field-element is-required">Comment</label>
              <div class="control">
                <input v-model="postData.comment" class="input" type="text" placeholder="Comment" required>
              </div>
            </div>
            <div class="field comment">
              <label class="label field-element is-required">Privacy Settings</label>
              <input type="radio" id="public" value="public" v-model="postData.code">
              <label for="public">Public</label>
              <br>
              <input type="radio" id="connections-only" value="connections-only" v-model="postData.code">
              <label for="connections-only">Connections Only</label>
            </div>
          </div>
        </section>
        <section class="hero is-info">
          <div class="hero-body">
            <a>Preview</a>
            <div class="box">
              <article class="media">
              <figure class="media-left">
                <p class="image is-64x64">
                  <img src="https://bulma.io/images/placeholders/128x128.png">
                </p>
              </figure>
                <div class="media-content">
                  <div class="content">
                    <p>
                      <strong>John Smith</strong><br>
                      <small>Occupation here.</small><br>
                      <small>{{currentDateTime.toString()}}</small><br>
                      <br>
                      {{postData.comment}}
                    </p>
                  </div>
                  <div class="container is-fluid">
                    <div class="card">
                      <div class="card-image">
                        <figure class="image is-square">
                          <img src="https://media.licdn.com/media/AAMABABqAAIAAQAAAAAAAA7yAAAAJGU1OTQ2NGFlLTNjNzEtNGZjOS04NjVkLWIxNjQ4NTY5ZjNlYw.png" alt="Placeholder image">
                        </figure>
                      </div>
                      <footer class="card-footer">
                        <span class="card-footer-item">
                          <span class="content">
                            {{postData.title}}
                            <br>
                            <small>{{postData.submittedurl}}</small>
                          </span>
                        </span>
                      </footer>
                    </div>
                  </div>
                  <hr class="dropdown-divider">
                  <nav class="level is-mobile">
                    <div class="level-left">
                      <a class="level-item">
                        <span class="icon is-small"><i class="fas fa-reply"></i></span>
                      </a>
                      <a class="level-item">
                        <span class="icon is-small"><i class="fas fa-retweet"></i></span>
                      </a>
                      <a class="level-item">
                        <span class="icon is-small"><i class="fas fa-heart"></i></span>
                      </a>
                    </div>
                  </nav>
                </div>
                <div class="media-right">
                  <button class="delete"></button>
                </div>
              </article>
            </div>
          </div>
        </section>
        <footer class="modal-card-foot">
          <button class="button is-success">Post on LinkedIn</button>
          <button class="button" v-on:click="toggleLinkedInModal">Cancel</button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import Axios from 'axios'
export default {
  name: 'LinkedInPostModal',
  data () {
    return {
      isActive: false,
      postData: {
        comment: 'Check this article I found on ECS!',
        title: 'Placeholder title',
        description: '',
        submittedurl: 'https://developer.linkedin.com/',
        code: 'connections-only'
      },
      currentDateTime: new Date()
    }
  },
  methods: {
    toggleLinkedInModal: function () {
      this.isActive = !this.isActive
    },
    shareToLinkedIn: function () {
      Axios({
        method: 'POST',
        url: 'https://localhost:44311/LinkedIn/SharePost'
      }).then(function (response) {
        window.sessionStorage.setItem('auth_token', response.data.auth_token)
      })
    }
  }
}
</script>

<style scoped>
.field-element {
  text-align: left;
}

.is-field-group:after {
  content: "\A";
  white-space: pre;
}

.is-field-group:before {
  content: "\A";
  white-space: pre;
}

.is-required:after {
  content: " *";
  color: red;
}

.modal-content {
  padding-top: 100px;
}

.warning {
  color: red;
  font-size: 12px;
}
</style>
