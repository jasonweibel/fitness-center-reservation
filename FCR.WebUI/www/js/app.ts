//----------------------------------------------------
// To Do	
//		A reference to this script in your index.hmtl
//----------------------------------------------------				
angular.module('fitnessApp', ['ionic'])

    .run(function ($ionicPlatform) {
        $ionicPlatform.ready(function () {
            // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
            // for form inputs)
            if (window.cordova && window.cordova.plugins.Keyboard) {
                cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            }
            if (window.StatusBar) {
                // org.apache.cordova.statusbar required
                StatusBar.styleDefault();
            }
        });
    })

    .config(function ($stateProvider, $urlRouterProvider) {
        $stateProvider

            .state('app', {
                url: "/app",
                abstract: true,
                templateUrl: "app/layout/menu-layout.html"
            })

            .state('app.calendar', {
                url: "/calendar",
                views: {
                    'mainContent': {
                        templateUrl: "app/calendar/calendar.html"
                    }
                }
            })

            .state('app.day', {
                params: { // Default parameters
                    DayId: calculateDayId(new Date()),
                    UserId: 1
                },

                views: {
                    'mainContent': {
                        templateUrl: "app/day/day.html"
                    }
                }
            })

            .state('app.equipment', {
                url: "/equipment",
                views: {
                    'mainContent': {
                        templateUrl: "app/equipment/equipment.html"
                    }
                }
            })

        ;
        // if none of the above states are matched, use this as the fallback
        $urlRouterProvider.otherwise('/app/calendar');

        function calculateDayId(day) {
            var yyyy = day.getFullYear().toString();
            var mm = (day.getMonth() + 1).toString(); // getMonth() is zero-based
            var dd = day.getDate().toString();
            return yyyy + (mm[1] ? mm : "0" + mm[0]) + (dd[1] ? dd : "0" + dd[0]); // padding
        }
    });
