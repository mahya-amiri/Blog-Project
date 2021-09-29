import axios from "axios";

export const baseUrl = "https://localhost:44374/";
const http = axios.create({
  baseURL: baseUrl,
});

export default http;
