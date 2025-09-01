<template>
    <div id="login-container">
        <button @click="backToMainPage">Powrót do strony głównej</button>
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

const backToMainPage = () => {
  router.push({ name: 'ContactList' })
}

onMounted(checkIfAuthenticated)
</script>

<style lang="css" scoped>

#login-container {
  max-width: 400px;
  max-height: 500px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  gap: 10px;
  margin: 20px auto;
  padding: 20px;
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.08);
  font-family: "Segoe UI", sans-serif;
}

button {
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 8px;
  font-weight: 600;
  color: white;
  cursor: pointer;
  transition: all 0.25s ease;
  background: linear-gradient(135deg, #4338ca, #2563eb);
  transform: translateY(-2px);
}

input {
  padding: 10px;
  border: none;
  border-radius: 8px;
  font-weight: 600;
  border: 1px black solid;
  border-radius: 12px;
  box-shadow: 0 12px 12px rgba(0,0,0,0.08);
}

button:hover {
  background: linear-gradient(135deg, #4338ca, #2563eb);
  transform: translateY(-2px);
}

</style>