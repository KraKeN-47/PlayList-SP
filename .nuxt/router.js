import Vue from 'vue'
import Router from 'vue-router'
import { interopDefault } from './utils'
import scrollBehavior from './router.scrollBehavior.js'

const _58970a13 = () => interopDefault(import('..\\pages\\inspire.vue' /* webpackChunkName: "pages_inspire" */))
const _242f9b62 = () => interopDefault(import('..\\pages\\login.vue' /* webpackChunkName: "pages_login" */))
const _8337ab8c = () => interopDefault(import('..\\pages\\register.vue' /* webpackChunkName: "pages_register" */))
const _1463ff83 = () => interopDefault(import('..\\pages\\resetPassword.vue' /* webpackChunkName: "pages_resetPassword" */))
const _5a87f84b = () => interopDefault(import('..\\pages\\index.vue' /* webpackChunkName: "pages_index" */))

// TODO: remove in Nuxt 3
const emptyFn = () => {}
const originalPush = Router.prototype.push
Router.prototype.push = function push (location, onComplete = emptyFn, onAbort) {
  return originalPush.call(this, location, onComplete, onAbort)
}

Vue.use(Router)

export const routerOptions = {
  mode: 'history',
  base: decodeURI('/'),
  linkActiveClass: 'nuxt-link-active',
  linkExactActiveClass: 'nuxt-link-exact-active',
  scrollBehavior,

  routes: [{
    path: "/inspire",
    component: _58970a13,
    name: "inspire"
  }, {
    path: "/login",
    component: _242f9b62,
    name: "login"
  }, {
    path: "/register",
    component: _8337ab8c,
    name: "register"
  }, {
    path: "/resetPassword",
    component: _1463ff83,
    name: "resetPassword"
  }, {
    path: "/",
    component: _5a87f84b,
    name: "index"
  }],

  fallback: false
}

export function createRouter () {
  return new Router(routerOptions)
}
