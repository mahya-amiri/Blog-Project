import axios from "axios";
const http = axios.create({
  baseURL: "https://localhost:44374/",
});

export default http;
