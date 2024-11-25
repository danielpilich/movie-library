<script>
 export default {
    props: ['movie']
 }
</script>

<template>
  <div id="movie">
    <h2>{{ movie.title }}</h2>
    <div class="button-container">
      <button>Edit</button>
      <button>Remove</button>
    </div>
  </div>
</template>