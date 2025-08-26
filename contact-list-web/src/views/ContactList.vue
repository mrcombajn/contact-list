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
      :phoneNumber="contact.phoneNumber"
      :birthdate="contact.birthdate" />
  </div>
</template>

<script>
import axios from 'axios';
import Contact from '../components/Contact.vue';

export default {
  name: 'ContactList',
  components: {
    Contact
  },
  data() {
    return {
      contacts: [],
      predefinedCategories: [],
      predefinedSubCategories: []
    };
  },
  methods: {
    async fetchData() {
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
    this.fetchData()
  }
};
</script>
