
module app.calendar {
	interface ICalendarModel {
		CalendarName: string;
		Month: string;
		Year: any;
		Weeks: any[];

		PreviousMonth(): void;
		NextMonth(): void;
		//SelectDay(): void;
	}

	class CalendarCtrl implements ICalendarModel {
		CalendarName: string;
		Month: string;
		Year: any;
		Weeks: any[];

		_dtToday: Date;
		_dtCalDate: Date;

		constructor($scope) {
			this.CalendarName = "Name";
			this.Month = "Month";
			this.Year = 2015;

			this._dtToday = new Date();
			this._dtCalDate = new Date();

			this.generateCalendarData(this._dtCalDate);
		}

		PreviousMonth(): void {
			this.addMonths(this._dtCalDate, -1);
			this.generateCalendarData(this._dtCalDate);
			//console.log("previousMonth", vm.month);
		}

		NextMonth(): void {
			this.addMonths(this._dtCalDate, 1);
			this.generateCalendarData(this._dtCalDate);
			//console.log("nextMonth", vm.month);
		}

		//SelectDay(): void {
		//    console.log("selectDay", day);
		//    $state.go("app.day", {
		//        DayId: day.Id,
		//        UserId: 1, // To Do: add user ID here.
		//    });
		//}

		generateCalendarData(calDate: Date): void {
			var month = calDate.getMonth();
			//console.log("month", month);
			var year = calDate.getFullYear();

			var firstDateOfMonth: Date = new Date(year, month, 1);
			//console.log("firstDateOfMonth", firstDateOfMonth);

			var firstDayOfMonth = firstDateOfMonth.getDay(); // 0 (Sun) to 6 (Sat)
			//console.log("firstDayOfMonth", firstDayOfMonth);

			var dayCycle: Date = firstDateOfMonth;
			this.addDays(dayCycle, -firstDayOfMonth);
			//console.log("dayCycle", dayCycle);

			var weeks: Week[] = [];
			do {
				var days: Day[] = [];
				for (var i = 0; i < 7; i++) {
					days.push({ // Day Properties go here.
						IsToday: dayCycle.toLocaleDateString() === this._dtToday.toLocaleDateString(),
						IsCurrentMonth: dayCycle.getMonth() === calDate.getMonth(),
						Date: new Date(dayCycle.toDateString()),
						Number: dayCycle.getDate(),
						Id: this.calculateDayId(dayCycle)
					});
					//console.log("week push", firstDateOfWeek);
					this.addDays(dayCycle, 1);
				}

				weeks.push({
					Days: days
				});
			} while (dayCycle.getMonth() === calDate.getMonth());

			//vm.CalendarName = getMonthName(month) + ", " + year;
			this.CalendarName = "Calendar";
			this.Month = this.getMonthName(month);
			this.Year = year;
			this.Weeks = weeks;

			//console.log("weeks", weeks);
		}

		addDays(date, daysToAdd): void {
			date.setDate(date.getDate() + daysToAdd);
		}

		addMonths(date, monthsToAdd): void {
			date.setMonth(date.getMonth() + monthsToAdd);
		}

		getMonthName(monthIndex): string {
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

		calculateDayId(day): string {
			var yyyy = day.getFullYear().toString();
			var mm = (day.getMonth() + 1).toString(); // getMonth() is zero-based
			var dd = day.getDate().toString();
			return yyyy + (mm[1] ? mm : "0" + mm[0]) + (dd[1] ? dd : "0" + dd[0]); // padding
		}
	}

	//angular.module('fitnessApp')
	//	.controller('CalendarCtrl', ['$state', 'fitnessApi', CalendarCtrl]);
	angular.module('fitnessApp')
		.controller('CalendarCtrl', [CalendarCtrl]);

	class Day {
		IsToday: boolean;
		IsCurrentMonth: boolean;
		Date: Date;
		Number: number;
		Id: string;
	}

	class Week {
		Days: Day[];
	}
}