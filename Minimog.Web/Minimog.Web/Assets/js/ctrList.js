angular.module('todoApp', [])
    .controller('ctrList',[ '$scope', function ($scope) {
        console.log("list");
        //var todoList = this;
        //todoList.todos = [
        //    { text: 'learn AngularJS', done: true },
        //    { text: 'build an AngularJS app', done: false }];

        //todoList.addTodo = function () {
        //    todoList.todos.push({ text: todoList.todoText, done: false });
        //    todoList.todoText = '';
        //};

        //todoList.remaining = function () {
        //    var count = 0;
        //    angular.forEach(todoList.todos, function (todo) {
        //        count += todo.done ? 0 : 1;
        //    });
        //    return count;
        //};

        //todoList.archive = function () {
        //    var oldTodos = todoList.todos;
        //    todoList.todos = [];
        //    angular.forEach(oldTodos, function (todo) {
        //        if (!todo.done) todoList.todos.push(todo);
        //    });
        //};

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
 }]).controller('loginController', function ($scope) {
     $scope.user = {};

     $scope.login = function () {
         // Perform login logic here
         console.log('Logging in:', $scope.user.username, $scope.user.password);
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