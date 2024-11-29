<template>
  <div
    class="modal fade"
    :id="`editModal-${movie.id}`"
    tabindex="-1"
    aria-labelledby="editModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content bg-dark text-white">
        <div class="modal-header">
          <h5 class="modal-title" id="editModalLabel">Edit Movie</h5>
          <button
            type="button"
            class="btn-close btn-close-white"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label for="movie-title" class="col-form-label">Title:</label>
              <input
                type="text"
                class="form-control bg-dark text-white"
                id="movie-title"
                v-model="editedMovie.title"
              />

              <div v-if="v$.editedMovie.title.$error">
                {{ v$.editedMovie.title.$errors[0].$message }}
              </div>
            </div>
            <div class="mb-3">
              <label for="movie-director" class="col-form-label"
                >Director:</label
              >
              <input
                type="text"
                class="form-control bg-dark text-white"
                id="movie-director"
                v-model="editedMovie.director"
              />
            </div>
            <div class="mb-3">
              <label for="movie-year" class="col-form-label">Year:</label>
              <input
                type="number"
                class="form-control bg-dark text-white"
                id="movie-year"
                v-model="editedMovie.year"
              />

              <div v-if="v$.editedMovie.year.$error">
                {{ v$.editedMovie.year.$errors[0].$message }}
              </div>
            </div>
            <div class="mb-3">
              <label for="movie-rate" class="col-form-label">Rate:</label>
              <input
                type="number"
                class="form-control bg-dark text-white"
                id="movie-rate"
                v-model="editedMovie.rate"
              />

              <div v-if="v$.editedMovie.rate.$error">
                {{ v$.editedMovie.rate.$errors[0].$message }}
              </div>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-outline-secondary btn-sm"
            data-bs-dismiss="modal"
          >
            Close
          </button>
          <button
            type="button"
            class="btn btn-outline-info btn-sm"
            data-bs-dismiss="modal"
            @click="editMovie"
          >
            Edit Movie
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useVuelidate } from "@vuelidate/core";
import { required, maxLength, between } from "@vuelidate/validators";

export default {
  props: {
    movie: Object,
  },
  setup() {
    return { v$: useVuelidate() };
  },
  validations() {
    return {
      editedMovie: {
        title: { required, maxLength: maxLength(200) },
        director: {},
        year: { required, between: between(1900, 2200) },
        rate: { between: between(0, 10) },
      },
    };
  },
  data() {
    return {
      editedMovie: {},
    };
  },
  watch: {
    movie: {
      immediate: true,
      handler(newValue) {
        this.editedMovie = { ...newValue };
      },
    },
  },
  methods: {
    editMovie() {
      this.v$.$validate();
      if (!this.v$.$error) {
        this.$emit("edit-movie", this.editedMovie);
        this.editedMovie = {};
      }
    },
  },
};
</script>
