export const state = () => ({
  isSignin: false,
  authToken: ""
});

export const mutations = {
  signin(state, authToken) {
    state.authToken = authToken;
    state.isSignin = authToken !== "";
  }
};
