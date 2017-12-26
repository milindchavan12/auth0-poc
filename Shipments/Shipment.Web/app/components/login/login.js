angular.module('shipments.login', ['auth0'])
    .controller('LoginCtl',
        function ($scope, auth, $location) {
            $scope.login = function() {
                auth.signin({},
                    function(profile, token) {
                        $location.path('/');
                    },
                    function(err) {
                        console.log('There was error while sign in' + err);
                    });
            }
        });