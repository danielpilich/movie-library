<template>
  <div id="movie">
    <h2>{{ movie.title }}</h2>
    <h2>{{ movie.id }}</h2>
    <div class="button-container">
      <button @click="editMovie">Edit</button>
      <button @click="showRemoveModal = true">Remove</button>
    </div>
    <RemoveModalBox v-if="showRemoveModal" :show="showRemoveModal" :movie="movie" @confirm-remove="removeMovie" @cancel="showRemoveModal = false" />
  </div>
</template>

<script>
import RemoveModalBox from './RemoveModalBox.vue';

export default {
  components: { RemoveModalBox },
  props: ['movie'],
  data() {
    return {
      showRemoveModal: false
    }
  },
  methods: {
    removeMovie() {
      this.$emit('remove-movie', this.movie.id);
    },
    editMovie() {
      this.$emit('edit-movie', this.movie);
    }
  }
}
</script>