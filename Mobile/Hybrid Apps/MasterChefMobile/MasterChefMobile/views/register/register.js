var app = app || {};
app.register = app.register || {};

(function (app) {
    app.register.model = kendo.observable({
        regUsername: '',
        regPassword: '',
        regConfirmPassword: '',
        registerClick : function() {
            var email = this.get('regUsername');
            var password = this.get('regPassword');
            var confirmPassword = this.get('regConfirmPassword');
            
            var isUsernameValid = app.validator.isValidEmail(email);
            if (!isUsernameValid) {
                app.notifier.error('The email is incorrect.');
                return;
            }
            
            var isPasswordValid = app.validator.isValidPassword(password);
            var isConfirmPasswordValid = app.validator.isValidPassword(confirmPassword);
            if (!isPasswordValid || !isConfirmPasswordValid) {
                app.notifier.error('The password is incorrect.');
                return;
            }
            
            if (!app.validator.passwordsMatches(password, confirmPassword)) {
               app.notifier.error('The password and confirmation password do not match.');
                return;
            }
            
            if (!app.connectionApi.hasConnection()) {
                app.notificationsApi.beep(1);
                app.notifier.error('Please check your connection before register...');
                return;
            }
            
            app.auth.register(email, password, confirmPassword).then(function(data) {
                app.notifier.success('Registered');
                app.main.navigate('views/login/login.html');
            }, app.errorHandler);
        }
    });
}(app));