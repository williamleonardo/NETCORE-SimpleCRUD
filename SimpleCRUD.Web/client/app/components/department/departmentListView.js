(function (app) {
    app.controller('departmentListController', departmentListController);
    departmentListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function departmentListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.departments = [];
        $scope.getDepartments = getDepartments;
        $scope.deleteDepartment = deleteDepartment;

        function getDepartments() {
            apiService.get('departments', null, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('No Records Found');
                }

                $scope.departments = result.data;
            }, function (error) {
                console.log('Load Department Fail. : ' + error);
            });
        }

        function deleteDepartment(id) {
            $ngBootbox.confirm('Are you sure to delete?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('departments/delete', config, function () {
                    notificationService.displaySuccess('Delete Successful');
                    getDepartments();
                }, function (error) {
                    notificationService.displayError('Delete Failed');
                });
            });
        }

        getDepartments();
    }
})(angular.module('company.department'));