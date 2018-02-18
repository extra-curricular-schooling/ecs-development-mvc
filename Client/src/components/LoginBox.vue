<template>
    <form class="login-fields">
        <fieldset>
            <p>Welcome back!</p>
            <!-- NOTE TO LUIS: This login thing is a placeholder -->
            <label for="username"><b>Username</b></label><br>
            <input type="text" placeholder="username" name="username" required><br>
            <label for="password"><b>Password</b></label><br>
            <input type="password" placeholder="************" name="password" required><br>
            <!-- END -->
            <div class="clearfix">
                <button class="loginbtn">Sign In</button>
                <router-link to="Registration" tag="button">New User?  Register Here.</router-link><br>
            </div>
            <a href="#" style="color:dodgerblue">Forgot credentials?</a>
        </fieldset>
    </form>
</template>

<script>
</script>

<style>
button {
    width: 240px;
}
</style>
