
//----------------------------------------------------
// To Do
//		A reference to this script in your index.hmtl
//----------------------------------------------------				
(function () {
    'use strict';
    //angular.module('fitnessApp').factory('fitnessApi', ['$http', '$q', '$ionicLoading', fitnessApi]);

    function fitnessApi($http, $q, $ionicLoading) {
        var selectedEquipment = [];

        //#region Public Methods
        function getEquipment(FitnessCenterId) {
            var deferred = $q.defer();

            $ionicLoading.show({
                template: 'Loading Equipment...'
            });

            $http.get("http://gis.phidev.com/PhitnessWebApi/api/equipment/center/" + FitnessCenterId)
                .success(function (data, status) {
                    console.log("Received equipment data via HTTP.", data, status);
                    $ionicLoading.hide();
                    deferred.resolve(data);
                })
                .error(function () {
                    console.log("Error while making HTTP call.");
                    $ionicLoading.hide();
                    deferred.reject();
                });

            return deferred.promise;
        }

        function getReservations(FitnessCenterId, DayId) {
            var deferred = $q.defer();

            $ionicLoading.show({
                template: 'Loading Reservations...'
            });

            $http.get("http://gis.phidev.com/PhitnessWebApi/api/reservations/center/" + FitnessCenterId + "/day/" + DayId)
                .success(function (data, status) {
                    console.log("Received reservations data via HTTP.", data, status);
                    $ionicLoading.hide();
                    deferred.resolve(data);
                })
                .error(function () {
                    console.log("Error while making HTTP call.");
                    $ionicLoading.hide();
                    deferred.reject();
                });

            return deferred.promise;
        }

        function getUser(userId) {
            var deferred = $q.defer();

            $ionicLoading.show({
                template: 'Loading User...'
            });

            $http.get("http://gis.phidev.com/PhitnessWebApi/api/users/" + userId)
                .success(function (data, status) {
                    console.log("Received user data via HTTP.", data, status);
                    $ionicLoading.hide();
                    deferred.resolve(data);
                })
                .error(function () {
                    console.log("Error while making HTTP call.");
                    $ionicLoading.hide();
                    deferred.reject();
                });

            return deferred.promise;
        }

        function getDayView(FitnessCenterId, DayId, UserId) {
            var deferred = $q.defer();

            var promiseRes = getReservations(FitnessCenterId, DayId);
            promiseRes.then(function (resForDay) {
                //console.log("resForDay", resForDay);

                var equ = selectedEquipment;
                //console.log("getDayView: selectedEquipment", equ);
				
                for (var i = 0; i < equ.length; i++) {
                    var res = getReservationsForEquipment(resForDay, equ[i].id, DayId);

                    for (var j = 0; j < res.length; j++) {
                        res[j].isReserved = true;
                        res[j].isSelf = res[j].userId === UserId;
                        res[j].startTimeId = res[j].startMinutesSinceMidnight;
                    }

                    equ[i].res = res;
                }

                var times = [];
                for (var t = 8 * 60; t < 17 * 60; t += 15) { // TODO: Will need to change to interval offsets not minutes.
                    var time = {
                        timeId: t,
                        timeDisplay: timeNumericToString(t),
                        equipments: []
                    }

                    for (var e = 0; e < equ.length; e++) {
                        var equip = {
                            EquipmentId: equ[e].id,
                            UserId: 0,
                            ReservationId: 0,
                            isReserved: false,
                            isSelf: false,
                            startTimeId: t,
                            endTimeId: t + 15
                        }

                        if (equ[e].res)
                            for (var r = 0; r < equ[e].res.length; r++)
                                if (equ[e].res[r].startTimeId === time.timeId) {
                                    equip = {
                                        EquipmentId: equ[e].id,
                                        UserId: equ[e].res[r].UserId,
                                        ReservationId: equ[e].res[r].id,
                                        isReserved: true,
                                        isSelf: equ[e].res[r].isSelf,
                                        startTimeId: equ[e].res[r].startTimeId,
                                        endTimeId: equ[e].res[r].endTimeId
                                    }
                                    //console.log("found " + time.timeDisplay, equip);
                                    break;
                                }

                        time.equipments.push(equip);
                    }

                    times.push(time);
                }

                deferred.resolve(times);
            });

            return deferred.promise;

            function getReservationsForEquipment(resForDay, equId, DayId) {
                var res = [];
                for (var i = 0; i < resForDay.length; i++)
                    if (resForDay[i].equipmentId === equId &&
                        resForDay[i].dayId == DayId) {
                        res.push(resForDay[i]);
                    }

                //console.log("res for equId " + equId, res);

                return res;
            }
        }

        function dayIdToDate(dayId) {
            var s = dayId.toString();

            var yyyy = Number(s.substr(0, 4));
            var mm = Number(s.substr(4, 2));
            var dd = Number(s.substr(6, 2));

            var day = new Date(yyyy, mm - 1, dd);

            return day;
        }

        function calculateDayId(day) {
            var yyyy = day.getFullYear().toString();
            var mm = (day.getMonth() + 1).toString(); // getMonth() is zero-based
            var dd = day.getDate().toString();
            return yyyy + (mm[1] ? mm : "0" + mm[0]) + (dd[1] ? dd : "0" + dd[0]); // padding
        }

        function addDays(date, daysToAdd) {
            date.setDate(date.getDate() + daysToAdd);
        }

        function setReservation(UserId, EquipmentId, DayId, StartTimeId) {
            var deferred = $q.defer();

            $ionicLoading.show({
                template: 'saving reservation...'
            });

            var data = {
                DayId: DayId,
                StartMinutesSinceMidnight: StartTimeId,
                EquipmentId: EquipmentId,
                UserId: UserId
            };

            $http.post("http://gis.phidev.com/PhitnessWebApi/api/reservations", data)
                .success(function (data, status) {
                    console.log("received setReservation data via http.", data, status);
                    $ionicLoading.hide();
                    deferred.resolve(data);
                })
                .error(function () {
                    console.log("error while making http call.");
                    $ionicLoading.hide();
                    deferred.reject();
                });

            return deferred.promise;
        }

        function deleteReservation(ReservationId) {
            var deferred = $q.defer();

            $ionicLoading.show({
                template: 'deleting reservation...'
            });

            $http.delete("http://gis.phidev.com/PhitnessWebApi/api/reservations/" + ReservationId)
                .success(function (data, status) {
                    console.log("received deleteReservation data via http.", data, status);
                    $ionicLoading.hide();
                    deferred.resolve(data);
                })
                .error(function () {
                    console.log("error while making http call.");
                    $ionicLoading.hide();
                    deferred.reject();
                });

            return deferred.promise;
        }

        return {
            getDayView: getDayView,
            getEquipment: getEquipment,
            getReservations: getReservations,
            setReservation: setReservation,
            deleteReservation: deleteReservation,
            selectedEquipment: selectedEquipment,
            getUser: getUser,

            dayIdToDate: dayIdToDate,
            calculateDayId: calculateDayId,
            addDays: addDays
        };
        //#endregion

        //#region Internal Methods
        function timeStringToNumeric(sTime) {
            var hour = 0;
            var minute = 0;

            var index = sTime.search(":");
            var hour = parseInt(sTime.substr(0, index));

            index++;
            var length = sTime.length - index;
            minute = parseInt(sTime.substr(index, length));

            return hour * 60 + minute;
        }

        function timeNumericToString(iNumeric) {
            var hh = (Math.floor(iNumeric / 60)).toString();
            var mm = (Math.floor(iNumeric % 60)).toString();

            var sTime = (hh[1] ? hh : "0" + hh[0]) + ":" + (mm[1] ? mm : "0" + mm[0]);
            return sTime;
        }

        //#endregion
    }
})();
