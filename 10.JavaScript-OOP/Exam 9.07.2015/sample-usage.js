function solve(){
	'use strict'
	let itemId = 0,
			catalogId = 0;
	class Item{

		constructor(name, description){
			this._id = ++itemId;

			if (typeof name !== 'string') {
				throw new Error('Name must be with type string.')
			}else if (name.length < 2 || name.length > 40) {
				throw new Error(`${name} is with invalid length.`);
			}
			this._name = name;

			if (typeof description !== 'string') {
				throw new Error('Description must be with type string.')
			}else if (description === '') {
				throw new Error('Description could not be empty string.')
			}
			this._description = description;

		};

		get id(){
			return this._id;
		}

		get name(){
			return this._name;
		}

		get description(){
			return this._description;
		}
	};

	class Book extends Item {
		constructor(name, isbn, genre, description){
			super(name, description);
			if (typeof isbn !== 'string') {
				throw new Error('Description must be with type string.')
			}else if (isbn.length < 10 || isbn.length > 13) {
				throw new Error(`${isbn} is with invalid length.`)
			}else {
				for (let i = 0, len = isbn.length; i < len; i+= 1) {
					if (typeof +isbn[i] !== 'number') {
						throw new Error('Invalid isbn');
					}
				}
			}
			this._isbn = isbn;
			if (typeof genre !== 'string') {
				throw new Error('Description must be with type string.')
			}else if (genre.length < 2 || genre.length > 20) {
				throw new Error(`${genre} is with invalid length.`)
			}
			this._genre = genre;
		};



		get isbn(){
			return this._isbn
		}

		get genre(){
			return this._genre;
		}
	};

	class Media extends Item {
		constructor(name, rating, duration, description){
			super(name, description);
			if (typeof rating !== 'number') {
				throw new Error(`${rating} is not a number`);
			}else if (rating < 1 || rating > 5) {
				throw new Error(`${rating} is invalid rating range.`);
			}
			this._rating = rating;

			if (typeof duration !== 'number') {
				throw new Error(`${duration} is not a number.`);
			}else if (duration < 0) {
				throw new Error(`${duration} is invalid duration.`)
			}
			this._duration = duration;
		};

		get rating(){
			return this._rating;
		}
		get duration(){
			return this._duration;
		}
	};

	class Catalog {
		constructor(name, items){
			items = items || [];
			this._id = ++catalogId;

			if (typeof name !== 'string') {
				throw new Error(`${name} must be with type string.`)
			}else if (name.length < 2 || name.length > 40) {
				throw new Error(`${name} is with invalid length.`);
			}
			this._name = name;

			if (typeof items !== 'object') {
				throw new Error(`${items} must be an array.`);
			}
			this._items = items;
		};

		get id(){
			return this._id;
		}
		get name(){
			return this.name;
		}
		get items(){
			return this._items;
		}

		add(...args){
			if (arguments.length === 0) {
				throw new Error('No items were passed.')
			}else {
				for (let i = 0, len = arguments.length; i < len; i+=1) {
					if (arguments[i] instanceof Item === false) {
						throw new Error('${arguments[i]} is not instance of Item.')
					}
				}
			}
			for (let i = 0, len = arguments.length; i < len; i+=1) {
				this._items.push(arguments[i]);
			}
			return this;
		}
		add(itemsArray){
			if (itemsArray === undefined) {
				throw new Error(`${itemsArray} is not with type Array.`);
			}else if (itemsArray.length < 1) {
				throw new Error(`${itemsArray} has length with less than one parameter.`);
			}else if (typeof (itemsArray.length) !== 'undefined') {
        return this.add.apply(this, itemsArray);
      }else {
				for (let i = 0, len = itemsArray.length; i < len; i+=1) {
					if (itemsArray[i] instanceof Item === false) {
						throw new Error('${arguments[i]} is not instance of Item.')
					}
				}
			}
			for (let i = 0, len = itemsArray.length; i < len; i+=1) {
				this._items.push(itemsArray[i]);
			}
		}
		find(id){
			if (typeof id === undefined) {
				throw new Error('No arguments were passed.');
			}else if (typeof id !== 'number') {
				throw new Error(`${id} is not a number.`);
			}
			let foundItem;
			for (let i = 0, len = this._items.length; i < len; i+= 1) {
				let currentItemId = this._items[i].id;
				if (currentItemId === id) {
					foundItem = this._items[i];
					return foundItem;
				}
			}
		}
		search(pattern){
			if (typeof (pattern) !== 'string' ||
        pattern.length < 1 ||
        pattern.length > Infinity) {
        throw new Error('The string must have at least 1 character');
      }
      pattern = pattern.toLowerCase();
      return this.items.filter(function (item) {
          return item.name.toLowerCase().indexOf(pattern) >= 0 ||
                item.description.toLowerCase().indexOf(pattern) >= 0;
      });
		}
	};

	class BookCatalog extends Catalog {
		constructor(name, items){
			super(name, items);
		};
		add(booksItems){
			debugger;
			if (booksItems === undefined) {
				throw new Error(`${booksItems} is not with type Array.`);
			}else if (booksItems.length < 1) {
				throw new Error(`${booksItems} has length with less than one parameter.`);
			}else if (typeof (bookItems.length) === 'undefined') {
        return this.add.apply(this, bookItems);
      }else {
				for (let i = 0, len = booksItems.length; i < len; i+=1) {
					if (booksItems[i] instanceof Book === false) {
						throw new Error('${arguments[i]} is not instance of Item.')
					}
				}
			}
			for (let i = 0, len = booksItems.length; i < len; i+=1) {
				this._items.push(booksItems[i]);
			}
		};
		getGenres(){
			let genres = {};
          this._items.forEach(function (item) {
              genres[item.genre.toLowerCase()] = 1;
          });
          return Object.keys(genres);
		};
		find(options){
			if (typeof (options) === 'undefined') {
                throw new Error('Id must be a number');
            }
            let isOnlyId = false,
                result;
            if (typeof (options) === 'number') {
                options = {
                    id: options
                };
                isOnlyId = true;
            }
            result = this._items.filter(function (item) {
                return Object.keys(options)
                    .every(function (key) {
                        return options[key] === item[key];
                    });
            });
            if (isOnlyId) {
                if (result.length) {
                    return result[0];
                }
                return null;
            }
            return result;
		};
	};

	class MediaCatalog extends Catalog{
		constructor(name, items){
			super(name,items);
		}
		add(mediaItems){
			if (mediaItems === undefined) {
				throw new Error(`${mediaItems} is not with type Array.`);
			}else if (mediaItems.length < 1) {
				throw new Error(`${mediaItems} has length with less than one parameter.`);
			}else {
				for (let i = 0, len = mediaItems.length; i < len; i+=1) {
					if (mediaItems[i] instanceof Media === false) {
						throw new Error('${arguments[i]} is not instance of Item.')
					}
				}
			}
			for (let i = 0, len = mediaItems.length; i < len; i+=1) {
				this._items.push(mediaItems[i]);
			}
		};
		getTop(count){
			if (typeof count === undefined) {
				throw new Error('Invalid count.');
			}else if (typeof count !== 'number') {
				throw new Error('Count is not a number.')
			}else if (count < 2) {
				throw new Error('Count must be more than 1.')
			}
			let items = this.items.slice();
          items.sort(function (i1, i2) {
            return i2.rating - i1.rating;
          });
          return items.slice(0, count)
                .map(function(item){
                  return {
                    id: item.id,
                    name: item.name
                };
          });
		};
		getSortedByDuration(){
			debugger;
			let itemsToReturn = this._items.slice();
          itemsToReturn.sort(function(i1, i2){
          if(i1.duration === i2.duration){
            return i1.id - i2.id;
          }
          return i2.duration - i1.duration;
      });
			return itemsToReturn;
		}
	}
	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};
}

var module = solve();
//var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'Math', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
var media1 = module.getMedia('BTV',3,224,'Popular media in Bulgaria.');
var media2 = module.getMedia('BNT',2,324,'National media in Bulgaria.');
var media3 = module.getMedia('Diema',4,124,'Sport media in Bulgaria.');
var catalog = module.getBookCatalog('Book for Magicians');
//console.log(book1);
//console.log(book2);
//console.log(media1);
//console.log(catalog);
var mediaCatalog = module.getMediaCatalog('Bulgarian medias')
var books = [book1,book2];
var medias = [media1,media2,media3];
console.log(mediaCatalog.add(medias));
console.log(mediaCatalog.getTop(2));
console.log(mediaCatalog.getSortedByDuration());
//console.log(catalog.find(book1.id));
//returns book1

//console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

//console.log(catalog.search('js'));
// returns book2

//console.log(catalog.search('javascript'));
//returns book1 and book2

//console.log(catalog.search('Te sa zeleni'))
//returns []
