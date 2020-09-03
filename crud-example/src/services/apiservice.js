import axios from "axios";

const baseURL = "https://localhost:44390/api/";

export default class datosExportar {
  getData(metodo) {
    return axios.get(`${baseURL}${metodo}`);
  }
  postData(metodo, datatosend) {
    return axios.post(`${baseURL}${metodo}`, datatosend);
  }

  putData(metodo, datatosend) {
    return axios.put(`${baseURL}${metodo}`, datatosend);
  }

  deleteData(metodo) {
    return axios.delete(`${baseURL}${metodo}`);
  }
}
