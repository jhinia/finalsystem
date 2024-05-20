using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kissbone_Cove_system
{
    internal class DataChecker
    {
        public static double totAmount { get; set; }
        public static chk dcheker = new chk();
        public static customerdata cd = new customerdata();
        public static roomdata ct = new roomdata();
        public static Reportsys rp = new Reportsys();
    }

    class chk
    {
        public Boolean chkr { get; set; }
        public string opt { get; set; }
    }
    class customerdata
    {
        public double todreven { get; set; }
        public int maxcustomer { get; set; }
        public int guestid { get; set; }
        public string paystatus { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string room { get; set; }
        public DateTime dateregistered { get; set; }
        public string contact_no { get; set; }
        public double totpayment { get; set; }
        public int totoccu { get; set; }
        public int room_id { get; set; }
        public int occupants { get; set; }
    }
    class roomdata
    {
        public int roomid { get; set; }
        public double price { get; set; }
        public string availability { get; set; }
        public DateTime date { get; set; }
        public int Capacity { get; set; }
    }
    class Reportsys
    {
        public int first { get; set; }
        public string firstName { get; set; }
        public int second { get; set; }
        public string secondName { get; set; }
        public int third { get; set; }
        public string thirdName { get; set; }

    }
}
