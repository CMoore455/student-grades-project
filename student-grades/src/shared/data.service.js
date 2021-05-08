import { API } from "./config";
const getStudents = async function() {
	try {
		let response = await fetch(`${API}/students`);
		let json = await response.json();
		return json.results;
	} catch (error) {
		console.error(error);
		return [];
	}
};

const getCourses = async function() {
	try {
		let response = await fetch(`${API}/courses`);
		let json = await response.json();
		return json.results;
	} catch (error) {
		console.error(error);
		return [];
	}
};

const addStudent = async function(student) {
	try {
		await fetch(`${API}/students`, {
			method: 'post',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(student)
		}).then((res) => {
			return res.json();
		});
	} catch (error) {
		console.error(error);
		return {};
	}
};

const addCourse = async function(course) {
	try {
		await fetch(`${API}/courses`, {
			method: 'post',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(course)
		}).then((res) => {
			return res.json();
		});
	} catch (error) {
		console.error(error);
		return {};
	}
};

export const dataService = {
	getStudents,
	getCourses,
	addStudent,
	addCourse
};