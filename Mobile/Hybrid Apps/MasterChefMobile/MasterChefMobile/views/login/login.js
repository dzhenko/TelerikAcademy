var app = app || {};
app.login = app.login || {};

(function (app) {
    app.login.model = kendo.observable({
        username: '',
        password: '',
        loginClick : function() {          
            var email = this.get('username');
            var password = this.get('password');
            
            var isEmailValid = app.validator.isValidEmail(email);
            var isPasswordValid = app.validator.isValidPassword(password);
            
            if (!isEmailValid || !isPasswordValid) {
                app.notifier.error('The email or password is incorrect.');
                return;
            }
            
            if (!app.connectionApi.hasConnection()) {
                app.notificationsApi.beep(1);
                app.notifier.error('Please check your connection before login...');
                return;
            }
            
            app.auth.login(email, password).then(function(data) {
                app.notifier.success('Logged in');
                app.main.navigate('views/home/home.html');
            }, app.errorHandler);
        },
        registerClick: function() {
            app.main.navigate('views/register/register.html');
        }
    });
}(app));