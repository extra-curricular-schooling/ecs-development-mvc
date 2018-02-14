// Nice to have a central location to update information. (Single Source of truth)
import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

// This is the universal in memory data storage for the client side.
export default new Vuex.Store({
  // If we want to expand the store to hold different objects/abstractions,
  // we could use modules to organize them.
  // modules: {}

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
  },

  // If strict should be enabled during development.
  strict: debug
})
