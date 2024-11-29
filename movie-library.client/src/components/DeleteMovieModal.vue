<template>
  <div class="modal fade"
       :id="`deleteModal-${movie.id}`"
       aria-labelledby="deleteModalLabel">
    <div class="modal-dialog">
      <div class="modal-content bg-dark text-white">
        <div class="modal-header">
          <h5 class="modal-title" id="deleteModalLabel">Delete Movie</h5>
          <button type="button"
                  class="btn-close btn-close-white"
                  data-bs-dismiss="modal"
                  aria-label="Close"></button>
        </div>
        <div class="modal-body">
          Are you sure you want to remove
          <strong>{{ movie?.title || "this item" }}</strong>?
        </div>
        <div class="modal-footer">
          <button type="button"
                  class="btn btn-outline-secondary btn-sm"
                  data-bs-dismiss="modal">
            Close
          </button>
          <button type="button"
                  class="btn btn-outline-danger btn-sm"
                  @click="confirmDelete"
                  data-bs-dismiss="modal">
            Remove Movie
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    props: {
      movie: Object,
    },
    methods: {
      confirmDelete() {
        if (this.movie) {
          this.$emit("delete-movie");
        }
      },
    },
  };
</script>
