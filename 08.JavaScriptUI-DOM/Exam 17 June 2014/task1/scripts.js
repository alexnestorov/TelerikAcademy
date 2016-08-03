function createImagesPreviewer(selector, items) {
  var root = document.querySelector(selector);
  root.style.width = '1200px';
  root.style.height = '500px';
  var fragment = document.createDocumentFragment();

  // Left side.
  var imagePreviewer = document.createElement('div');
  imagePreviewer.style.display = 'inline-block';
  imagePreviewer.style.width = '400px';
  imagePreviewer.style.float = 'left';

  var selectedParent = document.createElement('div');
  selectedParent.classList.add('image-preview');
  var selectedHeader = document.createElement('h1');
  selectedHeader.innerText = items[0].title;
  var selectedImage = document.createElement('img');
  selectedImage.src = items[0].url;
  selectedImage.style.width = '800px';
  selectedImage.style.borderRadius = '10px';

  selectedParent.appendChild(selectedHeader);
  selectedParent.appendChild(selectedImage);
  selectedParent.style.margin = '50px';
  imagePreviewer.appendChild(selectedParent);

  // Right side.
  var image = document.createElement('div');
  image.style.display = 'inline-block';
  image.style.width = '250px';
  image.style.float = 'right';

  var inputHeader = document.createElement('h3');
  inputHeader.innerText = 'Filter';
  var input = document.createElement('input');
  image.appendChild(inputHeader);
  image.appendChild(input);

  var list = document.createElement('ul');
  list.style.listStyleType = 'none';
  list.style.height = '500px';
  list.style.overflowY = 'scroll';
  list.addEventListener('click', function(ev) {
    var target = ev.target;
    if (target.tagName === 'IMG') {
      var header = target.previousElementSibling.innerText;
      var imageSrc = target.src;
      selectedHeader.innerText = header;
      selectedImage.src = imageSrc;
    };
  }, false);

  list.addEventListener('mouseover', function(ev) {
    var target = ev.target;
    if (target.tagName === 'IMG') {
      target.parentElement.style.backgroundColor = '#CCC';
      target.parentElement.style.cursor = 'pointer';
    };
  }, false);

  list.addEventListener('mouseout', function(ev) {
    var target = ev.target;
    if (target.tagName === 'IMG') {
      target.parentElement.style.backgroundColor = '#FFF';
    };
  }, false);

  var li = document.createElement('li');
  var header = document.createElement('h3');
  header.style.textAlign = 'center';
  var animal = document.createElement('img');
  animal.style.backgroundPosition = 'center';
  animal.style.width = '90%';
  animal.style.borderRadius = '10px';
  li.classList.add('image-container');
  for (var i = 0, len = items.length; i < len; i++) {
    let currentLi = li.cloneNode(true);
    let currentAnimal = animal.cloneNode(true);
    let currentHeader = header.cloneNode(true);
    currentHeader.innerText = items[i].title;
    currentAnimal.src = items[i].url;
    currentLi.appendChild(currentHeader);
    currentLi.appendChild(currentAnimal);
    list.appendChild(currentLi);

  }
  // events for filtering images.
  input.addEventListener('keyup', function(ev) {
    var target = ev.target.value.toLowerCase();
    var images = list.getElementsByTagName('li');
    for (var i = 0, len = images.length; i < len; i += 1) {
      var currentInputText = images[i].firstElementChild.innerText.toLowerCase();
      if (currentInputText.indexOf(target) < 0) {
        console.log(target.value);
        images[i].style.display = 'none';
      }
    }
  }, false);

  input.addEventListener('keydown', function(ev) {
    var target = ev.target;
    var images = list.getElementsByTagName('li');
    for (var i = 0, len = images.length; i < len; i += 1) {
        images[i].style.display = 'inline-block';
    }
  }, false);

  image.appendChild(list);

  fragment.appendChild(imagePreviewer);
  fragment.appendChild(image);
  root.appendChild(fragment);
}
