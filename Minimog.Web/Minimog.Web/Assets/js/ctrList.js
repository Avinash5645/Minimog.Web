angular.module('todoApp', ['ngCookies'])
    .controller('ctrList', ['$scope', function ($scope) {
        console.log("list");
       
        $scope.initList = function (model) {

            $scope.product = model;

        }
    }])
    .controller('crtDetail', ['$scope', function ($scope) {
        console.log("detail");

        $scope.initDetail = function (model) {

            $scope.product = model;
            console.log("list");
        }
    }]).controller('loginController', function ($scope, $http, $cookies) {
        $scope.user = {};

        $scope.login = function () {
            // Perform login logic here
            console.log('Logging in:', $scope.user.email, $scope.user.password);
            $http.post('/Account/LoginCheck', $scope.user)
                .then(function (response) {
                    if (response.data.IsValid) {
                        console.log('Registration successful:', response.data);
                        alert(response.data.Message);
                        iziToast.info({
                            title: 'Hello',
                            message: 'Welcome!',
                        });

                        // Save user data in cookies
                        const userData = {
                            name: response.data.Message,
                            isValid: response.data.IsValid
                        };
                        var loginDetails = JSON.stringify(userData);
                        $cookies.put('loginDetails', loginDetails, { path: '/' });
                        // Include the message as a query parameter in the URL
                        const redirectURL = '/Product/Index';
                        window.location.href = redirectURL;
                    }
                    else {
                        //alert(response.data.Message);
                        iziToast.error({
                            title: 'Error',
                            message: response.data.Message,
                            position: 'topRight',
                        });
                    }
                    // Clear form fields after successful registration
                    //vm.username = '';
                    //vm.email = '';
                    //vm.password = '';
                })
                .catch(function (error) {
                    console.error('Registration error:', error);
                });

        };
    }).controller('SignupController', function ($scope, $http) {
        var vm = this;

        vm.users = [];
        console.log(vm.users);
        vm.submitForm = function () {
            if ($scope.signupForm.$valid) {
                var userData = {
                    username: vm.username,
                    email: vm.email,
                    password: vm.password
                }

                vm.users.push(userData);
                console.log('UserData:', userData);
                // Send user data to backend
                $http.post('/Account/RegistrationData', userData)
                    .then(function (response) {
                        if (response.data.IsValid) {
                            console.log('Registration successful:', response.data);
                            alert(response.data.Message);
                            //  window.location.href = '@Url.Content("~/{Account}/{Login}")';
                            window.location.href = '/Account/Login'; // Modify the URL as needed
                        }
                        else {
                            alert(response.data.Message);
                        }
                        // Clear form fields after successful registration
                        //vm.username = '';
                        //vm.email = '';
                        //vm.password = '';
                    })
                    .catch(function (error) {
                        console.error('Registration error:', error);
                    });
            }

        };
    }).controller('globalController', function ($scope, $http, $location, $cookies) {

        //check exiting user is active or not 
        var loginDetail = $cookies.get('loginDetails');
        if (typeof (loginDetail) != "undefined") {
            $scope.loginData = JSON.parse(loginDetail);
           
        }

        $scope.logout = function ()
        {
            $cookies.remove("loginDetails", { path: "/" });
            window.location.reload();
        }



    });