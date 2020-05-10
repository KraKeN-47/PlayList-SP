export default function ({ $auth, redirect, store }) {
  const user = $auth.state.user
  if (user && user.isArtist) {
    // let the user in
  } else {
    redirect('/')
  }
}
