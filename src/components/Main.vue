<script>
import AddMovieModal from './AddMovieModal.vue';
import MovieItem from './MovieItem.vue';

export default {
  components: {
    MovieItem,
    AddMovieModal
  },
  data() {
    return {
      showAddMovieModal: false,
      movies: [
        { id: 1, title: 'The Matrix' },
          { id: 2, title: 'The Matrix Reloaded' },
          { id: 3, title: 'The Matrix Revolutions' },
          { id: 4, title: 'The Matrix Resurrections' },
          { id: 5, title: 'Gladiator' }
      ]
    }
  },
    methods: {
      addMovie(newMovie) {
        const newMovieId = this.movies.length === 0 ? 1 : Math.max(...this.movies.map(movie => movie.id)) + 1

      const movie = {
        id: newMovieId,
        title: newMovie.title
      };
      this.movies.push(movie);
      this.showAddMovieModal = false;
    },
    editMovie(movie) {
    const index = this.movies.findIndex(m => m.id === movie.id);
    this.movies.splice(index, 1, movie);
  },
      deleteMovie(id) {
        this.movies = this.movies.filter(movie => movie.id !== id);
      },
      async getMovies() {
      const response = await fetch('https://jsonplaceholder.typicode.com/todos');
      const data = await response.json();
      
      const newMovies = data.filter(movie => !this.movies.some(m => m.id === movie.id));
      this.movies = [...this.movies, ...newMovies];
    }
  }
  }
</script>

<template>
    <div id="main">
        <button @click="getMovies">Get Movies</button>
        <button @click="showAddMovieModal = true">Add Movie</button>
        <AddMovieModal v-if="showAddMovieModal" :show="showAddMovieModal" @add-movie="addMovie" @cancel="showAddMovieModal = false" />
        <hr>
        <div id="movie-list">
          <MovieItem 
            v-for="movie in movies" 
            v-bind:key="movie.id" 
            v-bind:movie="movie" 
            @delete-movie="deleteMovie"
            @edit-movie="editMovie"
            class="movie-item" />
        </div>
    </div>
</template>