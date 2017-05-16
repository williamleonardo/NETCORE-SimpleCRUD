var appModule = angular.module('company.common');

appModule.service('constantService', constantService);

function constantService() {

    var constantService = {
        webApiUrl: {
            baseUrl : 'http://localhost:57614/api/'
        }
    }

    return constantService;
}