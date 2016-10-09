(function() {
var sammyApp = Sammy('#content', function() {

  this.get('#/', function(){
    this.redirect('#/home', homeController.all);
  })
  this.get('#/home', homeController.all);
  this.get('#materials/:id', materialsController.getById);
  this.get('#/login', usersController.login);
  this.get('#profiles/:username', function(context){
    let username = localStorage.username;
  });
  this.get('#/add-material', materialsController.add);
  this.get('#/register', usersController.register);
  this.get('#/logout', usersController.logout);

});

$(function() {
  sammyApp.run('#/');
});
}());
