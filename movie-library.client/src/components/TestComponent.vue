<template>
  <div
    class="modal fade"
    id="exampleModal"
    tabindex="-1"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content bg-dark">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">Add Movie</h1>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label for="title" class="col-form-label">Title:</label>
              <input
                type="text"
                class="form-control"
                id="title"
                v-model="newMovie.title"
              />
            </div>
            <div class="mb-3">
              <label for="director" class="col-form-label">Director:</label>
              <input
                type="text"
                class="form-control"
                id="director"
                v-model="newMovie.director"
              />
            </div>
            <div class="mb-3">
              <label for="year" class="col-form-label">Year:</label>
              <input
                type="number"
                class="form-control"
                id="year"
                v-model="newMovie.year"
              />
            </div>
            <div class="mb-3">
              <label for="rate" class="col-form-label">Rate:</label>
              <input
                type="number"
                class="form-control"
                id="rate"
                v-model="newMovie.rate"
              />
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-secondary"
            data-bs-dismiss="modal"
          >
            Close
          </button>
          <button type="button" class="btn btn-primary" @click="addMovie">
            Add Movie
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
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
      this.$emit("add-movie", this.newMovie);
      this.newMovie = {
        title: "",
        director: "",
        year: "",
        rate: "",
      };
    },
  },
};
</script>
