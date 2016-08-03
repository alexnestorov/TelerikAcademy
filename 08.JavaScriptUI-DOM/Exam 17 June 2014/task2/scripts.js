/* globals $ */
$.fn.gallery = function(columns) {
  columns = columns || 4;
  var $p, $n;
  var $this = $(this);
  console.log($this);
  var $containers = $this.find('.image-container');
  $this.addClass('gallery');
  var $selected = $this.children('.selected');
  $selected.hide();

  var $imageContainer = $this.find('.image-container');
  $imageContainer.each(function(index, element) {
    if (index % columns === 0) {
      $(element).addClass('clearfix');
    }
  });

  var $galleryList = $this.children('.gallery-list');
  var $current = $this.find('#current-image');
  var $prev = $this.find('#previous-image');
  var $next = $this.find('#next-image');
  $galleryList.on('click', '.image-container', function() {
    var $this = $(this);
    var index = +$this.find('img').attr('data-info');
    var prevIndex = 0;
    var nextIndex = 0;
    $current.attr('src', $this.find('img').attr('src')).attr('data-info', index);
    if (index === 1) {
      $p = $containers.last();
      $n = $this.next();
      prevIndex = 12;
      nextIndex = index + 1;
    } else if (index === 12) {
      $p = $this.prev();
      $n = $containers.first();
      prevIndex = index - 1;
      nextIndex = 1;
    } else {
      $p = $this.prev();
      $n = $this.next();
      prevIndex = index - 1;
      nextIndex = index + 1;
    }
    $prev.attr('src', $p.find('img').attr('src')).attr('data-info', prevIndex);
    $next.attr('src', $n.find('img').attr('src')).attr('data-info', nextIndex);

    $galleryList.addClass('blurred');
    $('<div />').addClass('disabled-background').appendTo($this);
    $selected.show();
  })

  $prev.on('click', function() {
    var $this = $(this);
    index = (+$this.attr('data-info'));
    if (index === 1) {
      prevIndex = 12;
      nextIndex = index + 1;
    } else if (index === 12) {
      prevIndex = index - 1;
      nextIndex = 1;
    } else {
      prevIndex = index - 1;
      nextIndex = index + 1;
    }
    var $pr = $containers.eq(prevIndex - 1).find('img');
    var $cu = $containers.eq(index - 1).find('img');
    var $ne = $containers.eq(nextIndex - 1).find('img');
    $current.attr('src', $cu.attr('src')).attr('data-info', index);
    $prev.attr('src', $pr.attr('src')).attr('data-info', prevIndex);
    $next.attr('src', $ne.attr('src')).attr('data-info', nextIndex);
  })

  $next.on('click', function() {
    var $this = $(this);
    index = (+$this.attr('data-info'));
    if (index === 1) {
      prevIndex = 12;
      nextIndex = index + 1;
    } else if (index === 12) {
      prevIndex = index - 1;
      nextIndex = 1;
    } else {
      prevIndex = index - 1;
      nextIndex = index + 1;
    }
    var $pr = $containers.eq(prevIndex - 1).find('img');
    var $cu = $containers.eq(index - 1).find('img');
    var $ne = $containers.eq(nextIndex - 1).find('img');
    $current.attr('src', $cu.attr('src')).attr('data-info', index);
    $prev.attr('src', $pr.attr('src')).attr('data-info', prevIndex);
    $next.attr('src', $ne.attr('src')).attr('data-info', nextIndex);
  })
  $current.on('click', function() {
    $selected.fadeOut(3000);
    $galleryList.removeClass('blurred');
    $(".disabled-background").remove();
  })
  var $gallery = $this.find('#gallery');
  return this;
};
