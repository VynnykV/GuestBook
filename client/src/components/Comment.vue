<template>
  <div class="comment">
      <div class="comment__top">
          <div class="comment__author">{{ comment.author }}</div>
          <div class="comment__date">{{ format_date(comment.createdAt) }}</div>
      </div>

      <div class="comment__bottom">
          <div class="comment__body"> {{comment.body}} </div>
          <button class="comment__button" @click="answer_button_clicked">{{answer_button_text()}}</button>
      </div>

      <comment-form
          class="comment-form"
          v-if="answerButtonClicked"
          :post-id="get_post_id()"
          :comment-author="comment.author"
          @create="create_comment">
      </comment-form>
  </div>
</template>

<script>
  import moment from "moment";
  import CommentForm from "@/components/CommentForm.vue";
  import api from '@/services/GuestBookApiService'
  import commentCreatedBuss from "@/services/CommentEmitter";

  export default {
      components: {CommentForm},
      props: {
          comment: {
              type: Object,
              required: true,
          }
      },
      data() {
          return {
              answerButtonClicked: false
          }
      },
      methods: {
          format_date(value) {
              if (value) {
                  return moment(String(value)).format('DD.MM.YYYY hh:mm')
              }
          },
          get_post_id() {
              if (this.comment.postId)
                  return this.comment.postId;
              else {
                  return this.comment.id
              }
          },
          answer_button_clicked() {
              if (this.answerButtonClicked)
                  this.answerButtonClicked = false;
              else
                  this.answerButtonClicked = true;
          },
          answer_button_text() {
              if (this.answerButtonClicked)
                  return "Hide"
              else
                  return "Answer"
          },
          async create_comment(comment, postId) {
              try {
                  await api.createComment({
                      ...comment,
                      postId
                  });

                  commentCreatedBuss.emit('commentCreated', comment);
              } catch (e) {
                  console.log(e);
              }
          }
      }
  }
</script>


<style scoped>
  .comment {
    font-size: 20px;
    width: 100%;
    .comment__top {
        display: flex;
        align-items: center;
        gap: 10px;

        .comment__author {
            font-weight: bold;
        }

        .comment__date {
            opacity: 75%;
        }
    }

    .comment__bottom {
        display: flex;
        flex-direction: column;

        .comment__body {
            padding: 5px 0;
        }

        .comment__button {
            background: none;
            border: none;
            color: teal;
            font-size: 18px;
            align-self: flex-end;
            margin-right: 20px;
        }

        .comment__button:hover {
            cursor: pointer;
            color: mediumseagreen;
        }
    }
    .comment_form {
        margin-bottom: 10px;
    }
  }
</style>
