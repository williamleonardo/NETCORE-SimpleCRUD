(function (app) {
    app.controller('staffListController', staffListController);
    staffListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function staffListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.staffs = [];
        $scope.getStaffs = getStaffs;
        $scope.deleteStaff = deleteStaff;

        function getStaffs() {
            apiService.get('staffs', null, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('No Records Found');
                }

                $scope.staffs = result.data;
            }, function (error) {
                console.log(error);
            });
        }

        function deleteStaff(id) {
            $ngBootbox.confirm('Are you sure to delete?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('staffs/delete', config, function () {
                    notificationService.displaySuccess('Delete Successful');
                    getStaffs();
                }, function (error) {
                    notificationService.displayError('Delete Failed');
                });
            });
        }

        getStaffs();
    }
})(angular.module('company.staff'));