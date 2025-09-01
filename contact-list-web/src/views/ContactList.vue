<template>

  <div>
    <button v-if="userStore.isAuthenticated" @click="addContact">Dodaj nowy kontakt</button>
    <ContactListElement v-for="(contact, index) in contacts" :key="index"
      :id="contact.id"
      :email="contact.email"
      :name="contact.name"
      :surname="contact.surname" 
      @showContact="showContact(contact.id)"/>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useUserStore } from '@/stores/userStore'
import axios from 'axios'
import ContactListElement from '../components/ContactListElement.vue'

const router = useRouter()
const userStore = useUserStore()

const contacts = ref([])

const fetchData = async () => {
  try {
    const response = await axios.get(`${process.env.VUE_APP_API_URL}/api/contact`)
    contacts.value = response.data
  } catch (error) {
    console.error(error)
  }
}

const showContact = (id) => {
  router.push({ name: 'Contact', params: { id } })
}

const addContact = () => {
  router.push({ name: 'AddContact' })
}

onMounted(fetchData)

</script>

<style lang="css" scoped>
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

button:hover {
  background: linear-gradient(135deg, #4338ca, #2563eb);
  transform: translateY(-2px);
}

</style>