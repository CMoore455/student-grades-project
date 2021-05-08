<template>
  <div>
    <h2>Courses</h2>
    <div>
      <ul v-if="courses">
        <li v-for="course in courses" :key="course.id">
          {{ course.courseName }}
        </li>
      </ul>
      <router-link :to="{ name: 'courses-add-course' }" tag="button">
        Add Course
      </router-link>
    </div>
  </div>
</template>

<script>
import { dataService } from "../shared/data.service";

export default {
  name: "Courses",
  data() {
    return {
      courses: [],
    };
  },
  async created() {
    await this.loadCourses();
  },

  methods: {
    // Loads courses and sets the courses array
    async loadCourses() {
      this.courses = [];
      this.courses = await dataService.getCourses();
    },
  },
};
</script>

<style lang="scss" scoped>
</style>