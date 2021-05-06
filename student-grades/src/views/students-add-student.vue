<template>
  <div>
    <form @submit.prevent="submit">
      <label for="sname">Student Name: </label>
      <input type="text" v-model="studentName" name="sname" id="sname" />
      <label for="semail">Email: </label>
      <input type="text" v-model="studentEmail" name="semail" id="semail" />
      <input type="submit" />
    </form>
  </div>
</template>

<script>
import { dataService } from "../shared/data.service";

export default {
  data() {
    return {
      studentName: "",
      studentEmail: "",
    };
  },
  methods: {
    submit() {
      // console.log(
      //   JSON.stringify({
      //     studentName: this.studentName,
      //     email: this.studentEmail,
      //     grades: [],
      //   })
      // );
      dataService
        .addStudent({
          studentName: this.studentName,
          email: this.studentEmail,
          grades: [],
        })
        .then(() => {
          this.$router.push({ name: "Home" });
        });
    },
  },
};
</script>

<style lang="scss" scoped>
</style>