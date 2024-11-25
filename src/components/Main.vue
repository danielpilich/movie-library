<script>
import MovieItem from './MovieItem.vue';

export default {
  components: {
    MovieItem
  },
  data() {
    return {
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
      deleteMovie(id) {
        this.movies = this.movies.filter(movie => movie.id !== id);
      }
  },
    async mounted() {
      const response = await fetch('https://jsonplaceholder.typicode.com/todos');
      const data = await response.json();
      //this.movies = [...this.movies, ...data];
    }
  }
</script>

<template>
    <div id="main">
        <button>Get Movies</button>
        <button>Add Movie</button>
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