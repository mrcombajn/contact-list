<template>
    <div>
        <input v-model="login" type="text"/>
        <input v-model="password" type="password"/>
        <button @click="tryLogin">Login</button>
    </div>
</template>


<script setup>
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'
import { useUserStore } from '@/stores/userStore'

const router = useRouter()
const userStore = useUserStore()

const login = ref('')
const password = ref('')
const isAuthenticated = ref(false)

const tryLogin = async () => {
  await userStore.login(login.value, password.value)
  isAuthenticated.value = userStore.isAuthenticated

  if (isAuthenticated.value) {
    router.push({ name: 'ContactList' })
  }
}

const checkIfAuthenticated = () => {
    if(userStore.isAuthenticated){
        router.push({ name: 'ContactList' })
    }
}

onMounted(checkIfAuthenticated)
</script>