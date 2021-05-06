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
export default {
  data() {
    return {
      studentName: "",
      studentEmail: "",
    };
  },
  methods: {
    submit() {
      console.log(this.studentName, this.studentEmail);
    },
  },
};
</script>

<style lang="scss" scoped>
</style>