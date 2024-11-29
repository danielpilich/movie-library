<template>
  <div class="col-md-4 col-sm-6 g-3">
    <div class="card bg-dark text-white h-100 shadow">
      <div class="card-body">
        <h4 class="card-title">{{ movie?.title }}</h4>
        <p class="card-text">
          <strong>Director:</strong> {{ movie?.director }}<br />
          <strong>Year:</strong> {{ movie?.year }}<br />
          <strong>Rate:</strong> {{ movie?.rate }}/10
        </p>
      </div>
      <div class="card-footer d-flex justify-content-between">
        <button type="button"
                class="btn btn-outline-info btn-sm"
                data-bs-toggle="modal"
                :data-bs-target="`#editModal-${movie.id}`">
          Edit
        </button>
        <button type="button"
                class="btn btn-outline-danger btn-sm"
                data-bs-toggle="modal"
                :data-bs-target="`#deleteModal-${movie.id}`">
          Remove
        </button>
      </div>
    </div>

    <DeleteMovieModal :movie="movie" @delete-movie="deleteMovie" />
    <EditMovieModal :movie="movie" @edit-movie="editMovie" />
  </div>
</template>

<script>
  import DeleteMovieModal from "./DeleteMovieModal.vue";
  import EditMovieModal from "./EditMovieModal.vue";

  export default {
    components: { DeleteMovieModal, EditMovieModal },
    props: ["movie"],
    methods: {
      deleteMovie() {
        if (!this.movie || !this.movie.id) return;
        this.$emit("delete-movie", this.movie.id);
      },
      editMovie(movie) {
        if (!movie) return;
        this.$emit("edit-movie", movie);
      },
    },
  };
</script>
