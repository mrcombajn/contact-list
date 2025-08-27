<template>
  <div id="contact-container">
    <ul class="contact-list">
      <li class="contact-item">
        <span class="label">Email:</span>
        <span class="value">{{ email }}</span>
      </li>
      <li class="contact-item">
        <span class="label">Imię:</span>
        <span class="value">{{ name }}</span>
      </li>
      <li class="contact-item">
        <span class="label">Nazwisko:</span>
        <span class="value">{{ surname }}</span>
      </li>
    </ul>
    <button @click="$emit('showContact')">Show</button>
  </div>
</template>

<script>

export default {
  name: 'ContactListElementComponent',
  props: ['email', 'name', 'surname'],
};
</script>

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
  background: linear-gradient(135deg, #4f46e5, #3b82f6);
  color: white;
  cursor: pointer;
  transition: all 0.25s ease;
}

button:hover {
  background: linear-gradient(135deg, #4338ca, #2563eb);
  transform: translateY(-2px);
}
</style>