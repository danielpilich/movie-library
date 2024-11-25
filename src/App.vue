<script>
  import Header from './components/Header.vue'
  import MovieList from './components/MovieList.vue'

  export default {
    components: {
      Header,
      MovieList
    }
  }  
</script>

<template>
  <div id="app">
    <Header />
    <MovieList />
  </div>   
</template>
