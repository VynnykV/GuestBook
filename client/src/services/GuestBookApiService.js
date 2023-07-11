import axios from "axios";

const client = axios.create({
    baseURL: 'http://localhost:5050',
    json: true
})

export default {
    async execute(method, resource, data) {
        return client({
            method,
            url: resource,
            data
        }).then(req => {
            return req.data
        })
    },
    async getAllPosts() {
        return await this.execute('get', '/posts')
    },
    // create(data) {
    //     return this.execute('post', '/', data)
    // }
}
