import Vue from 'vue'
import Router from 'vue-router'
import Main from '../pages/main/Index'
import About from '../pages/about/Index'
import Registration from '../pages/registration/Index'
import Home from '../pages/home/Index'
import Account from '../pages/account/Index'
import Sweepstakes from '../pages/sweepstakes/Index'

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
      name: 'about',
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
      path: '/sweepstakes',
      name: 'Sweepstakes',
      component: Sweepstakes
    }
  ]
})
