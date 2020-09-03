import Vue from "vue";
import VueRouter from "vue-router";
import Moment from "vue-moment";
import VueSweetalert2 from "vue-sweetalert2";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import CRUDPermission from "./components/PermissionCrud.vue";
import CreatePermission from "./components/CreatePermission.vue";
import UpdatePermission from "./components/UpdatePermission.vue";
import App from "./App.vue";

Vue.config.productionTip = false;
Vue.use(VueRouter);
Vue.use(Moment);
Vue.use(VueSweetalert2);

const routes = [
  { path: "/Permission", component: CRUDPermission },
  { path: "/CreatePermission", component: CreatePermission },
  {
    path: "/UpdatePermission",
    name: "UpdatePermission",
    component: UpdatePermission,
    props: true,
  },
  { path: "/", redirect: "/Permission" },
];

const router = new VueRouter({
  routes,
  mode: "history",
});

new Vue({
  el: "#app",
  router,
  render: (h) => h(App),
});
