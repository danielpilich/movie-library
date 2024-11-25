<template>
  <div class="modal-overlay" v-if="show">
    <div class="modal">
      <h2>Edit Movie</h2>
      <form @submit.prevent="saveMovie">
        <label for="title">Title:</label>
        <input type="text" id="title" v-model="editedMovie.title" />
        <button type="submit">Save Changes</button>
        <button @click="cancel">Cancel</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    show: Boolean,
    movie: Object
  },
  data() {
    return {
      editedMovie: { ...this.movie }
    }
  },
  methods: {
    saveMovie() {
      this.$emit('edit-movie', this.editedMovie);
      this.cancel();
    },
    cancel() {
      this.$emit('cancel');
    }
  }
}
</script>