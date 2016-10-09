var validator = function() {

  var minLength = 6;
  var maxLength = 30;


  function validateString(text, min, max, chars) {
    if (typeof text !== 'string'){
      return {
        message: `Invalid type of text. Must be string`
      };
    } else if (text.length < min || text.length > max) {
      return {
        message: `Invalid: Length must be between ${min} and ${max}`
      };
    }

    if (chars) {
      text = text.split('');
      if (text.some(function(char) {
          return chars.indexOf(char) < 0;
        })) {
        return {
          message: `Invalid: Chars can be ${chars}`
        };
      }
    }
  }

  return {
    validateString: validateString
  }
}();
