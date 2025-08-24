<template>

  <ul class="space-y-4">
    <li 
      v-for="(task, index) in tasks" 
      :key="index"
      class="flex justify-between items-center p-4 border-b border-gray-200 rounded-md"
    >
      <span :class="{'line-through text-gray-500': task.completed}" class="text-lg">
        {{ task.text }}
      </span>
      <button 
        @click="toggleTaskCompletion(index)" 
        :class="task.completed ? 'bg-green-500' : 'bg-blue-500'"
        class="text-white px-4 py-2 rounded-md"
      >
        {{ task.completed ? 'Ukończone' : 'Do zrobienia' }}
      </button>
    </li>
  </ul>
</template>

<script>
export default {
  name: 'ContactList',
  data() {
    return {
      tasks: [
        { text: 'Uczyć się HTML', completed: false },
        { text: 'Przeczytać książkę', completed: true },
        { text: 'Wykonać ćwiczenie z Tailwind CSS', completed: false },
        { text: 'Napisać bloga', completed: true },
      ],
    };
  },
  methods: {
    toggleTaskCompletion(index) {
      this.tasks[index].completed = !this.tasks[index].completed;
    },
  },
};
</script>
