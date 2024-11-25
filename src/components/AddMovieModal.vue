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
        title: ''
      }
    }
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      newMovie: {
        title: { required }
      }
    }
  },
  methods: {
    addMovie() {
      this.v$.$validate()
      if (!this.v$.$error) {
        this.$emit('add-movie', this.newMovie)
        this.newMovie.title = ''
      }
    },
    cancel() {
      this.$emit('cancel')
    }
  }
}
</script>