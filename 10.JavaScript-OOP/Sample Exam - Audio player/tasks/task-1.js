function solve(){
  var module = (function () {
    var player,
        playlist,
        playable,
        validator,
        audio,
        video,
        CONSTANTS = {
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

    validator = {
      validateIfUndefined: function (val, name) {
        name = name || 'Value';
        if (val === undefined) {
          throw new Error(name + ' can not be undefined');
        }
      },
      validateIfObject: function (val, name){
        name = name || 'Value';
        if (typeof val !== 'object') {
          throw new Error();
        }
      },
      validateString: function (val, name) {
        name = name || 'Value';
        if (val === undefined) {
          throw new Error(name + ' can not be undefined');
        }

        if (typeof val !== 'string') {
          throw new Error(name + ' must be with type string');
        }

        if (val.length < CONSTANTS.MIN_LENGTH || val.length > CONSTANTS.MAX_LENGTH) {
          throw new Error(name + ' has invalid length');
        }
      },
      validateNumber: function (val, name) {
        name = name || 'Value';
        if (val === undefined) {
          throw new Error(name + ' can not be undefined');
        }

        if (typeof val !== 'number') {
          throw new Error(name + ' must be a number');
        }

        if (val < 1) {
          throw new Error(name + ' must be positive number');
        }
      },
      validateImdbRating: function (val) {
        if (val === undefined) {
          throw new Error(name + ' can not be undefined');
        }

        if (typeof val !== 'number') {
          throw new Error(name + ' must be a number');
        }

        if (val < CONSTANTS.IMDB_MINRATING && val > CONSTANTS.IMDB_MAXRATING) {
          throw new Error('Invalid imdb rating.');
        }
      },
      validatePageAndSize: function (page, size, max){
        this.validateIfUndefined(page);
        this.validateIfUndefined(size);
        this.validateNumber(page);
        this.validateNumber(size);
        if (page < 0) {
          throw new Error('Page must be positive number');
        }

        if (size <= 0) {
          throw new Error('Size must be positive number');
        }

        if (page * size > max) {
          throw new Error('Invalid elements to show');
        }
      }
    };

    player = (function () {
      var player = Object.create({

      });

      Object.defineProperty(player,'init',{
        value: function (name) {
          this._name = name;
        }
      });

      //Object.defineProperty(player,'addPlaylist')

      return player;
    }())

    playlist = (function () {
      var playlistId = 0,
          playlist = Object.create({

          });
      Object.defineProperty(playlist,'init',{
        value: function (name){
            this._name = name;
            this._id = ++playlistId;
            this._listPlayables = [];
            return this;
            }
          });
      Object.defineProperty(playlist,'id',{
        get:function () {
          return this._id;
            }
          });

      Object.defineProperty(playlist,'name',{
        get:function () {
          return this._name;
          },
        set: function (val) {
          validator.validateString(val,'Playlist Name');
          this._name = val;
          }
        });

      Object.defineProperty(playlist, 'addPlayable',{
        value: function (playable) {
          validator.validateIfUndefined(playable, 'Playlist add playable object');
          validator.validateIfObject(playable, 'Playlist add playable object');
          validator.validateIfUndefined(playable, 'Playlist add playable object');
          this._listPlayables.push(playable);
          return this;
        }
      });

      Object.defineProperty(playlist, 'getPlayableById',{
        value: function (id) {
          var i,
              len;
          validator.validateIfUndefined(id,'Playable Id');
          validator.validateNumber(id, 'Playable Id');

          for (i = 0, len = this._listPlayables.length; i < len; i+= 1) {
            var currentPlayableItem = this._listPlayables[i];
            if (currentPlayableItem.id === id) {
              return currentPlayableItem;
            }
          }
          return null;
        }
      });

      Object.defineProperty(playlist, 'removePlayable',{
        value: function (id) {
          var i,
              len;
          validator.validateIfUndefined(id,'Playable Id');
          validator.validateNumber(id, 'Playable Id');
          for (i = 0, len = this._listPlayables.length; i < len; i++) {
            var currentPlayableItem = this._listPlayables[i];
            if (currentPlayableItem.id === id) {
              this._listPlayables.splice(i,1);
            }
          }
          return this;
        }
      });

    //  Object.defineProperty(playlist, 'removePlayable',{
    //    value: function (playable) {
    //      var i,
    //          len;
    //      validator.validateIfUndefined(playable,'Playable');
    //      validator.validateIfObject(playable, 'Playable');
    //      for (i = 0, len = this._listPlayables.length; i < len; i++) {
    //        var currentPlayableItem = this._listPlayables[i];
    //        if (currentPlayableItem === playable) {
    //          this._listPlayables.splice(i,1);
    //        }
    //      }
    //      return this;
    //    }
    //  });

      Object.defineProperty(playlist, 'listPlayables',{
        value: function (page, size) {
          validator.validatePageAndSize(page, size, this._listPlayables.length);

          return this
                    ._listPlayables
                    .slice()
                    .sort(getSortingFunction('title', 'id'))
                    .splice(page * size, size);
        }
      })

      return playlist;
    }());

    playable = (function () {
      var playableId = 0,
          playable = Object.create({

      });
      Object.defineProperty(playable,'init',{
        value: function (title, author){
          this.title = title;
          this.author = author;
          this.id = ++playableId;
          return this;
        }
      });

      Object.defineProperty(playable,'id',{
        get:function () {
          return this._id;
        }
      });

      Object.defineProperty(playable,'title',{
        get:function () {
          return this._title;
        },
        set: function (val) {
          validator.validateString(val,'Playable Title');
          this._title = val;
        }
      });

      Object.defineProperty(playable,'author',{
        get:function () {
          return this._author;
        },
        set: function (val) {
          validator.validateString(val,'Playable Author');
          this._author = val;
        }
      });

      Object.defineProperty(playable,'play',{
        value: function () {
          return this.id + '. ' + this.title + ' - ' + this.author;
        }
      });

      return playable
    }());

    audio = (function (parent) {
      var audio = Object.create(parent);

      Object.defineProperty(audio, 'init', {
        value: function (title, author, length) {
          parent.init.call(this, title, author);
          this.length = length;
          return this;
        }
      });

      Object.defineProperty(audio, 'length', {
        get: function () {
          return this._length;
        },
        set: function (val) {
          validator.validateNumber(val, 'Audio length');
          this._length = val;
        }
      });

      Object.defineProperty(audio, 'play', {
        value: function () {
            return parent.play.call(this) + ' - ' + this.length;
        }
      });

      return audio;
    }(playable));

    video = (function (parent) {
      var video = Object.create(parent);
      Object.defineProperty(video, 'init', {
        value: function (title, author, imdbRating) {
          parent.init.call(this, title, author);
          this.imdbRating = imdbRating;
          return this;
        }
      });

      Object.defineProperty(video, 'imdbRating', {
        get: function () {
          return this._imdbRating;
        },
        set: function (val) {
          validator.validateImdbRating(val, 'Imdb rating');
          this._imdbRating = val;
        }
      });

      Object.defineProperty(video, 'play', {
        value: function () {
            return parent.play.call(this) + ' - ' + this.imdbRating;
        }
      });

      return video;
    }(playable));

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
  }());

  return module;
}

var module = solve();

var playlist = module.getPlaylist('Trance remixes');
for (var i = 1; i < 12; i+= 1) {
  var currentAudio = module.getAudio('Audio' + i, 'Author' + i, i);
  playlist.addPlayable(currentAudio);
}

for (var i = 1; i < 27; i+= 1) {
  var currentVideo = module.getVideo('Video' + i, 'Author' + i, i);
  playlist.addPlayable(currentVideo);
}
console.log(playlist);
