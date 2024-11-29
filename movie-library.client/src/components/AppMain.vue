<script>
  import AddMovieModal from "./AddMovieModal.vue";
  import MovieItem from "./MovieItem.vue";
  import apiClient from "@/server.config";

  export default {
    components: {
      MovieItem,
      AddMovieModal,
    },
    data() {
      return {
        loading: false,
        movies: [],
        error: null,
      };
    },
    methods: {
      async getMovies() {
        try {
          const response = await apiClient.get("/");
          this.movies = response.data;
        } catch (error) {
          console.error("Error fetching movies:", error);
          this.error = "Failed to load movies.";
        }
      },

      async getSampleMovies() {
        try {
          this.loading = true;
          const response = await apiClient.post("/sampleMovies");
          this.movies.push(response.data);
        } catch (error) {
          console.error("Error fetching movies:", error);
          this.error = "Failed to load movies.";
        } finally {
          await this.getMovies();
          this.loading = false;
        }
      },

      async addMovie(newMovie) {
        try {
          const response = await apiClient.post("/", newMovie);
          this.movies.push(response.data);
        } catch (error) {
          console.error(
            "Error adding movie:",
            error.response?.data || error.message
          );
          this.error = "Failed to add movie.";
        } finally {
          await this.getMovies();
        }
      },

      async editMovie(updatedMovie) {
        try {
          await apiClient.put(`/${updatedMovie.id}`, updatedMovie);
          const index = this.movies.findIndex(
            (movie) => movie.id === updatedMovie.id
          );
          if (index !== -1) {
            this.movies.splice(index, 1, updatedMovie);
          }
        } catch (error) {
          console.error(
            "Error editing movie:",
            error.response?.data || error.message
          );
          this.error = "Failed to update movie.";
        } finally {
          await this.getMovies();
        }
      },

      async deleteMovie(id) {
        try {
          await apiClient.delete(`/${id}`);
          this.movies = this.movies.filter((movie) => movie.id !== id);
        } catch (error) {
          console.error(
            "Error deleting movie:",
            error.response?.data || error.message
          );
          this.error = "Failed to delete movie.";
        } finally {
          await this.getMovies();
        }
      },
    },
    async mounted() {
      await this.getMovies();
    },
  };
</script>

<template>
  <div class="container py-4" id="app-main">
    <div class="d-flex justify-content-center gap-3 mb-4">
      <button type="button"
              class="btn btn-outline-success btn-sm"
              data-bs-toggle="modal"
              data-bs-target="#addModal">
        <span class="sr-only">Add Movie</span>
      </button>
      <button type="button"
              class="btn btn-outline-light btn-sm"
              @click="getSampleMovies">
        <span v-if="loading"
              class="spinner-border spinner-border-sm"></span>
        <span>Get Movies</span>
      </button>
    </div>

    <AddMovieModal @add-movie="addMovie" />

    <hr />

    <div class="row">
      <MovieItem v-for="movie in movies"
                 :key="movie.id"
                 :movie="movie"
                 @delete-movie="deleteMovie"
                 @edit-movie="editMovie"
                 class="movie-item" />
    </div>
  </div>
</template>
