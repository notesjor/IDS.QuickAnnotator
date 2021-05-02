<template>
  <div class="document" v-if="this.doc != null">
    <div class="sentence" v-for="(s, i) in doc" v-bind:key="i">
      <div class="token" v-for="(t, j) in s" v-bind:key="j">{{ t }}</div>
    </div>
  </div>
</template>

<style>
.document {
  
}
.sentence {
  display: inline;
}
.token {
  display: inline-block;
  margin-right: 5px;
  margin-bottom: 10px;
}
</style>

<script>
var id;

export default {
  async asyncData({ params }) {
    id = params.id;
    return { id };
  },
  data: () => {
    return {
      doc: null,
      id: 0
    };
  },
  methods: {
    getDocument: function() {
      var at = "A74ECAA00F3F4A4BBDA84CC5CCFAE9C4";// TODO this.$store.state.auth.authToken ;

      this.$axios
        .$post("http://localhost:4545/getDocument", {
          AuthToken: at,
          DocumentId: id
        })
        .then(response => {
          this.doc = response;
        });
    }
  },
  mounted() {
    this.getDocument();
  }
};
</script>
