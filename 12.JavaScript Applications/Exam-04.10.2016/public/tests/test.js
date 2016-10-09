mocha.setup('bdd');

const expect = chai.expect;
const SOME_TEMPLATE = Handlebars.compile("<div></div>");
const SOME_USER = "some_user";
const data = {
			result: [SOME_POST]
		};

describe("Test Controllers", function() {
    describe("User Controller Tests", function() {
        describe("Register Tests", function() {
            beforeEach(function() {
                sinon.stub(users, 'register')
                    .returns(Promise.resolve(SOME_USER));

                sinon.stub(templates, 'get')
                    .returns(Promise.resolve(SOME_TEMPLATE));
            });

            afterEach(function() {
                users.register.restore();
                templates.get.restore();
            });

            it("expect users.register() to be called exactly once", function(done) {
                usersController.register()
                    .then(() => {
                        expect(users.register.calledOnce).to.be.true;
                    })
                    .then(done, done);
            });

            it("expect templates.get() to be called exactly once", function(done) {
                usersController.register()
                    .then(() => {
                        expect(templates.get.calledOnce).to.be.true;
                    })
                    .then(done, done);
            });
        });

        describe("Login Tests", function() {
            beforeEach(function() {
                sinon.stub(users, 'login')
                    .returns(Promise.resolve(SOME_USER));

                sinon.stub(templates, 'get')
                    .returns(Promise.resolve(SOME_TEMPLATE));
            });

            afterEach(function() {
                users.login.restore();
                templates.get.restore();
            });

            it("expect users.login() to be called exactly once", function(done) {
                usersController.login()
                    .then(() => {
                        expect(users.login.calledOnce).to.be.true;
                    })
                    .then(done, done);
            });

            it("expect templates.get() when user found to be called exactly once", function(done) {
                usersController.login()
                    .then(() => {
                        expect(templates.get.calledOnce).to.be.true;
                    })
                    .then(done, done);
            });
        });
    });
});

mocha.run();
