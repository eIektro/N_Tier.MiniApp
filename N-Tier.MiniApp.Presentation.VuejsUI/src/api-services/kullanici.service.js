import Axios from 'axios';
const RESOURCE_NAME = '/Kullanici';
export default {
  getAll() {
      return Axios({
        method: 'GET',
        url: 'https://localhost:44312/api/Kullanici',
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Content-type': 'application/json',
        }
      }) 
    //return Axios.get(RESOURCE_NAME);
  },
  get(id) {
    return Axios.get(`${RESOURCE_NAME}/${id}`);
  },
  create(data) {
    return Axios.post(RESOURCE_NAME, data);
  },
  update(id, data) {
    return Axios.put(`${RESOURCE_NAME}/${id}`, data);
  },
  delete(id) {
    return Axios.delete(`${RESOURCE_NAME}/${id}`);
  }
};
