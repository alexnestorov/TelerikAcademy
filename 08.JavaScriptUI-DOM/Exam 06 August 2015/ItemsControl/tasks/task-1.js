function solve() {
  return function(selector, isCaseSensitive) {
    var root,
      isCaseSensitive = isCaseSensitive || false,
      controlItems,
      buttonAdd,
      inputEnterText,
      inputSearchText,
      searchItems,
      spanEnterName,
      spanSearchName,
      resultItems,
      listItems,
      currentItem,
      newItem;

    // create list item and search with caseSensitive or caseInsensitive.
    // hiding elements with display none.
    console.log(isCaseSensitive);
    // creating Root element
    root = document.querySelector(selector);
    root.className += ' items-control';


    controlItems = document.createElement('div');
    controlItems.className = 'add-controls';

    var label = document.createElement('label');
        label.setAttribute('for', 'the-input');
        label.innerHTML = 'Enter text';

    // create button Add
    buttonAdd = document.createElement('button');
    buttonAdd.className += ' button';
    buttonAdd.innerHTML = 'Add';
    // add event for mouseover
    buttonAdd.addEventListener('mouseover', function(ev) {
      var target = ev.target;
      if (target.className === 'button') {
        target.className += ' button:hover';
      }
    });

    var fragment = document.createDocumentFragment();


    // create input Enter text field
    inputEnterText = document.createElement('input');
    inputEnterText.setAttribute('type', 'text');

    controlItems.appendChild(label);
    controlItems.appendChild(inputEnterText);
    controlItems.appendChild(buttonAdd);

    // create input Enter text field
    searchItems = document.createElement('div');
    searchItems.className += ' search-controls';
    spanSearchName = document.createElement('label');
    spanSearchName.setAttribute('for', 'search');
    spanSearchName.innerHTML = 'Search:';
    inputSearchText = document.createElement('input');
    inputSearchText.setAttribute('type', 'text');

    searchItems.appendChild(spanSearchName);
    searchItems.appendChild(inputSearchText);

    resultItems = document.createElement('div');
    resultItems.className += ' result-controls';
    listItems = document.createElement('ul');
    listItems.className += ' items-list';
    resultItems.appendChild(listItems);

    // add word to result items.
    buttonAdd.addEventListener('click', function() {
        var currentDeleteButton = document.createElement('button');
        currentDeleteButton.className += ' button';
        currentDeleteButton.innerHTML = 'X';
        newItem = document.createElement('li');
        newItem.style.fontWeight = 'bold';
        newItem.className += ' list-item';
        var text = inputEnterText.value;
        newItem.innerHTML = text;
        newItem.appendChild(currentDeleteButton);
        inputEnterText.value = '';
        listItems.appendChild(newItem);

    });


    inputSearchText.addEventListener('input', function() {
      var targetSensitive = inputSearchText.value;
      var items = document.getElementsByClassName('list-item');
      for (var i = 0, len = items.length; i < len; i += 1) {
        if (isCaseSensitive == true) {
          if (+items[i].firstChild.data.indexOf(targetSensitive) >= 0) {
            items[i].style.display = '';
          }else {
            items[i].style.display = 'none';
          }
        } else {
          if (+items[i].firstChild.data.toLowerCase().indexOf(targetSensitive.toLowerCase()) >= 0) {
            items[i].style.display = '';
          }else {
            items[i].style.display = 'none';
          }
        }
      }
    });

    //delete action
    listItems.addEventListener('click', function(ev) {
      var target = ev.target;
      if (target.className.indexOf('button') >= 0) {
        this.removeChild(target.parentNode);
      }
    })

    // adding elements to root element.
    fragment.appendChild(controlItems);
    fragment.appendChild(searchItems);
    fragment.appendChild(resultItems);

    root.appendChild(fragment);
  };
}

//module.exports = solve;
