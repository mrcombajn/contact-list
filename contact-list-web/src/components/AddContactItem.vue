<script setup>
import { reactive } from 'vue'
import axios from 'axios'
import { useUserStore } from '@/stores/userStore'
import { useRouter } from 'vue-router'

const userStore = useUserStore()
const router = useRouter()

const contact = reactive({
  email: '',
  name: '',
  surname: '',
  password: '',
  phoneNumber: '',
  category: '',
  subCategory: '',
  birthdayDate: ''
})

const addContact = async () => {
    try {
        await axios.post(
        `${process.env.VUE_APP_API_URL}/api/contact`,
        contact,
        { headers: { Authorization: `Bearer ${userStore.token}` }}
        )    

        router.push({ name: 'ContactList' })
    } catch(error) {
        console.error(error)
    }
}

const backToMainPage = () => {
  router.push({ name: 'ContactList' })
}

</script>

<template>
  <div id="contact-container">
    <button @click="backToMainPage">Powrót do strony głównej</button>

    <ul class="contact-list">
      <li class="contact-item">
        <span class="label">Email:</span>
        <span class="value"><input type="text" v-model="contact.email"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Imię:</span>
        <span class="value"><input type="text" v-model="contact.name"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Nazwisko:</span>
        <span class="value"><input type="text"  v-model="contact.surname"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Hasło:</span>
        <span class="value"><input type="password" v-model="contact.password"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Numer telefonu:</span>
        <span class="value"><input type="text" v-model="contact.phoneNumber"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Kategoria:</span>
        <span class="value">
          <select v-model="contact.category">
            <option>służbowy</option>
            <option>prywatny</option>
            <option>inny</option>
          </select>
        </span>
      </li>
      <li class="contact-item" v-if="contact.category !== 'prywatny'">
        <span class="label">Podkategoria:</span>
        <span class="value">
          <select v-model="contact.subCategory" v-if="contact.category !== 'inny'">
            <option>szef</option>
            <option>klient</option>
          </select>
          <input v-else type="text"/>
        </span>
      </li>
      <li class="contact-item">
        <span class="label">Data urodzin:</span>
        <span class="value">
          <input type="date" v-model="contact.birthdayDate">
        </span>
      </li>
    </ul>
    <button class="edit" @click="addContact">Add</button>
  </div>
</template>

<style scoped>

#contact-container {
  max-width: 400px;
  margin: 20px auto;
  padding: 20px;
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.08);
  font-family: "Segoe UI", sans-serif;
}

.contact-list {
  list-style: none;
  padding: 0;
  margin: 0 0 15px 0;
}

.contact-item {
  display: flex;
  justify-content: space-between;
  padding: 10px 0;
  border-bottom: 1px solid #eee;
}

.contact-item:last-child {
  border-bottom: none;
}

.label {
  font-weight: 600;
  color: #555;
}

.value {
  color: #222;
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
}

button.delete {
  background-color: red;
}
button.edit {
  background: linear-gradient(135deg, #4f46e5, #3b82f6);
}

button.edit:hover {
  background: linear-gradient(135deg, #4338ca, #2563eb);
  transform: translateY(-2px);
}
</style>