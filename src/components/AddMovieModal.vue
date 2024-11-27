<template>
  <div class="modal-overlay" v-if="show">
    <div class="modal">
      <h2>Add Movie</h2>
      <form @submit.prevent="addMovie">
  <label for="title">Title:</label>
  <input type="text" id="title" v-model="newMovie.title" />
  <div v-if="v$.newMovie.title.$error">
    {{ v$.newMovie.title.$errors[0].$message }}
  </div>
  <label for="director">Director:</label>
  <input type="text" id="director" v-model="newMovie.director" />
  <div v-if="v$.newMovie.director.$error">
    {{ v$.newMovie.director.$errors[0].$message }}
  </div>
  <label for="year">Year:</label>
  <input type="number" id="year" v-model="newMovie.year" />
  <div v-if="v$.newMovie.year.$error">
    {{ v$.newMovie.year.$errors[0].$message }}
  </div>
  <label for="rate">Rate:</label>
  <input type="number" id="rate" v-model="newMovie.rate" />
  <div v-if="v$.newMovie.rate.$error">
    {{ v$.newMovie.rate.$errors[0].$message }}
  </div>
  <button type="submit">Add Movie</button>
  <button @click="cancel">Cancel</button>
</form>
    </div>
  </div>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import { required } from '@vuelidate/validators'

export default {
  props: ['show'],
  data() {
    return {
      newMovie: {
      title: '',
      director: '',
      year: '',
      rate: ''
    }
    }
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      newMovie: {
      title: { required },
      director: { required },
      year: { required },
      rate: { required }
    }
    }
  },
  methods: {
    addMovie() {
      this.v$.$validate()
      if (!this.v$.$error) {
        this.$emit('add-movie', this.newMovie)
        this.newMovie = {
    title: '',
    director: '',
    year: '',
    rate: ''
  };
      }
    },
    cancel() {
      this.$emit('cancel')
    }
  }
}
</script>