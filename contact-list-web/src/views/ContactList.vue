<template>

  <div>
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
//import { useUserStore } from '@/stores/userStore'
import axios from 'axios'
import ContactListElement from '../components/ContactListElement.vue'

const router = useRouter()
//const userStore = useUserStore()

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

onMounted(fetchData)

</script>