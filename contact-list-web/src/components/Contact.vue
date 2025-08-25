<template>
    <div id="contact-container">

        <div class="contact">{{ email }}</div>
        <div class="contact">{{ name }}</div>
        <div class="contact">{{ surname }}</div>
        <div class="contact">{{ password }}</div>
        <div class="contact">{{ category }}</div>
        <div class="contact">{{ subCategory }}</div>
        <div class="contact">{{ phonenumber }}</div>
        <div class="contact"><input type="date"/></div>
        <button>Edit</button>
    </div>
</template>

<script>

export default {
  name: 'ContactComponent',
  props: ['id', 'email', 'name', 'surname', 'password', 'category', 'subCategory', 'phonenumber', 'birthdate'],
  data() {
    return {
        papiez: []
    };
  },
};
</script>

<style scoped>

#contact-container {
  max-width: 700px;
  margin: 40px auto;
  padding: 30px 35px;
  background: #ffffff;
  border-radius: 16px;
  box-shadow: 0 6px 18px rgba(0, 0, 0, 0.08);
  font-family: "Segoe UI", Roboto, sans-serif;
  color: #333;
}

.contact {
  padding: 16px 0;
  border-bottom: 1px solid #eee;
  font-size: 17px;
}

.contact:last-of-type {
  border-bottom: none;
}

#contact-container button {
  margin-top: 20px;
  width: 100%;
  padding: 12px;
  font-size: 15px;
  font-weight: 600;
  border: none;
  border-radius: 12px;
  cursor: pointer;
  background: linear-gradient(135deg, #4f46e5, #3b82f6);
  color: white;
  transition: all 0.25s ease;
}

#contact-container button:hover {
  background: linear-gradient(135deg, #4338ca, #2563eb);
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(59, 130, 246, 0.35);
}

</style>