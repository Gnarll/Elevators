using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftModel
{
    public class Person
    {
        private string SystemName { get; set; }
        public int StartFloor { get; set; }
        public int TargetFloor { get; set; }

        public string Info
        {
            get
            {
                return SystemName + " - едет c " + StartFloor.ToString() + " на  " + TargetFloor.ToString();
            }
        }
        public Person(int startFloor, int targetFloor)
        {
            Random r = new Random();
            SystemName = "№ " + r.Next(100).ToString();

            StartFloor = startFloor;
            TargetFloor = targetFloor;
        }
    }
}
