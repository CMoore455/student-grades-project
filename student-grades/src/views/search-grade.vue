<template>
  <div>
    <form @submit.prevent="submit">
      <label for="sname">Student Name: </label>
      <input type="text" v-model="studentName" name="sname" id="sname" />
      <label for="semail">Course: </label>
      <input type="text" v-model="courseName" name="cname" id="cname" />
      <input type="submit" />
    </form>

    <div v-if="grade">
      Letter: {{ grade.letter }} <br />
      Score: {{ grade.score }}
    </div>
  </div>
</template>

<script>
import { dataService } from "../shared/data.service";
export default {
  data() {
    return {
      studentName: "",
      courseName: "",
      grade: null,
    };
  },

  methods: {
    async submit() {
      this.grade = await dataService.searchGrade({
        studentName: this.studentName,
        courseName: this.courseName,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
</style>