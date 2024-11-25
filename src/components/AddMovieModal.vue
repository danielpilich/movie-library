<template>
  <div class="modal-overlay" v-if="show">
    <div class="modal">
      <h2>Add Movie</h2>
      <form @submit.prevent="addMovie">
        <label for="title">Title:</label>
        <input type="text" id="title" v-model="newMovie.title" />
        <button type="submit">Add Movie</button>
        <button @click="cancel">Cancel</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  props: ['show'],
  data() {
    return {
      newMovie: {
        title: ''
      }
    }
  },
  methods: {
    addMovie() {
      this.$emit('add-movie', this.newMovie);
      this.newMovie.title = '';
    },
    cancel() {
      this.$emit('cancel');
    }
  }
}
</script>