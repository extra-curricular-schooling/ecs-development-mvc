<template>
    <div>
        <div class="greeting">Hello {{name}}{{exclamationMarks}}</div>
        <button @click="decrement">-</button>
        <button @click="increment">+</button>
    </div>
</template>

<script lang='ts'>
import Vue from "vue"
export default Vue.extend({
})
</script>

<style>
.greeting {
    font-size: 20px;
}
</style>
