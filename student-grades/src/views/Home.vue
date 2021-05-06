<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <Students />
    <div class="exampleOutputFrame">
      <pre class="pre-scrollable">{{ exampleOutput }}</pre>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import Students from "@/components/students.vue";

export default {
  name: "Home",
  components: { Students },
};
</script>
