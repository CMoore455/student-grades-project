<template>
  <div>
    <h2>Students</h2>
    <div>
      <ul v-if="students">
        <li v-for="student in students" :key="student.id">
          {{ student.studentName }} <br />
          GPA: {{ student.overallGPA }}
        </li>
      </ul>
      <router-link :to="{ name: 'students-add-student' }" tag="button">
        Add Student
      </router-link>
    </div>
  </div>
</template>

<script>
import { dataService } from "../shared/data.service";
export default {
  name: "Students",
  data() {
    return {
      students: [],
    };
  },
  async created() {
    await this.loadStudents();
  },

  methods: {
    // Loads students and sets the students array
    async loadStudents() {
      this.students = [];
      this.students = await dataService.getStudents();
    },
  },
};
</script>

