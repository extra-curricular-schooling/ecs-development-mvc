<template>
  <form>
    <div class="container">
      <p>Please register your information to get started.</p>
      <hr>

      <label for="firstname"><b>First Name</b></label><br>
      <input type="text" placeholder="Jane" name="firstname" required><br>

      <label for="lastname"><b>Last Name</b></label><br>
      <input type="text" placeholder="Doe" name="lastname" required><br>

      <label for="username"><b>Username</b></label><br>
      <input type="text" placeholder="janedoe123" name="username" required><br>

      <label for="email"><b>Email Address</b></label><br>
      <input type="text" placeholder="janedoe123@email.com" name="email" required><br>

      <label for="pswd"><b>Password</b></label><br>
      <input type="password" placeholder="********" name="pswd" required><br>

      <label for="pswd_repeat"><b>Confirm Password</b></label><br>
      <input type="password" placeholder="********" name="pswd_repeat" required><br>

      <p>By creating an account, you agree to our <a href="#" style="color:dodgerblue">Terms & Privacy</a>.</p>

      <div class="clearfix">
        <button type="button" class="cancelbtn">Cancel</button>
        <button type="submit" class="registerbtn">Register</button>
      </div>
    </div>
  </form>
</template>

<script>
import axios from 'axios'

export default {
  methods: {
    submit: () => {
      // This is not a correct path... Please fix when available.
      axios({
        method: 'GET',
        url: 'https://localhost/registration/SayHello',
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

* {box-sizing: border-box}

  input[type=text], input[type=password] {
  width: 500px;
  padding: 13px;
  margin: 5px 0 30px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
  }

  hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
  }

  button {
  background-color: #D3DCE5;
  color: black;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 250px;
  opacity: 0.9;
  }

  button:hover {
    opacity:1;
  }

</style>
