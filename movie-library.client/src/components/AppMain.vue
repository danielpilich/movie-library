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
      post: [],
      newMovies: [],
      movies: [],
      addMovieMessageSent: false,
      error: null,
    };
  },
  methods: {
    async getMovies() {
      try {
        const response = await apiClient.get("/");
        this.newMovies = response.data.filter(
          (movie) => !this.movies.some((m) => m.id === movie.id)
        );
        this.movies = [...this.movies, ...this.newMovies];
      } catch (error) {
        console.error("Error fetching movies:", error);
        this.error = "Failed to load movies.";
      }
    },

    addMovie(newMovie) {
      if (newMovie) {
        this.newMovie = newMovie;
        const newMovieId =
          this.movies.length === 0
            ? 1
            : Math.max(...this.movies.map((movie) => movie.id)) + 1;

        const movie = {
          id: newMovieId,
          title: newMovie.title,
          director: newMovie.director,
          year: newMovie.year,
          rate: newMovie.rate,
        };
        this.movies.push(movie);
        this.addMovieMessageSent = true;
      }
    },
    editMovie(editedMovie) {
      if (editedMovie) {
        const index = this.movies.findIndex(
          (movie) => movie.id === editedMovie.id
        );
        if (index !== -1) {
          this.movies.splice(index, 1, editedMovie);
        }
      }
    },
    deleteMovie(id) {
      if (id) {
        this.movies = this.movies.filter((movie) => movie.id !== id);
      }
    }
  }
};
</script>

<template>
  <div class="container py-4" id="app-main">
    <div class="d-flex justify-content-center gap-3 mb-4">
      <button
        type="button"
        class="btn btn-outline-success btn-sm"
        data-bs-toggle="modal"
        data-bs-target="#addModal"
      >
        Add Movie
      </button>

      <button
        type="button"
        class="btn btn-outline-light btn-sm"
        @click="getMovies"
      >
        Get Movies
      </button>
    </div>
    
    <AddMovieModal @add-movie="addMovie" />

    <hr />

    <div class="row">
      <MovieItem
        v-for="movie in movies"
        :key="movie.id"
        :movie="movie"
        @delete-movie="deleteMovie"
        @edit-movie="editMovie"
        class="movie-item"
      />
    </div>
  </div>
</template>
