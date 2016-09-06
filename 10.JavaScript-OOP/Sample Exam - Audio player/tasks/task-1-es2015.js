function  solve() {
  'use strict'
  const CONSTANTS = {
    MIN_LENGTH: 3,
    MAX_LENGTH: 25,
    IMDB_MINRATING: 1,
    IMDB_MAXRATING: 5
  };

  function getSortingFunction(firstParameter, secondParameter) {
      return function (first, second) {
        if (first[firstParameter] < second[firstParameter]) {
          return -1;
        }
        else if (first[firstParameter] > second[firstParameter]) {
          return 1;
        }

        if (first[secondParameter] < second[secondParameter]) {
          return -1;
        }
        else if (first[secondParameter] > second[secondParameter]) {
          return 1;
        }
        else {
        return 0;
      }
    }
  }

   class  Validator {
     constructor() {

     }
     static validateIfUndefined(value, name){
       name = name || "Value";
       if (value === undefined) {
         throw new Error(`${name} can not be undefined`);
       }
     }
      static validateIfObject(value, name){
        name = name || "Value";
        if (typeof value !== 'object') {
          throw new Error(`${name} must be with type object`);
        }
      }
      static validateString(value, name){
        name = name || 'Value';
        Validator.validateIfUndefined(value, name);

        if (typeof value !== 'string') {
          throw new Error(`${name} must be with type string`);
        }

        if (value.length < CONSTANTS.MIN_LENGTH ||
            value.length > CONSTANTS.MAX_LENGTH) {
          throw new Error(`${name} has invalid length`);
        }
      }
      static validateNumber(value, name){
        name = name || 'Value';
        Validator.validateIfUndefined(value, name);

        if (typeof value !== 'number') {
          throw new Error(`${name} must be with type number`);
        }

        if (value < 1) {
          throw new Error(`${name} must be positive number`);
        }
      }
      static validateImdbRating(value){
        if (value === undefined) {
          throw new Error(`${value} can not be undefined`);
        }

        if (typeof value !== 'number') {
          throw new Error(`${name} must be a number`);
        }

        if (value < CONSTANTS.IMDB_MINRATING && value > CONSTANTS.IMDB_MAXRATING) {
          throw new Error(`Invalid imdb rating`);
        }
      }

      static validatePageAndSize(page, size, max){
        Validator.validateIfUndefined(page);
        Validator.validateIfUndefined(size);
        Validator.validateNumber(page);
        Validator.validateNumber(size);
        if (page < 0) {
          throw new Error(`${page} must be positive number`);
        }

        if (size <= 0) {
          throw new Error(`${size} must be positive number`);
        }

        if (page * size > max) {
          throw new Error(`Invalid elements to show`);
        }
      }
   }

   class Player {
     constructor(name) {
       this._name = name;
     }
   }

   class Playlist {
     //let playlistId = 0;
     constructor(name) {
       this._name = name;
       this._id = ++playlistId;
       this._listPlayables = [];
     }

     get Id(){
       return this._id;
     }

     get Name(){
       return this._name;
     }

     set Name(value){
       Validator.validateString(value, 'Playlist Name');
       this._name = value;
     }

     addPlayable(playable){
       Validator.validateIfUndefined(playable, 'Playlist add playable object');
       Validator.validateIfObject(playable, 'Playlist add playable object');
       Validator.validateIfUndefined(playable, 'Playlist add playable object');
       this._listPlayables.push(playable);
       return this;
     }

     getPlayableById(id){
       let i,
           len;
       Validator.validateIfUndefined(id,'Playable Id');
       Validator.validateNumber(id, 'Playable Id');

       for (i = 0, len = this._listPlayables.length; i < len; i+= 1) {
         let currentPlayableItem = this._listPlayables[i];
         if (currentPlayableItem.id === id) {
           return currentPlayableItem;
         }
       }
       return null;
     }

     removePlayable(id){
       let i,
           len;
       Validator.validateIfUndefined(id,'Playable Id');
       Validator.validateNumber(id, 'Playable Id');
       for (i = 0, len = this._listPlayables.length; i < len; i++) {
         let currentPlayableItem = this._listPlayables[i];
         if (currentPlayableItem.id === id) {
           this._listPlayables.splice(i,1);
         }
       }
       return this;
     }

     listPlayables(page, size){
       Validator.validatePageAndSize(page, size, this._listPlayables.length);

       return this
                 ._listPlayables
                 .slice()
                 .sort(getSortingFunction('title', 'id'))
                 .splice(page * size, size);
    }
  }

  class Playable {
    //var playableId = 0;
    constructor(title, author) {
      this._title = title;
      this._author = author;
      this._id = ++playableId;
    }

    get Title(){
      return this._title;
    }

    set Title(value){
      Validator.validateString(value, "Playable author");
      this._author = value;
    }

    get Author(){
      return this._author;
    }

    set Title(value){
      Validator.validateString(value, "Playable author");
      this._author = value;
    }

    get Id(){
      return this._id;
    }

    play(){
      return `${this._id} ${this._title} - ${this._author};`
    }
  }

  class Audio extends Playable {
    constructor(title, author, length) {
      super(title,author);
      this._length = length;
    }

    get Length() {
      return this._length;
    }

    set Length(value) {
      Validator.validateNumber(value, 'Audio length');
      this._length = value;
    }

    play(){
      return `${this._id} ${this._title} - ${this._length};`
    }
  }

  class Video extends Playable {
    constructor(title, author, imdbRating) {
      super(title, author);
      this._imdbRating = imdbRating;
      return this;
    }

    get ImdbRating() {
      return this._imdbRating;
    }

    set ImdbRating(value) {
      Validator.validateNumber(value, 'Audio length');
      this._length = value;
    }

    play(){
      return `${this._id} ${this._title} - ${this._length};`
    }
  }

  return {
  getPlayer: function (name){
      // returns a new player instance with the provided name
  },
  getPlaylist: function(name){
    return Object.create(playlist).init(name);
  },
  getAudio: function(title, author, length){
    return Object.create(audio).init(title,author,length);
  },
  getVideo: function(title, author, imdbRating){
    return Object.create(video).init(title, author, imdbRating);
  }
};
};

return module;
}
