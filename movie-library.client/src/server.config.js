import axios from "axios";

const apiClient = axios.create({
  baseURL: "/mymovies",
  timeout: 5000,
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
});

export default apiClient;