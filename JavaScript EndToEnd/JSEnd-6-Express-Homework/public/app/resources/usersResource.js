app.factory('UsersResource', function($resource) {
    'use strict';

    return $resource('/api/users/:id', {_id: '@id'}, {update: {method:'PUT', isArray:false}});
});