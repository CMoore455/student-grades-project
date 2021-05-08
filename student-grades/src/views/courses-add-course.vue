<template>
  <div>
    <form @submit.prevent="submit">
      <label for="sname">Course Name: </label>
      <input type="text" v-model="courseName" name="cname" id="cname" />
      <input type="submit" />
    </form>
  </div>
</template>

<script>
import { dataService } from "../shared/data.service";

export default {
  data() {
    return {
      courseName: "",
    };
  },
  methods: {
    submit() {
      dataService
        .addCourse({
          courseName: this.courseName,
        })
        .then(() => {
          this.$router.push({ name: "Courses" });
        });
    },
  },
};
</script>

<style lang="scss" scoped>
</style>