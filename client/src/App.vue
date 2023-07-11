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
  import CommentForm from "@/components/CommentForm.vue";
  import commentCreatedBuss from "@/services/CommentEmitter";

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
          CommentForm,
          Post,
          PostForm
      },
      async mounted() {
          await this.fetchAllPosts();
          commentCreatedBuss.on('commentCreated', async () => {
              await this.fetchAllPosts();
          })
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
      font-size: 15px;
      visibility: hidden;
      height: 10px;
  }

  .invalid-feedback.active {
      visibility: visible;
  }

  .form__input {
      width: 100%;
      border: 1px solid teal;
      padding: 10px 15px;
      margin-top: 15px;
  }

  .form__button {
      padding: 10px 15px;
      background: none;
      color: teal;
      border: 1px solid teal;
      align-self: flex-end;
      margin-bottom: 20px;
      margin-top: 25px;
  }

  .form__button:hover {
      cursor: pointer;
      opacity: 75%;
  }

  .form__button:focus {
      outline: 0;
  }

  .form-group {
      width: 100%;
  }
</style>
