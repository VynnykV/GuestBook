<template>
  <div class="comment">
      <div class="comment__top">
          <div class="comment__author">{{ comment.author }}</div>
          <div class="comment__date">{{ format_date(comment.createdAt) }}</div>
      </div>

      <div class="comment__bottom">
          <div class="comment__body"> {{comment.body}} </div>
          <button class="comment__button">Answer</button>
      </div>
  </div>
</template>

<script>
  import moment from "moment";

  export default {
      props: {
          comment: {
              type: Object,
              required: true,
          }
      },
      methods: {
          format_date(value){
              if (value) {
                  return moment(String(value)).format('DD.MM.YYYY hh:mm')
              }
          },
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
  }
</style>
