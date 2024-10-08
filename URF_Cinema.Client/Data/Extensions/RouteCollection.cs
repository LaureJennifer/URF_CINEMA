﻿namespace URF_Cinema.Client.Data.Extensions
{
    public class RouteManager
    {
        public class Home
        {
            public static string AdminHome = "/";

        }
        public class Bill
        {
            public static string List = "/bill/list";

        }
        public class Customer
        {
            public static string List = "/customer/list";

        }
        public class Department
        {
            public static string List = "/department/list";

        }
        public class Film
        {
            public static string List = "/film/list";

        }
        public class FilmSchedule
        {
            public static string List = "/filmschedule/list";

        }
        public class Room
        {
            public static string List = "/room/list";

        }
        public class Ticket
        {
            public static string List = "/ticket/list";

        }
        public class User
        {
            public static string List = "/user/list";

        }
        public class PaymentMethod
        {
            public static string Payment = "/payment";

        }
        public class Transaction
        {
            public static string CaseHistory = "/casehistory";

        }
        public class Seat
        {
            public static string List = "/seat/list";

        }
        public class Statistic
        {
            public static string BillStatistic = "/bill-statistic";
            public static string FilmStatistic = "/film-statistic";
        }
        public class RoomLayout
        {
            public static string ExcelImport = "/admin/excel-import";
            public static string List = "/room-layout/list";
        }
    }
}
