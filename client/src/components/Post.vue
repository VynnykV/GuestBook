<template>
    <div class="post">
        <comment :comment="post"></comment>
        <comment class="under_comment"
                 v-for="comment in post.comments"
                 :comment="comment"
                 :post-id="post.id"
        >
        </comment>
    </div>
  <hr>
</template>

<script>
  import Comment from "@/components/Comment.vue";

  export default {
      components: {Comment},
      props: {
          post: {
              type: Object,
              required: true,
          }
      }
  }
</script>

<style scoped>
  .post {
      width: 100%;
  }
  .under_comment {
      margin-left: 15px;
  }
</style>
