var data = (function () {
  const USERNAME_STORAGE_KEY = 'username-key';

  // start users
  function userLogin(user) {
    localStorage.setItem(USERNAME_STORAGE_KEY, user);
    return Promise.resolve(user);
  }

  function userLogout() {
    localStorage.removeItem(USERNAME_STORAGE_KEY)
    return Promise.resolve();
  }

  function userGetCurrent() {
    return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
  }
  // end users

  // start threads
  function threadsGet() {
    return new Promise((resolve, reject) => {
      $.getJSON('api/threads')
        .done(resolve)
        .fail(reject);
    })
  }

  function threadsAdd(title) {
    const url = 'api/threads';
    const request = {
      title: title,
      username: 'anonymous'
    }

    const promise = new Promise((resolve, reject) => {
    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json',
        data: JSON.stringify(request)
    })
      .done(resolve)
      .fail(reject);
    });

    return promise;
  }

  function threadById(id) {
    const baseUrl = 'api/threads/';
    const urlById = baseUrl + id;

    const promiseById = new Promise((resolve, reject) => {
      $.getJSON(urlById)
        .done(resolve)
        .fail(reject);
    });
  }

  function threadsAddMessage(threadId, content) {
    const apiUrl = `api/threads/${threadId}/messages`;
        const request = {
            username: 'anonymous',
            content: content
        };

        const promise = new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: apiUrl,
                data: JSON.stringify(request),
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });

        return promise;
  }
  // end threads

  // start gallery
  function galleryGet() {
    const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

    const promise = new Promise((resolve, reject) => {
            $.getJSON(REDDIT_URL)
                .done(resolve)
                .fail(reject);
        });

        return promise;
  }
  // end gallery

  return {
    users: {
      login: userLogin,
      logout: userLogout,
      current: userGetCurrent
    },
    threads: {
      get: threadsGet,
      add: threadsAdd,
      getById: threadById,
      addMessage: threadsAddMessage
    },
    gallery: {
      get: galleryGet,
    }
  }
})();
