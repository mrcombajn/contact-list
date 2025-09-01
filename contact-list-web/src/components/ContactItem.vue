<script setup>
import { useRoute, useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'
import axios from 'axios'
import { useUserStore } from '@/stores/userStore'

const route = useRoute()
const router = useRouter()
const userStore = useUserStore()

const contact = ref(null)

onMounted(async () => {
  try {
    const response = await axios.get(
      `${process.env.VUE_APP_API_URL}/api/contact/${route.params.id}`)

    contact.value = response.data
  } catch (err) {
    console.error(err)
  }
})

const editContact = async () => {
  try {
    var rawData = Object.assign({}, contact.value)

    const response = await axios.put(
      `${process.env.VUE_APP_API_URL}/api/contact/${route.params.id}`,
      rawData,
      { headers: { Authorization: `Bearer ${userStore.token}` }}
    )
    contact.value = response.data

    router.push({name: "ContactList" })
  } catch (err) {
    console.error(err)
  }
}

const deleteContact = async () => {
  try  {
    await axios.delete(
      `${process.env.VUE_APP_API_URL}/api/contact/${route.params.id}`,
      { headers: { Authorization: `Bearer ${userStore.token}` }}
    )

    router.push({name: "ContactList"})
  } catch (err) {
    console.error(err)
  }
}

const backToMainPage = () => {
  router.push({ name: 'ContactList' })
}

</script>

<template>
  <div id="contact-container" v-if="contact">
    <button @click="backToMainPage">Powrót do strony głównej</button>
    <ul class="contact-list">
      <li class="contact-item">
        <span class="label">Email:</span>
        <span class="value"><input type="text" value="contact.email" v-model="contact.email"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Imię:</span>
        <span class="value"><input type="text" value="contact.name" v-model="contact.name"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Nazwisko:</span>
        <span class="value"><input type="text" value="contact.surname" v-model="contact.surname"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Hasło:</span>
        <span class="value"><input type="password" value="contact.password" v-model="contact.password"/></span>
      </li>
      <li class="contact-item">
        <span class="label">Numer telefonu:</span>
        <span class="value"><input type="text" value="contact.phoneNumber" v-model="contact.phoneNumber"/></span>
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
          <input type="date" v-model.lazy="contact.birthdayDate">
        </span>
      </li>
    </ul>
    <button @click="editContact" class="edit">Edit</button>
    <button @click="deleteContact" class="delete">Delete</button>
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