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
        title: ''
      },
    }
  },
  validations() {
    return {
      editedMovie: {
        title: { required }
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