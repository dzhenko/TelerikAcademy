var util = require('util'),
    db = require('./../db.js');

exports.index = function(req, res) {

    res.render('customer/index',{ title: 'Customer List', customers: db.listCustomers()});
};

exports.create = function (req, res) {

    res.render('customer/create');
};

exports.createCustomer = function (req, res) {

    console.dir(req.files.picture);
    db.addCustomer({name: req.body.name, email: req.body.email, telephone: req.body.telephone, picture: req.files.picture.path});

    res.redirect('/customer');
};

exports.edit = function (req, res) {

    var customer = db.getCustomerById(req.params.id);

    res.render('customer/edit', { customer: customer });

};

exports.editCustomer = function (req, res) {

    db.updateCustomer({ id: req.params.id, name:req.body.name, email:req.body.email, telephone:req.body.telephone});

    res.redirect('/customer');

};

exports.delete = function (req, res) {
    db.deleteCustomer(req.params.id);
    res.redirect('/customer');
};

exports.details = function (req, res) {
    var customer = db.getCustomerById(req.params.id);

    if (customer) {
        res.format({
            html: function () { res.render('customer/details', { customer: customer} ); },
            json: function () { res.json(JSON.stringify(customer));},
            text: function () { res.send(util.format('Name: %s - Email: %s - Telephone: %s', customer.name, customer.email, customer.telephone))}
        });
    } else {
        res.send(404, 'Not found');
    }
};

exports.picture = function (req, res) {
    var customer = db.getCustomerById(req.params.id);
    if (req.query.attachment === 'true') {
        res.download(customer.picture);
    } else {
        res.sendfile(customer.picture);
    }
};

