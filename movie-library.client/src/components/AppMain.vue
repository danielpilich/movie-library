<script>
import AddMovieModal from "./AddMovieModal.vue";
import MovieItem from "./MovieItem.vue";

export default {
  components: {
    MovieItem,
    AddMovieModal,
  },
  data() {
    return {
      post: null,
      newMovie: "",
      addMovieMessageSent: false,

      movies: [
        {
          id: 1,
          title: "The Matrix",
          director: "The Wachowskis",
          year: 1999,
          rate: 8.7,
        },
        {
          id: 2,
          title: "The Matrix Reloaded",
          director: "The Wachowskis",
          year: 2003,
          rate: 7.5,
        },
        {
          id: 3,
          title: "The Matrix Revolutions",
          director: "The Wachowskis",
          year: 2003,
          rate: 7.2,
        },
        {
          id: 4,
          title: "The Matrix Resurrections",
          director: "Lana Wachowski",
          year: 2021,
          rate: 6.8,
        },
        {
          id: 5,
          title: "Gladiator",
          director: "Ridley Scott",
          year: 2000,
          rate: 8.5,
        },
      ],
    };
  },
  methods: {
    addMovieTest(newMovie) {
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
    },
    async getMovies() {
      this.post = null;

      try {
        const response = await fetch("mymovies");
        const json = await response.json();
        this.post = json;

        const newMovies = this.post.filter(
          (movie) => !this.movies.some((m) => m.id === movie.id)
        );
        this.movies = [...this.movies, ...newMovies];
      } catch (error) {
        console.error(error);
      }
    },
  },
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
    
    <AddMovieModal @add-movie="addMovieTest" />

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
