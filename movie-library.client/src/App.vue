<script>
  import AppHeader from "./components/AppHeader.vue";
  import AppMain from "./components/AppMain.vue";

  export default {
    components: {
      AppHeader,
      AppMain,
    },
  };
</script>

<template>
  <div id="app">
    <AppHeader />
    <AppMain />
  </div>
</template>
