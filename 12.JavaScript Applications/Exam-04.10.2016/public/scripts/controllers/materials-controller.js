var materialsController = function(){

function all(context){
  let allMaterials = {};
  data.materials.all()
      .then((data) => {
          allMaterials = data;
          templates.get('home')
          .then(function (template) {
              context.$element().html(template(allMaterials));
          });
      })
      .catch((error) => {
          console.log(error);
      });
}

function add(context){
  templates.get('add-material')
  .then(function(template){
    context.$element().html(template);

    $('#btn-add-material').on('click', function(){
      let title = $('#tb-title').val();
      let description = $('#tb-description').val();
      let image = $('#tb-image').val();
      var material = {
        "title": title,
        "description": description,
        "iamge": image
      }
      console.log(material);
      data.materials.add(material)
      .then(function() {
        console.log('Created new material!');
        setTimeout(function() {
          context.redirect('#/home');
          document.location.reload(true);
        }, 1000);
      }, function(err){
        console.log(err);
      });
    })
  })
}

  return{
    all: all,
    add: add,
    
  }
}()
