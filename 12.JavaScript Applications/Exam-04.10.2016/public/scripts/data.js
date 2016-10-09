var data = function() {
  const USERNAME_LOCAL_STORAGE_KEY = 'username',
      AUTH_KEY_LOCAL_STORAGE_KEY = 'auth-key';

    const USERNAME_CHARS = "QWERTYUIOPLKJHGFDSAZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789._",
      USERNAME_MIN_LENGTH = 6,
      USERNAME_MAX_LENGTH = 30;

    const PASSWORD_CHARS = "QWERTYUIOPLKJHGFDSAZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789",
      PASSWORD_MIN_LENGTH = 6,
      PASSWORD_MAX_LENGTH = 30;

    const MATERIALS_TEXT_MIN_LENGTH = 6,
      MATERIALS_TEXT_MAX_LENGTH = 100;


  function register(user) {
    let usernameError = validator.validateString(user.username, USERNAME_MIN_LENGTH, USERNAME_MAX_LENGTH, USERNAME_CHARS);
    let passError = validator.validateString(user.password, PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH, PASSWORD_CHARS);
  if (passError) {
    return Promise.reject(passError.message);
  }

  if (usernameError) {
    return Promise.reject(usernameError.message);
  }

  var reqUser = {
    username: user.username,
    password: user.password,
    authKey: user.authKey
  };

  return jsonRequester.post('api/users', {
      data: reqUser
    })
    .then(function(resp) {
      var user = resp.result;
      localStorage.setItem(USERNAME_LOCAL_STORAGE_KEY, user.username);
      localStorage.setItem(AUTH_KEY_LOCAL_STORAGE_KEY, user.authKey);
      return {
        username: resp.result.username
      };
    });
}

function login(user) {
  let usernameError = validator.validateString(user.username, USERNAME_MIN_LENGTH, USERNAME_MAX_LENGTH, USERNAME_CHARS);
  let passError = validator.validateString(user.password, PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH, PASSWORD_CHARS);

  if (passError) {
    return Promise.reject(passError.message);
  }

  if (usernameError) {
    return Promise.reject(usernameError.message);
  }
    var reqUser = {
      username: user.username,
      passHash: user.password
    };


    return jsonRequester.put('api/users/auth', {
      data: reqUser
    })
      .then(function(resp) {
        var user = resp.result;
        localStorage.setItem(USERNAME_LOCAL_STORAGE_KEY, user.username);
        localStorage.setItem(AUTH_KEY_LOCAL_STORAGE_KEY, user.authKey);
        return user;
      });
  }

function logout(){
  var promise = new Promise(function(resolve, reject) {
   localStorage.removeItem(USERNAME_LOCAL_STORAGE_KEY);
   localStorage.removeItem(AUTH_KEY_LOCAL_STORAGE_KEY);
   resolve();
 });
 return promise;
}

function getAllUsers() {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      }
    };
    return jsonRequester.get('api/users', options)
      .then(function(res) {
        return res.result;
      });
  }

  function getAllMaterials(){
    return jsonRequester.get('api/materials')
      .then(function(res) {
        return res.result;
      });
  }

function addNewMaterial(material){
  let materialError = validator.validateString(material.title, MATERIALS_TEXT_MIN_LENGTH, MATERIALS_TEXT_MAX_LENGTH);
    if (materialError) {
      return Promise.reject('Text ' + materialError.message);
    }

    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      },
      data: material
    };
    return jsonRequester.post('api/materials', options)
      .then(function(res) {
        return res.result;
      });
}

function getMaterial(id){
  return json.requester.get('api/materials/:id');
}
  return{
    users:{
      register: register,
      login: login,
      logout: logout,
      all: getAllUsers
    },
    materials:{
      all: getAllMaterials,
      add: addNewMaterial,
      getById: getMaterial
    }
  }
}();
