import axios from "axios";
import { defineStore } from "pinia";

/* eslint-disable */
export const useUserStore = defineStore('user', {
    state: () => ({
        token: null,
    }),
    getters: {
        isAuthenticated: (state) => !!state.token
    },
    actions: {
        async login(username, password) {
            try {
                const response = await axios.post(`${process.env.VUE_APP_API_URL}/api/login`, {
                    login: username,
                    password: password
                })

                if(response.data.token){
                    this.token = response.data.token
                }
            }
            catch(error){
                console.log(error)
            }
        },
    }
})