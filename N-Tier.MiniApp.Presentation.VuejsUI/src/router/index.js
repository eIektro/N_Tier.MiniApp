import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import Home from '@/components/Home'
import NotFound from '@/components/NotFound'
import KullaniciListComponentVue from '../components/kullanici/KullaniciList.component.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/kullanici/list',
      name: 'KullaniciList',
      component: KullaniciListComponentVue
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    },
    {
      path: '/HelloWorld',
      name: 'HelloWorld',
      component: HelloWorld
    }
  ]
})
