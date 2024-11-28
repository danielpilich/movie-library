<template>
  <div class="modal-box-overlay" v-if="show">
    <div class="modal-box">
      <h2>Confirm Removal</h2>
      <p>Are you sure you want to remove {{ movie.title }}?</p>
      <button @click="confirmDelete">Yes, remove</button>
      <button @click="cancel">Cancel</button>
    </div>
  </div>
</template>

<script>
export default {
  props: ['show', 'movie'],
  methods: {
    confirmDelete() {
      this.$emit('confirm-delete');
    },
    cancel() {
      this.$emit('cancel');
    }
  }
}
</script>