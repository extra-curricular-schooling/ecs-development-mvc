// Nice to have a central location to update information. (Single Source of truth)

import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// This is the universal in memory data storage for the client side.
export default new Vuex.Store({
  // State is passed into any of your getters.
  state: {
    isAuthenticated: false
  },
  // Any function that retrieves data.
  getters: {
    isAuth: function (state) {
      return state.isAuthenticated
    }
  },
  // Any function that changes data.
  mutations: {
    signIn: function (state) {
      state.isAuthenticated = true
    }
  },
  // The exposed methods that the system uses to work with the store.
  actions: {
    signIn: function (context, payload) {
      // Commit = Call this method in the mutations.
      context.commit('signIn')
    }
  }
})
