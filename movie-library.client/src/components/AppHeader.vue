<template>
  <header class="bg-primary text-white py-3 mb-4 shadow-sm">
    <div class="container text-center">
      <h1 class="display-4 fw-bold">{{ appTitle }}</h1>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {
      appTitle: "Movie Library",
    };
  },
};
</script>
