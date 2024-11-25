<template>
  <div class="modal-overlay" v-if="show">
    <div class="modal">
      <h2>Confirm Removal</h2>
      <p>Are you sure you want to remove {{ movie.title }}?</p>
      <button @click="confirmRemove">Yes, remove</button>
      <button @click="cancel">Cancel</button>
    </div>
  </div>
</template>

<script>
export default {
  props: ['show', 'movie'],
  methods: {
    confirmRemove() {
      this.$emit('confirm-remove');
    },
    cancel() {
      this.$emit('cancel');
    }
  }
}
</script>