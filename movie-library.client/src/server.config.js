import axios from "axios";

const apiClient = axios.create({
  baseURL: "/movies",
  timeout: 5000,
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
});

export default apiClient;
