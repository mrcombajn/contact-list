<template>

  <div>
    <Contact v-for="(contact, index) in contacts" :key="index"
      :id="contact.id"
      :email="contact.email"
      :name="contact.name"
      :surname="contact.surname"
      :password="contact.password"
      :category="contact.category"
      :subCategory="contact.subCategory"
      :phonenumber="contact.phonenumber"
      :birthdate="contact.birthdate" />
  </div>
</template>

<script>
import axios from 'axios';
import Contact from './Contact.vue';

export default {
  name: 'ContactList',
  components: {
    Contact
  },
  data() {
    return {
      contacts: []
    };
  },
  methods: {
    async fetchContacts() {
      try
      {
        var response = await axios.get(`${process.env.VUE_APP_API_URL}/api/contact`)
        console.log(response)
        this.contacts = response.data     
      }
      catch(error){
        console.log(error)
      }
    }
  },
  mounted() {
    this.fetchContacts()
  }
};
</script>
