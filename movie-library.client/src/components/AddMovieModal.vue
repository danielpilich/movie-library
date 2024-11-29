<template>
  <div class="modal fade"
       id="addModal"
       aria-labelledby="addModalLabel"
       aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content bg-dark">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="addModalLabel">Add Movie</h1>
          <button type="button"
                  class="btn-close"
                  data-bs-dismiss="modal"
                  aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label for="title" class="col-form-label">Title:</label>
              <input type="text"
                     class="form-control bg-dark text-white"
                     id="title"
                     v-model="newMovie.title" />

              <div v-if="v$.newMovie.title.$error">
                {{ v$.newMovie.title.$errors[0].$message }}
              </div>
            </div>
            <div class="mb-3">
              <label for="director" class="col-form-label">Director:</label>
              <input type="text"
                     class="form-control bg-dark text-white"
                     id="director"
                     v-model="newMovie.director" />

              <div v-if="v$.newMovie.director.$error">
                {{ v$.newMovie.director.$errors[0].$message }}
              </div>
            </div>
            <div class="mb-3">
              <label for="year" class="col-form-label">Year:</label>
              <input type="number"
                     class="form-control bg-dark text-white"
                     id="year"
                     v-model="newMovie.year" />

              <div v-if="v$.newMovie.year.$error">
                {{ v$.newMovie.year.$errors[0].$message }}
              </div>
            </div>
            <div class="mb-3">
              <label for="rate" class="col-form-label">Rate:</label>
              <input type="number"
                     class="form-control bg-dark text-white"
                     id="rate"
                     v-model="newMovie.rate" />

              <div v-if="v$.newMovie.rate.$error">
                {{ v$.newMovie.rate.$errors[0].$message }}
              </div>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button"
                  class="btn btn-outline-secondary btn-sm"
                  data-bs-dismiss="modal">
            Close
          </button>
          <button v-if="!v$.$error"
                  type="button"
                  class="btn btn-outline-success btn-sm"
                  data-bs-dismiss="modal"
                  @click="addMovie">
            Add Movie
          </button>
          <button v-else
                  type="button"
                  class="btn btn-outline-success btn-sm"
                  disabled>
            Add Movie
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
    setup() {
      return { v$: useVuelidate() };
    },
    validations() {
      return {
        newMovie: {
          title: { required, maxLength: maxLength(200) },
          director: { required },
          year: { required, between: between(1900, 2200) },
          rate: { required, between: between(0, 10) },
        },
      };
    },
    data() {
      return {
        newMovie: {
          title: "",
          director: "",
          year: "",
          rate: "",
        },
      };
    },
    methods: {
      addMovie() {
        this.v$.$validate();
        if (!this.v$.$error) {
          this.$emit("add-movie", this.newMovie);
          this.newMovie = {
            title: "",
            director: "",
            year: "",
            rate: "",
          };
        }
      },
    },
    mounted() {
      this.v$.$touch();
    },
  };
</script>
