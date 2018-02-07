import Vue from 'vue'
import Router from 'vue-router'
import Main from '@/pages/Main'
import About from '@/pages/About'
import Registration from '@/pages/Registration'
import Home from '@/pages/Home'
import Account from '@/pages/Account'
import Sweepstake from '@/pages/Sweepstake'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Main',
      component: Main
    },
    {
      path: '/about',
      name: 'About',
      component: About
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
      path: '/sweepstake',
      name: 'Sweepstake',
      component: Sweepstake
    }
  ]
})
