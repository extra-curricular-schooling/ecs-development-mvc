<template>
  <!-- Main Registration Fields -->
  <form class="registration-fields">
    <p>Please register your information to get started.</p>
    <fieldset>
      <legend>Basic Info</legend>
      <label for="firstname" class="required-data"><b>First Name</b></label><br>
      <input type="text" placeholder="First Name" name="firstname" required><br>

      <label for="lastname" class="required-data"><b>Last Name</b></label><br>
      <input type="text" placeholder="Last Name" name="lastname" required><br>

      <label for="username" class="required-data"><b>Username</b></label><br>
      <input type="text" placeholder="username" name="username" required><br>

      <label for="email" class="required-data"><b>Email Address</b></label><br>
      <input type="text" placeholder="myemail@email.com" name="email" required><br>

      <label for="pswd" class="required-data"><b>Password</b></label><br>
      <input type="password" placeholder="************" name="pswd" required><br>

      <label for="confirm-pswd" class="required-data"><b>Confirm Password</b></label><br>
      <input type="password" placeholder="************" name="confirm-pswd" required><br>
    </fieldset>

    <fieldset>
      <legend>Mailing Address</legend>
      <label for="street-address"><b>Street Address</b></label><br>
      <input type="text" placeholder="Street Address" name="street-address" optional><br>

      <label for="city"><b>City</b></label><br>
      <input type="text" placeholder="City" name="city" optional><br>

      <label for="state"><b>State</b></label><br>
      <input type="text" placeholder="State" name="state" optional><br>

      <label for="zipcode"><b>Zip Code</b></label><br>
      <input type="text" placeholder="Zip Code" name="zipcode" optional><br>
    </fieldset>

    <fieldset>
      <legend>Security Questions</legend>
      <select id="questions1" onchange="showQuestions1()">
        <option value="0">--select--</option>
      </select><label class="required-data"></label><br>
      <input type="text" placeholder="Answer 1" name="answer1" required><br>

      <select id="questions2" onchange="showQuestions2()">
        <option value="0">--select--</option>
      </select><label class="required-data"></label><br>
      <input type="text" placeholder="Answer 2" name="answer2" required><br>

      <select id="questions3" onchange="showQuestions3()">
        <option value="0">--select--</option>
      </select><label class="required-data"></label><br>
      <input type="text" placeholder="Answer 3" name="answer3" required><br>
    </fieldset>

    <label>
    <input type="checkbox" checked="checked" name="rememberme-box" style="margin-bottom:12px">Remember me</label><br>

    <label>
    <input type="checkbox" name="agreement-box" style="margin-bottom:12px">
    I have read and agreed to the <a href="#" style="color:dodgerblue">Terms & Conditions</a>.</label>

    <div class="clearfix">
      <router-link to="/" tag="button">Cancel</router-link>
      <button class="registerbtn" v-on:click.prevent="submit">Register</button>
    </div>
    <!-- Terms and Conditions Modal -->
  </form>
</template>

<script>
import axios from 'axios'

export default {
  components: {
  },
  methods: {
    submit: () => {
      // This is not a correct path... Please fix when available.
      axios({
        method: 'GET',
        url: 'https://localhost:44313/registration/SayHello',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Credentials': true
        }
      })
        .then(response => console.log('It worked!'))
        .catch(response => console.log(response))
    }
  }
}
</script>

<style>
*, *:before, *:after {
  -moz-box-sizing: border-box;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
}

button {
  background-color: #E8E9E4;
  color: black;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 270px;
  opacity: 0.9;
}

button:hover {
    opacity:1;
}

fieldset {
  margin-bottom: 10px;
  border-color: #D3DCE5;
  border-width:  5px;
  background-color: #F8FCFB;
}

form {
  max-width: 550px;
  margin: 10px auto;
  padding: 0px 0px;
  border-radius: 8px;
  text-align: left;
}

hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

input[type=text], input[type=password] {
  width: 500px;
  padding: 10px;
  margin: 5px 0 25px 0;
  display: inline-block;
  border: none;
  background: #E8E9E4;
}

legend {
  font-size: 1.4em;
}

label.required-data:after {
  content: " *";
  color: red;
}

p {
  text-align: center;
}
</style>
