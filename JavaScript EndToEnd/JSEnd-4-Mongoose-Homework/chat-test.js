var chat = require('./chat-db');

chat.registerUser({user:'Pesho', pass:'qwe'});
chat.registerUser({user:'Gosho', pass:'qwe'});
chat.registerUser({user:'Ivan', pass:'qwe'});

chat.sendMessage({
    from: 'Pesho',
    to: 'Gosho',
    text: 'Zdrasti Gosho'
});

chat.sendMessage({
    from: 'Pesho',
    to: 'Ivan',
    text: 'Zdrasti Ivan'
});

chat.sendMessage({
    from: 'Gosho',
    to: 'Pesho',
    text: 'Zdrasti Pesho'
});

chat.sendMessage({
    from: 'Pesho',
    to: 'Gosho',
    text: 'Kakvo stava Gosho'
});

chat.sendMessage({
    from: 'Gosho',
    to: 'Pesho',
    text: 'Nishto Pesho'
});

chat.getMessages({
    with: 'Gosho',
    and: 'Pesho'
}, function(messages) {
    console.log(messages);
});