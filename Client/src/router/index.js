import Vue from 'vue'
import Router from 'vue-router'
import Main from '@/components/pages/Main'
import About from '@/components/pages/About'
import Registration from '@/components/pages/Registration'
import Home from '@/components/pages/Home'
import Account from '@/components/pages/Account'
import Sweepstake from '@/components/pages/Sweepstake'
import MissingPage from '@/components/pages/MissingPage'

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
    },
    // Does not know how to handle 404 errors. Might want to build in a catch all page right here.
    {
      path: '/404',
      name: 'MissingPage',
      component: MissingPage
    }
  ]
})
