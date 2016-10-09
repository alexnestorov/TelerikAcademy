var usersController = function() {

  function all(context) {
    let allUsers = {};
    data.users.all()
        .then((data) => {
            allUsers = data.result;
            templates.get('all-users')
            .then(function (template) {
                context.$element().html(template(allUsers));
            });
        })
        .catch((error) => {
            console.log(error);
        });
  }

  function register(context) {
    templates.get('register')
      .then(function(template){
        context.$element().html(template)

        $('#btn-register').on('click', function(){
            let username = $('#tb-username').val();
            let password = $('#tb-password').val();
            var user = {
              username: username,
              password: password,
              authKey: password
            }

            data.users.register(user)
            .then(function() {
              $('#infoBox')
              .text('You have registered successfully.')
              .show()
              .delay(5000)
              .fadeOut();
              setTimeout(function() {
                context.redirect('#/');
                document.location.reload(true);
              }, 1000);
            }, function(err){
              $('#errorBox')
              .text(err)
              .show()
              .delay(5000)
              .fadeOut();
              context.redirect('#/register');
            });

      });
    });
  }

  function login(context){
    templates.get('login')
      .then(function(template){
        context.$element().html(template)

        $('#btn-login').on('click', function(){
          let username = $('#tb-login-username').val();
          let password = $('#tb-login-password').val();
          var user = {
            "username": username,
            "password": password
          }
          data.users.login(user)
          .then(function() {
            console.log('User logged in!');
            $('#span-username').text(user.username);
            setTimeout(function() {
              context.redirect('#/');
              document.location.reload(true);
            }, 1000);
          }, function(err){
            console.log(err);
          });
        });
      });
  }


  function logout(context){
    templates.get('logout')
    .then(function(template){
      context.$element().html(template);
      $('#btn-logout').on('click', function(){
        data.users.logout()
          .then(function (res) {
            console.log(res);
            context.redirect('#/');
        })
      })
    })
  }

  return {
    all: all,
    register: register,
    login: login,
    logout: logout
  };
}();
