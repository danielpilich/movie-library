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
        { id: 1, title: 'The Matrix', director: 'The Wachowskis', year: 1999, rate: 8.7 },
        { id: 2, title: 'The Matrix Reloaded', director: 'The Wachowskis', year: 2003, rate: 7.5 },
        { id: 3, title: 'The Matrix Revolutions', director: 'The Wachowskis', year: 2003, rate: 7.2 },
        { id: 4, title: 'The Matrix Resurrections', director: 'Lana Wachowski', year: 2021, rate: 6.8 },
        { id: 5, title: 'Gladiator', director: 'Ridley Scott', year: 2000, rate: 8.5 }
      ]
    }
  },
    methods: {
      addMovie(newMovie) {
  const newMovieId = this.movies.length === 0 ? 1 : Math.max(...this.movies.map(movie => movie.id)) + 1

  const movie = {
    id: newMovieId,
    title: newMovie.title,
    director: newMovie.director,
    year: newMovie.year,
    rate: newMovie.rate
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
      const response = await fetch('https://filmy.programdemo.pl/MyMovies');
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