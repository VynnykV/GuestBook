<template>
    <form @submit.prevent class="post_form">
        <h4 class="post_form__title">New comment</h4>
        <div class="form-group">
            <input
                v-model="post.author"
                class="post_form__input"
                type="text"
                placeholder="Author's name"
            />
            <div v-if="v$.post.author.$error" class="invalid-feedback">
                <span v-for="error in v$.post.author.$errors">
                    {{ error.$message }}
                </span>
            </div>
        </div>

        <div class="form-group">
            <input
                v-model="post.body"
                class="post_form__input"
                type="text"
                placeholder="Comment"
            />
            <div v-if="v$.post.body.$error" class="invalid-feedback">
                <span v-for="error in v$.post.body.$errors">
                    {{ error.$message }}
                </span>
            </div>
        </div>

        <button
                class="post_form__button"
                @click="createPost"
        >
            Add new comment
        </button>
    </form>
</template>

<script>
import useValidate from '@vuelidate/core'
import {maxLength, required} from "@vuelidate/validators";

export default {
    data() {
        return {
            v$: useValidate(),
            post: {
                author: 'Anonym',
                body: ''
            }
        }
    },
    validations: {
        post: {
            author: { required, maxLength: maxLength(32)},
            body: { required, maxLength: maxLength(512)}
        }
    },
    methods: {
        async createPost() {
            const isFormValid = await this.v$.$validate();
            if (isFormValid) {
                this.$emit('create', this.post)
                this.post = {
                    author: 'Anonym',
                    body: ''
                }
                await this.v$.$reset();
            }
        }
    },
}
</script>

<style scoped>
.post_form {
    display: flex;
    flex-direction: column;
    width: 100%;

    .post_form__title {
        font-size: 24px;
    }

    .post_form__input {
        width: 100%;
        border: 1px solid teal;
        padding: 10px 15px;
        margin-top: 15px;
    }

    .post_form__button {
        padding: 10px 15px;
        background: none;
        color: teal;
        border: 1px solid teal;
        align-self: flex-end;
        margin-top: 15px
    }

    .post_form__button:hover {
        cursor: pointer;
        opacity: 75%;
    }

    .post_form__button:focus {
        outline: 0;
    }
}

</style>
