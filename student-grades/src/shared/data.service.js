import { API } from "./config";
const getStudents = async function() {
	console.log(API);
	try {
		let response = await fetch(`${API}/students`);
		let json = await response.json();
		return json.results;
	} catch (error) {
		console.error(error);
		return [];
	}
};


export const dataService = {
	getStudents
};