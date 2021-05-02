<template>
  <v-app dark>
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-list>
        <v-list-item to="/" v-if="!isSignin">
          <v-list-item-action>
            <v-icon>mdi-key-outline</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              Anmelden
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/overview" v-if="isSignin">
          <v-list-item-action>
            <v-icon>mdi-apps</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              Startseite
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/annotate" v-if="isSignin">
          <v-list-item-action>
            <v-icon>mdi-comment-edit-outline</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              Annotieren
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/compare" v-if="isSignin">
          <v-list-item-action>
            <v-icon>mdi-file-compare</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              Vergleichen
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/export" v-if="isSignin">
          <v-list-item-action>
            <v-icon>mdi-database-export-outline</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              Exportieren
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar 
      app
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
    </v-app-bar>
    <v-main>
      <v-container>
        <nuxt />
      </v-container>
    </v-main>
    <v-footer
      app
    >
      <span>&copy; {{ new Date().getFullYear() }} - Leibniz-Institut für Deutsche Sprache</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      title: 'Vuetify.js'
    }
  },
  watch: {
    isSignin: function (){
      return this.$store.state.auth.isSignin
    }
  }
}
</script>
