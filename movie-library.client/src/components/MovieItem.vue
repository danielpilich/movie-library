<template>
  <div id="movie">
    <h2>{{ movie.title }}</h2>
    <h2>{{ movie.id }}</h2>
    <p>Director: {{ movie.director }}</p>
    <p>Year: {{ movie.year }}</p>
    <p>Rate: {{ movie.rate }}/10</p>
    <div class="button-container">
      <button @click="showEditMovieModal = true">Edit</button>
      <button @click="showDeleteMovieModal = true">Remove</button>
    </div>
    <DeleteMovieModal v-if="showDeleteMovieModal" :show="showDeleteMovieModal" :movie="movie" @confirm-delete="deleteMovie" @cancel="showDeleteMovieModal = false" />
    <EditMovieModal v-if="showEditMovieModal" :show="showEditMovieModal" :movie="movie" @edit-movie="editMovie" @cancel="showEditMovieModal = false" />
  </div>
</template>

<script>
import DeleteMovieModal from './DeleteMovieModal.vue';
import EditMovieModal from './EditMovieModal.vue';

export default {
  components: { DeleteMovieModal, EditMovieModal },
  props: ['movie'],
  data() {
    return {
      showDeleteMovieModal: false,
      showEditMovieModal: false
    }
  },
  methods: {
    deleteMovie() {
      this.$emit('delete-movie', this.movie.id);
    },
    editMovie(movie) {
    this.$emit('edit-movie', movie);
  }
  }
}
</script>