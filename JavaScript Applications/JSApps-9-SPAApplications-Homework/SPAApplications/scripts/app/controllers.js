define(['areas/home/home', 'areas/login/login', 'areas/chat/chat', 'areas/about/about'],
    function (home, login, chat, about) {
        function initHome() {
            home.init();
        }

        function initLogin() {
            login.init();
        }

        function initChat() {
            chat.init();
        }

        function initAbout() {
            about.init();
        }

        return {
            initHome: initHome,
            initLogin: initLogin,
            initChat: initChat,
            initAbout: initAbout
        }
})