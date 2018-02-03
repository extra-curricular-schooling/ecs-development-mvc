import Vue from 'vue'
import Router from 'vue-router'
import Main from '@/pages/main/index.vue'
import Registration from '@/pages/registration/index.vue'
import Home from '@/pages/home/index.vue'
import Account from '@/pages/account/index.vue'
import Sweepstakes from '@/pages/sweepstakes/index.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Main',
      component: Main
    },
    {
      path: '/registration',
      name: 'Registration',
      component: Registration
    },
    {
      path: '/home',
      name: 'Home',
      component: Home
    },
    {
      path: '/account',
      name: 'Account',
      component: Account
    },
    {
      path: '/sweepstakes',
      name: 'Sweepstakes',
      component: Sweepstakes
    }
  ]
})
