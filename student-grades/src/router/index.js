import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import StudentsAddStudent from '../views/students-add-student.vue';
import CoursesAddCourse from '../views/courses-add-course.vue';
import Courses from '../views/courses.vue';
import SearchGrades from '../views/search-grade.vue';


Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/home',
    name: 'Home',
    component: Home
  },
  {
    path: '/courses',
    name: 'Courses',
    component: Courses
  },
  {
    path: '/students/addstudent',
    name: 'students-add-student',
    component: StudentsAddStudent
  },
  {
    path: '/courses/addCourses',
    name: 'courses-add-course',
    component: CoursesAddCourse
  },
  {
    path: '/grades/search_grade',
    name: 'search-grade',
    component: SearchGrades
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;
