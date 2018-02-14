const Logger = {
  install (Vue, options) {
    // Add functionality to all components
    Vue.mixin({
      beforeCreate () {
        // Initialization happens here
      },
      created () {
        // Instance created
      },
      beforeMount () {
        // Before component is "attached" to DOM
      },
      mounted () {
        // Component is "attached" to DOM
      },
      beforeUpdate () {
        // Before data changes
      },
      updated () {
        // Data has changed
      },
      beforeDestroy () {
        // Before teardown of event listeners, watchers and child components
      },
      destroyed () {
        // Component destroyed
      }
    })

    // Add global functionality to specific instance
    Vue.log = function (message) {
      if (message.unshift) {
        message.unshift('[From Global]')
        console.log.apply(this, message)
      } else {
        console.log('[From Global]', message)
      }
    }

    // Vue.prototype.plugins.$log is a better approach to avoid confusion that it is coming
    // from a plugin and not a Vue instance. It also adds functionality to all Vue instances.
    Vue.prototype.plugins.$log = function (message) {
      if (message.unshift) {
        message.unshift('[From prototype]')
        console.log.apply(this, message)
      } else {
        console.log('[From prototype]', message)
      }
    }
  }
}

// Automatic installation of plugin within web context
if (typeof window !== 'undefined' && window.Vue) {
  window.Vue.use(Logger)
}

export default Logger
