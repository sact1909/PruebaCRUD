import Vue from 'vue'
//import App from './App.vue'
import HelloWorld from './components/HelloWorld.vue'
import MostrarDatos from './components/MostrarDatos.vue'
const NotFound = { template: '<p>Page not found</p>' }

Vue.config.productionTip = false

const routes = {
  '/': HelloWorld,
  '/MostrarDatos': MostrarDatos
}

new Vue({
  el: '#app',
  data: {
    currentRoute: window.location.pathname
  },
  computed: {
    ViewComponent () {
      return routes[this.currentRoute] || NotFound
    }
  },
  render (h) { return h(this.ViewComponent) }
})

/*
new Vue({
  render: h => h(App),
}).$mount('#app')
*/