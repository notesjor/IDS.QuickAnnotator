<template>
  <div>
    <h1>QuickAnnotator</h1>
    <p>Herzlich willkommen zum QuickAnnotator!</p>

    <v-text-field
      label="AuthToken hier eingeben..."
      outlined
      v-model="authToken"
    ></v-text-field>
    <v-btn @click="signin">Anmelden</v-btn>
  </div>
</template>

<script>
export default {
  data() {
    return {
      authToken: ""
    };
  },
  methods: {
    signin: function() {
      var axios = this.$axios;
      var credentials = { AuthToken: this.authToken };

      axios
        .$post("http://localhost:4545/signin", credentials)
        .then(response => {
          if (response) {
            axios
              .$post("http://localhost:4545/getProfile", credentials)
              .then(response2 => {
                this.$store.commit("auth/signin", credentials.AuthToken);
                this.$store.commit("auth/setProfile", response2);
                this.$router.push({ path: "/overview" });
              });
          }
        });
    }
  }
};
</script>
