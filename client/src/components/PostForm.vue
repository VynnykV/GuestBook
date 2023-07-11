<template>
    <form @submit.prevent class="post_form">
        <h4 class="post_form__title">New comment</h4>
        <div class="form-group">
            <input
                v-model="post.author"
                class="form__input"
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
                class="form__input"
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
                class="form__button"
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
}

</style>
