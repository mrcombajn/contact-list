import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import { createPinia } from 'pinia'
import { useUserStore } from './stores/userStore'
import App from './App.vue'
import LoginForm from './views/LoginForm.vue'
import Contact from './components/Contact.vue';
import ContactList from './views/ContactList.vue'

const routes = [
    { path: '/', name: 'Home', component: LoginForm },
    { path: '/login', name: 'Login', component: LoginForm },
    { path: '/contactlist', name: 'ContactList', component: ContactList },
    { path: '/contact/:id', name: 'Contact', component: Contact, meta: { requiresAuth: true }},
    { path: '/contact/add', name: 'Add Contact', component: Contact, meta: { requiresAuth: true }}
];

const router = createRouter({
  history: createWebHistory(),
  routes,
})

router.beforeEach((to, from, next) => {
  const userStore = useUserStore()

  if (to.meta.requiresAuth && !userStore.token) {
    next('/login')
  } else {
    next()
  }
})

const app = createApp(App)
app.use(createPinia())
app.use(router)
app.mount('#app')
