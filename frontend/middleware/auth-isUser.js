export default function ({ $auth, redirect, store }) {
  const loggedIn = $auth.loggedIn
  if (loggedIn) {
    // let the user in
  } else {
    redirect('/')
  }
}
