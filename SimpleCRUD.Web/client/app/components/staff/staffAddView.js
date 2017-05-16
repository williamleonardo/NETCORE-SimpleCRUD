(function (app) {
    app.controller('addStaffController', addStaffController);

    addStaffController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addStaffController(apiService, $scope, notificationService, $state) {
        $scope.staff = {
            departmentId: ''
        };

        $scope.AddStaff = AddStaff;

        function AddStaff() {
            apiService.post('staffs/create', $scope.staff,
            function (result) {
                notificationService.displaySuccess($scope.staff.FirstName + ' is added successful');
                $state.go('staff');
            },
            function (error) {
                notificationService.displayError('Failed to add Staff');
            });
        }

        function loadDepartmentList() {
            apiService.get('departments', null, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('No Records Found');
                }

                $scope.departments = result.data;
                $scope.staff.departmentId = $scope.departments["0"].id;
            }, function (error) {
                console.log(error);
            });
        }

        loadDepartmentList();
    }
})(angular.module('company.staff'));