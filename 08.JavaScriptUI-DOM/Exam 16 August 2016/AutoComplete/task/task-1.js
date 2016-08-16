/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
      var root,
          stringArray,
          inputSearchText,
          buttonAdd,
          fragment,
          suggestion,
          suggestionLink,
          suggestionUl,
          isCaseSensitive = isCaseSensitive || false;

      root = document.querySelector(selector);
      stringArray = initialSuggestions;
      fragment = document.createDocumentFragment();

      if (initialSuggestions === undefined) {
        suggestionUl = document.createElement('ul');
        suggestionUl.className += ' suggestions-list';
      }else {
        suggestionUl = root.children[2];
      }
      inputSearchText = root.children[0];
      buttonAdd = root.children[1];


      for (var i = 0, len = initialSuggestions.length; i < len; i+= 1) {
        var items = document.getElementsByClassName('suggestion');
        var target = initialSuggestions[i].text;
        for (var i = 0, len = items.length; i < len; i += 1) {
            if (+items[i].innerText.indexOf(target) !== 0) {
              suggestion = document.createElement('li');
              suggestion.style.display = 'none';
              suggestion.className += ' suggestion';
              suggestionLink = document.createElement('a');
              suggestionLink.setAttribute('href','#');
              suggestionLink.className += ' suggestion-link';
              suggestionLink.innerText = initialSuggestions[i];
              console.log(suggestionLink.innerText);
              suggestion.appendChild(suggestionLink).cloneNode();
              suggestionUl.appendChild(suggestion).cloneNode();
              items[i].style.display = 'none';
            }
        }
      }

      if (inputSearchText.value = '') {
        suggestionUl.style.display = 'none';
      }

      inputSearchText.addEventListener('input', function() {
      var targetSensitive = inputSearchText.value;
      var items = document.getElementsByClassName('suggestion');
      for (var i = 0, len = items.length; i < len; i += 1) {
        if (isCaseSensitive === true) {
          if (+items[i].innerText.indexOf(targetSensitive) < 0) {
            items[i].style.display = 'none';
          }else {
            items[i].style.display = '';
          }
        } else {
          if (+items[i].innerText.toLowerCase().indexOf(targetSensitive.toLowerCase()) < 0) {
            items[i].style.display = 'none';
          }else {
            items[i].style.display = '';
          }
        }
        if (targetSensitive === '') {
          items[i].style.display = 'none';
        }
      }
    });

    buttonAdd.addEventListener('click', function() {
        var wordToAdd = inputSearchText.value;
        var existingWord = false;
        var items = document.getElementsByClassName('suggestion');
        for (var i = 0, len = items.length; i < len; i += 1) {
            if (+items[i].innerText.indexOf(wordToAdd) === 0) {
              existingWord = true;
          }
      }
        if (!existingWord) {
        suggestion = document.createElement('li');
        suggestion.style.display = 'none';
        suggestion.className += ' suggestion';
        suggestionLink = document.createElement('a');
        suggestionLink.setAttribute('href','#');
        suggestionLink.className += ' suggestion-link';
        suggestionLink.innerText = wordToAdd;
        suggestion.appendChild(suggestionLink).cloneNode();
        suggestionUl.appendChild(suggestion).cloneNode();
      }
    });

    suggestionUl.addEventListener('click', function(){
      var textToReplace = this.innerText;
      inputSearchText.value = textToReplace;
    });

      suggestionUl.appendChild(suggestion);
      fragment.appendChild(suggestionUl);

      root.appendChild(fragment);
    };
}

//module.exports = solve;
