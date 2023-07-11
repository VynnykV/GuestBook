<template>
    <form @submit.prevent class="post_form">
        <h4 class="post_form__title">New comment</h4>
        <input
                v-model="post.author"
                class="post_form__input"
                type="text"
                placeholder="Author's name"
        />
        <input
                v-model="post.body"
                class="post_form__input"
                type="text"
                placeholder="Comment"
        />
        <button
                class="post_form__button"
                @click="createPost"
        >
            Add new comment
        </button>
    </form>
</template>

<script>
export default {
    data() {
        return {
            post: {
                author: 'Anonym',
                body: ''
            }
        }
    },
    methods: {
        createPost() {
            this.post.id = Date.now();
            this.$emit('create', this.post)
            this.post = {
                author: 'Anonym',
                body: ''
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
