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
        ].filter(movie => movie && movie.id && movie.title)
      };
    },
    async mounted() {
      const response = await fetch('https://jsonplaceholder.typicode.com/todos');
      const data = await response.json();
      this.movies = [...this.movies, ...data];
    }
  }

</script>

<template>
    <div id="movie-list">
        <MovieItem v-for="movie in movies" v-bind:key="movie.id" v-bind:movie="movie" class="movie-item" />
    </div>
</template>