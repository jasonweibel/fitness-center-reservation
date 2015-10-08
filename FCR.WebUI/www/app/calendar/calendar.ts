
//----------------------------------------------------
// To Do
//		A reference to this script in your index.hmtl
//----------------------------------------------------
(function () {
    'use strict';
    angular.module('fitnessApp').controller('calendarCtrl', ['$state', 'fitnessApi', calendarCtrl]);

    function calendarCtrl($state, fitnessApi) {
        var vm = this;

        var today = new Date();
        var calDate = new Date();

        generateCalendarData(calDate);

        vm.PreviousMonth = previousMonth;
        vm.NextMonth = nextMonth;
        vm.SelectDay = selectDay;

        function generateCalendarData(calDate) {
            var month = calDate.getMonth();
            //console.log("month", month);
            var year = calDate.getFullYear();

            var firstDateOfMonth = new Date(year, month, 1);
            //console.log("firstDateOfMonth", firstDateOfMonth);

            var firstDayOfMonth = firstDateOfMonth.getDay(); // 0 (Sun) to 6 (Sat)
            //console.log("firstDayOfMonth", firstDayOfMonth);

            var dayCycle = firstDateOfMonth;
            addDays(dayCycle, -firstDayOfMonth);
            //console.log("dayCycle", dayCycle);

            var weeks = [];
            do {
                var days = [];
                for (var i = 0; i < 7; i++) {
                    days.push({ // Day Properties go here.
                        isToday: dayCycle.toLocaleDateString() === today.toLocaleDateString(),
                        isCurrentMonth: dayCycle.getMonth() === calDate.getMonth(),
                        date: new Date(dayCycle),
                        number: dayCycle.getDate(),
                        Id: calculateDayId(dayCycle)
                    });
                    //console.log("week push", firstDateOfWeek);
                    addDays(dayCycle, 1);
                }

                weeks.push({
                    days: days
                });
            } while (dayCycle.getMonth() === calDate.getMonth());

            //vm.CalendarName = getMonthName(month) + ", " + year;
            vm.CalendarName = "Calendar";
            vm.month = getMonthName(month);
            vm.year = year;
            vm.weeks = weeks;

            //console.log("weeks", weeks);
        }

        function previousMonth() {
            addMonths(calDate, -1);
            generateCalendarData(calDate);
            //console.log("previousMonth", vm.month);
        }

        function nextMonth() {
            addMonths(calDate, 1);
            generateCalendarData(calDate);
            //console.log("nextMonth", vm.month);
        }

        function selectDay(day) {
            console.log("selectDay", day);
            $state.go("app.day", {
                DayId: day.Id,
                UserId: 1, // To Do: add user ID here.
            });
        }

        function calculateDayId(day) {
            var yyyy = day.getFullYear().toString();
            var mm = (day.getMonth() + 1).toString(); // getMonth() is zero-based
            var dd = day.getDate().toString();
            return yyyy + (mm[1] ? mm : "0" + mm[0]) + (dd[1] ? dd : "0" + dd[0]); // padding
        }
    }

    function addDays(date, daysToAdd) {
        date.setDate(date.getDate() + daysToAdd);
    }

    function addMonths(date, monthsToAdd) {
        date.setMonth(date.getMonth() + monthsToAdd);
    }

    function getMonthName(monthIndex) {
        switch (monthIndex) {
            case 0:
                return "January";
            case 1:
                return "February";
            case 2:
                return "March";
            case 3:
                return "April";
            case 4:
                return "May";
            case 5:
                return "June";
            case 6:
                return "July";
            case 7:
                return "August";
            case 8:
                return "September";
            case 9:
                return "October";
            case 10:
                return "November";
            case 11:
                return "December";
        }
    }

})();
