<template>
  <div id="movie">
    <h2>{{ movie.title }}</h2>
    <h2>{{ movie.id }}</h2>
    <div class="button-container">
      <button @click="editMovie">Edit</button>
      <button @click="showDeleteMovieModal = true">Remove</button>
    </div>
    <DeleteMovieModal v-if="showDeleteMovieModal" :show="showDeleteMovieModal" :movie="movie" @confirm-delete="deleteMovie" @cancel="showDeleteMovieModal = false" />
  </div>
</template>

<script>
import DeleteMovieModal from './DeleteMovieModal.vue';

export default {
  components: { DeleteMovieModal },
  props: ['movie'],
  data() {
    return {
      showDeleteMovieModal: false
    }
  },
  methods: {
    deleteMovie() {
      this.$emit('delete-movie', this.movie.id);
    },
    editMovie() {
      this.$emit('edit-movie', this.movie);
    }
  }
}
</script>