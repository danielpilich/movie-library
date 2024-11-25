<script>
 export default {
    props: ['movie'],

    methods: {
    removeMovie() {
      this.$emit('remove-movie', this.movie.id);
    }
  }
 }
</script>

<template>
  <div id="movie">
    <h2>{{ movie.title }}</h2>
    <div class="button-container">
        <button @click="editMovie">Edit</button>
        <button @click="removeMovie">Remove</button>
    </div>
  </div>
</template>