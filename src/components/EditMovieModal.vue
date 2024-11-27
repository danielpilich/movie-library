<template>
  <div class="modal-overlay" v-if="show">
    <div class="modal">
      <h2>Edit Movie</h2>
      <form @submit.prevent="saveMovie">
  <label for="title">Title:</label>
  <input type="text" id="title" v-model="editedMovie.title" />
  <div v-if="v$.editedMovie.title.$error">
    {{ v$.editedMovie.title.$errors[0].$message }}
  </div>
  <label for="director">Director:</label>
  <input type="text" id="director" v-model="editedMovie.director" />
  <div v-if="v$.editedMovie.director.$error">
    {{ v$.editedMovie.director.$errors[0].$message }}
  </div>
  <label for="year">Year:</label>
  <input type="number" id="year" v-model="editedMovie.year" />
  <div v-if="v$.editedMovie.year.$error">
    {{ v$.editedMovie.year.$errors[0].$message }}
  </div>
  <label for="rate">Rate:</label>
  <input type="number" id="rate" v-model="editedMovie.rate" />
  <div v-if="v$.editedMovie.rate.$error">
    {{ v$.editedMovie.rate.$errors[0].$message }}
  </div>
  <button type="submit">Save Changes</button>
  <button @click="cancel">Cancel</button>
</form>
    </div>
  </div>
</template>

<script>
import { useVuelidate } from '@vuelidate/core'
import { required } from '@vuelidate/validators'

export default {
  props: {
    show: Boolean,
    movie: Object
  },
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      editedMovie: {
      title: '',
      director: '',
      year: '',
      rate: ''
    }
    }
  },
  validations() {
    return {
      editedMovie: {
      title: { required },
      director: { required },
      year: { required },
      rate: { required }
    }
    }
  },
  methods: {
    saveMovie() {
      this.v$.$validate()
      if (!this.v$.$error) {
        this.$emit('edit-movie', this.editedMovie)
        this.cancel()
      }
    },
    cancel() {
      this.$emit('cancel')
    }
  },
  mounted() {
    this.editedMovie = { ...this.movie }
  }
}
</script>