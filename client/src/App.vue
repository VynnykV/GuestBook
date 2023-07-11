<template>
  <div class="app">
      <div class="content">
          <post-form @create="createPost" class="post_form"></post-form>
          <div v-if="!loading">
              <post
                  v-for="post in posts"
                  :post="post">
              </post>
          </div>
      </div>
  </div>
</template>

<script>
  import PostForm from "./components/PostForm.vue";
  import api from './services/GuestBookApiService'
  import Post from "@/components/Post.vue";

  export default {
      data() {
          return {
              loading: false,
              posts: []
          }
      },
      methods: {
        async fetchAllPosts() {
            this.loading = true;

            try {
                this.posts = await api.getAllPosts();
            } finally {
                this.loading = false;
            }
        },
        async createPost(post) {
            try {
                await api.createPost(post)
                await this.fetchAllPosts()
            } catch (ex) {
                console.log(ex)
            }
        }
      },
      components: {
          Post,
          PostForm
      },
      mounted() {
          this.fetchAllPosts();
      }
  }
</script>

<style>
  @import "./styles/reset.css";
  * {
      box-sizing: border-box;
  }
  
  body {
      font-size: 16px;

  }

  .app {
      display: flex;
      justify-content: center;
  }

  .post_form {
      margin-bottom: 10px;
  }

  .content {
      width: 100%;
      max-width: 900px;
      display: flex;
      flex-direction: column;
      align-items: center;
      padding: 25px;
  }

  .invalid-feedback {
      color: red;
  }
</style>
