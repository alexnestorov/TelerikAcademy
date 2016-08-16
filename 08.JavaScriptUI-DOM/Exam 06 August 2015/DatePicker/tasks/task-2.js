function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };
        Date.prototype.getNextDay = function () {
          if(this.getDate() < daysInMonth(this.getFullYear(), this.getMonth() + 1)) {
            return new Date(this.getFullYear(), this.getMonth(), this.getDate() + 1);
          } else if (this.getDate() === daysInMonth(this.getFullYear(), this.getUTCMonth() + 1)) {
            return this.getNextMonth();
          }
        };
        Date.prototype.getNextMonth = function () {
          if (this.getMonth() < 11) {
            return new Date(this.getFullYear(), this.getMonth() + 1, 1);
          } else {
            return this.getNextYear();
          }
        };
        Date.prototype.getPreviousDay = function () {
          if(this.getDate() > 1) {
            return new Date(this.getFullYear(), this.getMonth(), this.getDate() - 1);
          } else {
            return this.getPreviousMonth();
          }
        };

        Date.prototype.getNextMonth = function () {
          if (this.getMonth() < 11) {
            return new Date(this.getFullYear(), this.getMonth() + 1, 1);
          } else {
            return this.getNextYear();
          }
        };

        Date.prototype.getPreviousMonth = function () {
          if (this.getMonth() > 0) {
            return new Date(this.getFullYear(), this.getMonth() - 1, daysInMonth(this.getFullYear(), this.getMonth()));
          } else {
            return this.getPreviousYear();
          }
        };

        Date.prototype.getNextYear = function () {
          return new Date(this.getFullYear() + 1, 0, 1);
        };

        Date.prototype.getPreviousYear = function () {
          return new Date(this.getFullYear() - 1, 11, 31);
        };
        // Wrap the input
        var divWrapper = $('<div />').addClass('datepicker-wrapper');
        this.addClass('datepicker').wrap(divWrapper);
        var input = this;

        var controlls = $('<div />').addClass('controls');

        var leftBtn = $('<button />').addClass('btn left').text('<').css('display','inline-block');

        var rightBtn = $('<button />').addClass('btn right').text('>').css('display','inline-block');

        var div = $('<div />').addClass('picker').hide();

        var divMonth = $('<div />').addClass('current-month').text('August' + ' 2016');



        var table;
        var date1 = new Date();
        var monthName = date1.getMonthName();
        var month = date1.getMonth();
        var year = date1.getYear() + 1900;
        var date = new Date(year, month, 1);
        createCalendar(date.getFullYear(),date.getMonth());
        function createCalendar(year, month) {
            var tr,td;
            table = $('<table />').addClass('calendar');
            for (var r = 0; r < 6; r+= 1) {
              tr = $('<tr />');
              for (var c = 0,len = WEEK_DAY_NAMES.length; c < len; c+= 1) {
                if (r === 0) {
                  td = $('<td />').text(WEEK_DAY_NAMES[c]).appendTo(tr);
                }else {
                  if (date.getMonth() !== month) {
                      td.addClass('another-month');
                  }else {
                      td.addClass('current-month');
                }
                  td.attr('data-info', date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear());
                  td = $('<td />').addClass('current-month').text(date.getDate()).appendTo(tr);
                }
                date = date.getNextDay();
              }
              table.append(tr);
            }
        }
        function daysInMonth(month, year) {
               return new Date(year, month, 0).getDate();
           }
        var divDate = $('<div />').addClass('current-date');
        var dateLink = $('<a />').addClass('current-date-link').text(date.getDay() + ' ' + monthName + ' ' + year);
        divDate.append(dateLink);

    $(this).on('click',function () {
      div.show();
    })
     $(dateLink).on('click','a',function(){
          var $target = $(this);

            //console.log($target.text());

            var newDate = new Date($target.text())
            $('#date').val(newDate.getDay()+'/'+(newDate.getMonth()+1)+'/'+(newDate.getYear()+1900));

            $('.picker').hide();


        })

      $(leftBtn).on('click',function(){
        date = date.getPreviousMonth();
        createCalendar(date.getFullYear(),date.getMonth());
        divMonth.text(MONTH_NAMES[date.getMonth()] + ' ' + date.getFullYear());
      })
      $(rightBtn).on('click',function(){
        date = date.getNextMonth();
        createCalendar(date.getFullYear(),date.getMonth());
        divMonth.text(MONTH_NAMES[date.getMonth()] + ' ' + date.getFullYear());
      })

      $(table).on('click',function(){
        var $target = $(this);
          var newDate = new Date(date.getFullYear(), date.getMonth());
          $(input).val(newDate.getDay()+'/'+(newDate.getMonth()) +'/'+(newDate.getYear()+1900));

          $('.picker').hide();

      })
      $(divDate).on('click',function(){
        var newDate = new Date(date.getFullYear(), date.getMonth());
        $(input).val(newDate.getDay()+'/'+(newDate.getMonth()) +'/'+(newDate.getYear()+1900));

        $('.picker').hide();
      })
        controlls.append(leftBtn);
        controlls.append(divMonth);
        controlls.append(rightBtn);
        div.append(controlls);
        div.append(table);
        div.append(divDate);
        div.insertAfter(this);

        return $(this);
    };
}

//module.exports = solve;
