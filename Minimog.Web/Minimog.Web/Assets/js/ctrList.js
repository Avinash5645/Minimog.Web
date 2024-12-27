angular.module('todoApp', ['ngCookies'])
    .controller('ctrList', ['$scope', function ($scope) {
        console.log("list");

        $scope.initList = function (model) {

            $scope.product = model;

        }
    }])
    .controller('crtDetail', ['$scope', '$window', function ($scope, $window) {
        console.log("detail");
        // Load cart items from localStorage
        $scope.cartItems = JSON.parse($window.localStorage.getItem('cart')) || [];
        
        // Save cart items to localStorage
        function saveToLocalStorage(cartItems) {
            $window.localStorage.setItem('cart', JSON.stringify(cartItems));
        }
        $scope.initDetail = function (model) {

            $scope.product = model;
            console.log("list");
        }
        $scope.addToCart = function (product) {
            console.log(product);
            // Initial product data
            var cartItem = {
                title: product.title,
                price: product.price,
                quantity: product.quantity,
                image: product.imageUrl
            };
            $scope.cartItems.push(cartItem);
            saveToLocalStorage($scope.cartItems);
            // send 1 to globalController  $scope.cartCount =  $scope.cartCount + 1
        }
        // Function to increment the quantity
        $scope.increment = function () {
            $scope.product.quantity++;
        };

        // Function to decrement the quantity
        $scope.decrement = function () {
            if ($scope.product.quantity > 1) {
                $scope.product.quantity--;
            }
        };



    }]).controller('globalController', function ($scope, $http, $location, $cookies, $window) {

        $scope.cartItems = JSON.parse($window.localStorage.getItem('cart')) || [];
        $scope.cartCount = $scope.cartItems.length;

     
        // // Function to calculate the total price
        $scope.getTotalPrice = function () {
            let total = 0;
            for (let product of $scope.cartItems) {
                total += product.price * product.quantity;
            }
            return total;
        };
        $scope.Total = $scope.getTotalPrice();
     
        $scope.callAddToCArt = function () {
            // Load cart items from localStorage
            $scope.cartItems = JSON.parse($window.localStorage.getItem('cart')) || [];

        }


        //check exiting user is active or not 
        var loginDetail = $cookies.get('loginDetails');
        if (typeof (loginDetail) != "undefined") {
            $scope.loginData = JSON.parse(loginDetail);

        }
        function saveToLocalStorage(cartItems) {
            $window.localStorage.setItem('cart', JSON.stringify(cartItems));
        }

        $scope.logout = function () {
            $cookies.remove("loginDetails", { path: "/" });
            window.location.reload();
        }
        // Function to remove an item from the cart
        $scope.removeFromCart = function (index) {
            $scope.cartItems.splice(index, 1);
            saveToLocalStorage($scope.cartItems);
            $scope.cartCount--;
        };

        // Function to increment the quantity of a cart item
        $scope.incrementItem = function (item) {
            item.quantity++;
            saveToLocalStorage($scope.cartItems);
            $scope.cartCount++;
        };

        // Function to decrement the quantity of a cart item
        $scope.decrementItem = function (item) {
            if (item.quantity > 1) {
                item.quantity--;
                saveToLocalStorage($scope.cartItems);

            }

        };
        // Function to update the quantity of a cart item on enter key
        $scope.enterQuantityItem = function (item) {
            if (item.quantity > 1) {
                saveToLocalStorage($scope.cartItems);
            }
        };


    }).controller('loginController', function ($scope, $http, $cookies) {
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
    });
