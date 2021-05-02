<template>
  <div>
    <h1>QuickAnnotator</h1>
    <p>Herzlich willkommen zum QuickAnnotator!</p>

    <v-text-field label="AuthToken hier eingeben..." outlined></v-text-field>
    <v-btn @click="signin">Anmelden</v-btn>
  </div>
</template>

<script>

export default {
  methods: {
    signin: function(){

    }
  }
};
</script>
