<template>
  <!-- Main Registration Form -->
  <form class="registration-form">
    <p class="warning field-element">* indicates a required field</p>

    <!-- BEGIN required fields for basic information -->
    <div class="is-field-group">
      <div class="field first-name">
        <label class="label field-element is-required">First Name</label>
        <div class="control">
          <input v-model="user.firstName" class="input" type="text" placeholder="First Name" required>
        </div>
      </div>

      <div class="field last-name">
        <label class="label field-element is-required">Last Name</label>
        <div class="control">
          <input v-model="user.lastName" class="input" type="text" placeholder="Last Name" required>
        </div>
      </div>

      <div class="field username">
        <label class="label field-element is-required">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="user.username" class="input" type="text" placeholder="Username" required>
          <span class="icon is-small is-left">
            <i class="fas fa-user"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-check"></i>
          </span>
        </div>
      </div>

      <div class="field email-address">
        <label class="label field-element is-required">Email</label>
        <div class="control has-icons-left has-icons-right">
          <input v-model="user.email" class="input" type="email" placeholder="Email" required>
          <span class="icon is-small is-left">
            <i class="fas fa-envelope"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-exclamation-triangle"></i>
          </span>
        </div>
      </div>

      <div class="field password">
        <label class="label field-element is-required">Password</label>
        <div class="control has-icons-left">
          <input v-model="user.password" class="input" type="password" placeholder="************" required>
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </div>
      </div>

      <div class="field confirm-password">
        <label class="label field-element is-required">Confirm Password</label>
        <div class="control has-icons-left">
          <input v-model="user.confirmPassword" class="input" type="password" placeholder="************" required>
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </div>
      </div>
    </div>
    <!-- END basic info fields -->

    <!-- BEGIN optional fields for mailing address -->
    <div class="is-field-group">
      <div class="field mailing-address">
        <label class="label field-element">Mailing Address</label>
        <div class="control">
          <input class="input" type="text" placeholder="Street Address">
        </div>
      </div>
      <div class="field mailing-address">
        <div class="control">
          <input class="input" type="text" placeholder="City">
        </div>
      </div>
      <div class="field is-grouped mailing-adress">
        <p class="control">
          <span class="select">
            <select>
              <option selected>State</option>
            </select>
          </span>
        </p>
        <p class="control">
          <input class="input" type="text" placeholder="Zip Code">
        </p>
      </div>
    </div>
    <!-- END mailing address fields -->

    <!-- BEGIN required security questions -->
    <div class="is-field-group">
      <div class="field security-questions">
        <label class="label field-element is-required">Security Questions</label>
        <div class="control">
          <span class="select">
            <select>
              <option selected>--select--</option>
            </select>
          </span>
        </div>
        <!-- <div class="control">
          <span class="select">
            <select v-model="user.question1">
              <v-list-tile v-for="security_qa in security_qas" v-bind:key="security_qas.question">--select--</v-list-tile>
            </select>
          </span>
        </div> -->
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input v-model="user.answer1" class="input" type="text" placeholder="Answer 1" required>
        </div>
      </div>

      <div class="field security-questions">
        <div class="control">
          <span class="select">
            <select>
              <option selected>--select--</option>
            </select>
          </span>
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input v-model="user.answer2" class="input" type="text" placeholder="Answer 2" required>
        </div>
      </div>

      <div class="field security-questions">
        <div class="control">
          <span class="select">
            <select>
              <option selected>--select--</option>
            </select>
          </span>
        </div>
      </div>
      <div class="field security-questions-answers">
        <div class="control">
          <input v-model="user.answer3" class="input" type="text" placeholder="Answer 3" required>
        </div>
      </div>
    </div>
    <!-- END security questions -->

    <div class="field form-agreements">
      <label class="checkbox">
        <input type="checkbox" checked="checked" name="remember-me-box">
        Remember me
      </label><br>
      <label class="checkbox">
        <agreement-modal></agreement-modal>
      </label>
    </div>

    <!-- BEGIN form submission options -->
    <div class="field is-grouped is-grouped-centered form-buttons">
      <p class="control">
        <router-link to="/" tag="button" class="button is-link cancel-button">
        Cancel
        </router-link>
      </p>
      <p class="control">
        <!-- NOTE: Issues with properly checking if required fields have been entered -->
        <registration-alert v-on:click="submit"></registration-alert>
        <!-- <router-link to="/" tag="button" class="button is-primary submit-button" v-on:click="submit">
        Submit
        </router-link> -->
        <!-- <button class="button is-primary submit-button" v-on:click="showAlert">
        Submit
        </button> -->
      </p>
    </div>
    <!-- END submission options -->
  </form>
</template>

<script>
import axios from 'axios'
import agreementModal from '@/components/AgreementModal'
import registrationAlert from '@/components/RegistrationAlert'

export default {
  name: 'RegistrationForm',
  components: {
    agreementModal,
    registrationAlert
  },
  data () {
    return {
      user: {
        userName: '',
        password: '',
        // confirmPassword: '',
        securityQAs: [
          { securityQuestion: '', securityAnswer: '' },
          { securityQuestion: '', securityAnswer: '' },
          { securityQuestion: '', securityAnswer: '' }
        ],
        email: '',
        firstName: '',
        lastName: '',
        // address: '',
        zipCode: '',
        city: '',
        state: ''
      },
      errors: []
    }
  },
  methods: {
    submit: () => {
      axios({
        method: 'POST',
        url: 'https://localhost:44311/Registration/SubmitRegistration',
        data: {
          userName: this.user.username,
          password: this.user.password,
          // confirmPassword: this.user.confirmPassword,
          securityQAs: [
            { securityQuestion: this.user.question1, securityAnswer: this.user.answer1 },
            { securityQuestion: this.user.question2, securityAnswer: this.user.answer2 },
            { securityQuestion: this.user.question3, securityAnswer: this.user.answer3 }
          ],
          email: this.user.email,
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          // address: this.user.address
          zipCode: this.user.zipCode,
          city: this.user.city,
          state: this.user.state
        },
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true
        }
      })
        .then(response => console.log(response))
        .catch(response => console.log(response))
    }
    /* fetchSecurityQuestions: () => {
      axios({
        method: 'GET',
        url: 'https://localhost:44313/registration/RequestSecurityQuestions'
      })
        .then(response => {
          this.security_qas = response.data
        })
        .catch(response => console.log(response))
    } */
  }
}
</script>

<style scoped>
.field-element {
  text-align: left;
}

.form-agreements {
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

button {
  width: 175px;
}
</style>
