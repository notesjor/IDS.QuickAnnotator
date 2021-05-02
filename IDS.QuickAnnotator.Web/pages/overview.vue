<template>
  <div>
    <h1>
      Willkommen: {{ this.$store.state.auth.myName }}
    </h1>
    <br />
    <p v-if="this.profile != null"> Dokumente: {{ this.profile.DoneDocumentIds.length }} / {{ this.docs }}</p>
    <v-btn v-if="this.profile != null && this.profile.LastDocumentId !== ''" color="info" v-bind:to="lastUrl">Annotation fortsetzen</v-btn>
  </div>
</template>

<script>
export default {
  data: () => {
    return {
      profile: null,
      docs: 0
    };
  },
  computed:{
    lastUrl: function(){
      return "/annotate/"+ this.profile.LastDocumentId;
    }
  },
  methods: {
    myProfile: function() {
      this.$axios
        .$post("http://localhost:4545/getProfile", {
          AuthToken: this.$store.state.auth.authToken
        })
        .then(response => {
          this.profile = response;
        });
    },
    getDocuments: function() {
      this.$axios
        .$post("http://localhost:4545/getDocuments")
        .then(response => {
          this.docs = response.length;
        });
    },
  },
  mounted() {
    this.myProfile();
    this.getDocuments();
  }
};
</script>
