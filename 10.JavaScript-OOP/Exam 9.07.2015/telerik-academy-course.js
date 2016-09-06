/* Task Description */
/*
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  var studentId = 0,
      Consecutive_WhiteSpaces = /\s\s+/,
      First_Letter_UpperCase = /[A-Z][a-z]*/;

  var presentation = {
    init: function (title, homework) {
      this._title = title;
      this._homework = homework;
      return this;
    }
  }

  var student = {
    init: function (firstName, lastName){
      this._id = ++studentId;
      this._firstName = firstName;
      this._lastName = lastName;
      return this;
    }
  }

  var validator = {
    validateNumber: function(number){
      if (typeof number === undefined) {
        throw new Error(`${number} is not defined`);
      }else if (typeof number !== 'number') {
        throw new Error(`${number} is not a number`);
      }
    },
    validateString: function(str){
        if (typeof str === undefined) {
          throw new Error(`${str} is undefined.`);
        }else if (typeof str !== 'string') {
          throw new Error(`${str} is not a string.`);
        }
        if (str[0] === ' ' || str[str.length - 1] === ' ') {
          throw new Error(`${str} can not start or end with white spaces.`);
        }else if (Consecutive_WhiteSpaces.test(str)) {
          throw new Error(`${str} can not contains consecutive white spaces.`);
        }
      },
    validateIfArray: function (arr) {
        if (typeof arr === undefined) {
          throw new Error(`${arr} is not defined.`);
        }
        if (!Array.isArray(arr)) {
          throw new Error(`${arr} is not with type array.`);
        }
        if (arr.length === 0) {
          throw new Error(`${arr} can not be empty.`);
        }
      },
    validateStudentName: function (name){
        this.validateString(name);
        if (!First_Letter_UpperCase.test(name)) {
          throw new Error(`${name} must start with capital letter.`);
        }
      },
    validateHomeworkId: function (id, length){
        if (id >= length || id < 0) {
          throw new Error(`There is no homework with this ${id}`);
        }
      }
    }

	var Course = {
		init: function(title, presentations) {
      validator.validateString(title);
      this._title = title;
      validator.validateIfArray(presentations);
      presentations.forEach(function (presentation) {
        validator.validateString(presentation);
      });
      this._presentations = presentations;
      this._students = [];
      this._homeworks = [];
      this._examResults = [];
      return this;
		},
		addStudent: function(name) {
      var names = name.split(' ');
      if (names.length !== 2) {
        throw new Error('Invalid names.');
      }
      if (names.length === 2) {
          names.forEach(function (name) {
            validator.validateStudentName(name);
          })
      }
      var currentStudent = Object.create(student).init(names[0],names[1]);
      this._students.push(currentStudent);
      return currentStudent._id;
		},
		getAllStudents: function() {
      var studentInfo = [];
      this._students.forEach(function (student) {
        studentInfo.push({
          firstname: student._firstName,
          lastname: student._lastName,
          studentID: student._id
        });
      })
      return studentInfo;
		},
		submitHomework: function(studentID, homeworkID) {
      var existingStudent = false;
      this._students.forEach(function (student) {
        if (student._id === studentID) {
          existingStudent = true;
        }
      })
      if (!existingStudent) {
        throw new Error(`There is no student with this ${studentID}`);
      }
      validator.validateHomeworkId(homeworkID, this._students.length);
      this._presentations[homeworkID - 1] = [];
      if (!this._homeworks[studentID]) {
          this._homeworks[studentID] = 0;
      }
      this._homeworks[studentID] += 1;
		},
		pushExamResults: function(results) {
      results.forEach(function (result) {
        validator.validateNumber(result.Score);
      });
      var existingId = false;
      var students = this._students;
      var examResults = this._examResults;
      results.forEach(function (result) {
        students.forEach(function(student){
          if (result.StudentID === student._id) {
            existingId = true;
          }
        })
        if (!existingId) {
          throw new Error(`There is no student with id: ${result.Score}`);
        }
        existingId = false;
      })
      results.forEach(function (result) {
        var existingResult = false;
        examResults.forEach(function (currentExam){
          if (currentExam.studentID === result.StudentID) {
            existingResult = true;
          }
        })
        if (!existingResult) {
          examResults.push({
            StudentID: result.StudentID,
            Score: result.Score
          })
        }
      })
		},
		getTopStudents: function() {
      debugger;
      var topTenStudents = [],
          finalScore = [];
          for (var i = 0, len = this._students.length; i < len; i+= 1) {
            var id = this._students[i]._id,
                examScore = this._examResults[id].Score || 0,
                homeworkCount = this._homeworks[id] || 0,
                score = (0.75 * examScore) + (0.25 * (homeworkCount / 5));

                finalScore[id] = {
                    Score: score,
                    ID: id
                };
          }
      finalScore.sort(function(score1, score2){
        return score2.Score - score1.Score;
      })
      for (i = 0; i < 10; i += 1) {
        if (finalScore[i]) {
            topTenStudents.push({StudentID: finalScore[i].ID, Score: finalScore[i].Score});
        } else {
            break;
        }
      }
      return topTenStudents;
		}
	};

	return Course;
};


module = solve();
var course = module.init('High Quality Code',
[
  'High Quality Methods',
  'High Quality Classes',
  'Naming identifiers',
  'Reformatting code',
  'Code documentation'
]);
course.addStudent('Alexander Nestorov');
course.addStudent('Martin Vesheff');
course.addStudent('Stoqn Uzunov');
//console.log(course.getAllStudents());
course.submitHomework(1,1);
course.pushExamResults([{StudentID: 1,Score: 200},{StudentID:3,Score: 100}]);
console.log(course);
console.log(course.getTopStudents());
