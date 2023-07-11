<template>
    <form @submit.prevent class="comment_form">
        <div class="form-group">
            <input
                    v-model="comment.author"
                    class="form__input"
                    type="text"
                    placeholder="Author's name"
            />
            <div :class="{'invalid-feedback': true, 'active': v$.comment.author.$error}">
                <span v-for="error in v$.comment.author.$errors">
                    {{ error.$message }}
                </span>
            </div>
        </div>

        <div class="form-group">
            <input
                    v-model="comment.body"
                    class="form__input"
                    type="text"
                    placeholder="Comment"
            />
            <div :class="{'invalid-feedback': true, 'active': v$.comment.body.$error}">
                <span v-for="error in v$.comment.body.$errors">
                    {{ error.$message }}
                </span>
            </div>
        </div>

        <button
                class="form__button"
                @click="createComment"
        >
            Send
        </button>
    </form>
</template>

<script>
  import useValidate from "@vuelidate/core";
  import {maxLength, required} from "@vuelidate/validators";

  export default {
      props: {
          postId: 0,
          commentAuthor: ''
      },
      data() {
          return {
              v$: useValidate(),
              comment: {
                  author: 'Anonym',
                  body: ''
              }
          }
      },
      validations: {
          comment: {
              author: { required, maxLength: maxLength(32)},
              body: { required, maxLength: maxLength(256)}
          }
      },
      methods: {
          async createComment() {
              const isFormValid = await this.v$.$validate();
              if (isFormValid) {
                  this.$emit('create', this.comment, this.postId)
                  this.comment = {
                      author: 'Anonym',
                      body: ''
                  }
                  await this.v$.$reset();
              }
          }
      },
      mounted() {
          this.comment.body = this.commentAuthor + ", ";
      }
  }
</script>

<style scoped>
    .comment_form {
        display: flex;
        gap: 10px;
        width: 100%;
        align-items: center;
    }

    .form__button {
        font-size: 15px;
    }
</style>
