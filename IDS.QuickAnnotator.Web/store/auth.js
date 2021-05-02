export const state = () => ({
  isSignin: false,
  authToken: "",
  myName: "",
  isAdmin: false
});

export const mutations = {
  signin(state, payload) {
    state.authToken = payload;
    state.isSignin = true;
  },
  setProfile(state, payload) {
    state.myName = payload.Name;
    state.isAdmin = payload.IsAdmin;
  }
};
