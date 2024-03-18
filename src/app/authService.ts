//create a authservice class
export class AuthService {
  constructor() {}

  //create isloggedin method to check if the user is logged in
  isLoggedIn(): boolean {
    //get the token from local storage
    const token = localStorage.getItem('token');
    //if token is present return true else return false
    return token ? true : false;
  }
}
