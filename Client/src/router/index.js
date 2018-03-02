import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Main',
      component: () => import('@/components/pages/Main')
    },
    {
      path: '/about',
      name: 'About',
      component: () => import('@/components/pages/About')
    },
    {
      path: '/registration',
      name: 'Registration',
      component: () => import('@/components/pages/Registration')
    },
    {
      path: '/home',
      name: 'Home',
      component: () => import('@/components/pages/Home')
    },
    {
      path: '/account',
      name: 'Account',
      component: () => import('@/components/pages/Account')
    },
    {
      path: '/sweepstake',
      name: 'Sweepstake',
      component: () => import('@/components/pages/Sweepstake')
    },
    // Does not know how to handle 404 errors. Might want to build in a catch all page right here.
    {
      path: '/404',
      name: 'MissingPage',
      component: () => import('@/components/pages/MissingPage')
    },
    {
      path: '/linkedin',
      name: 'LinkedIn',
      component: () => import('@/components/pages/LinkedIn')
    },
    {
      path: '/ScottTest',
      name: 'ScottTest',
      component: () => import('@/components/pages/ScottTest')
    }
  ]
})
