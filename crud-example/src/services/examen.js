import axios from 'axios';

const baseURL = "https://jsonplaceholder.typicode.com/";

export default class datosExportar{
    saludar(metodo){
       return axios.get(`${baseURL}${metodo}`)
    }
}
