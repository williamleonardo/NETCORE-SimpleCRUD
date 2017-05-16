
(function (app) {
    app.factory('apiService', apiService);
    app.$inject = ['$http', 'notificationService', 'constantService'];
    function apiService($http, notificationService, constantService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        };

        function get(url, params, success, failure) {
            var targetUrl = constantService.webApiUrl.baseUrl + url;

            $http.get(targetUrl, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }

        function del(url, data, success, failure) {
            var targetUrl = constantService.webApiUrl.baseUrl + url;

            $http.delete(targetUrl, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    notificationService.displayError('Authenticate is required');
                }
                else if (failure !== null) {
                    failure(error);
                }

            });
        }

        function post(url, data, success, failure) {
            var targetUrl = constantService.webApiUrl.baseUrl + url;

            $http.post(targetUrl, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    notificationService.displayError('Authenticate is required');
                }
                else if (failure !== null) {
                    failure(error);
                }

            });
        }

        function put(url, data, success, failure) {
            var targetUrl = constantService.webApiUrl.baseUrl + url;
           
            $http.put(targetUrl, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === '401') {
                    notificationService.displayError('Authenticate is required');
                }
                else if (failure !== null) {
                    failure(error);
                }
            });
        }
    }
})(angular.module('company.common'));

