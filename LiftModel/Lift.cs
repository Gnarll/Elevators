using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftModel
{
    public class Lift
    {
        public int Floors { get; set; }
        public int CurrentFloor { get; set; } = 1;

        public List<LiftButton> Buttons { get; set; } = new List<LiftButton>();
        public List<Person> Queue { get; set; } = new List<Person>();
        public List<Person> Pessengers { get; set; } = new List<Person>();
        public int ActiveUsers => Pessengers.Count + Queue.Count;
        public int CurrentMin = 0;
        public int CurrentSec = 0;
        private int timeMoving = 1000;
        public bool IsMove { get; set; } = false;
        public bool IsEmpty { get; set; } = true;
        public int GetTimeMoving()
        {
            return timeMoving;
        }

        public void SetTimeMoving(int value)
        {
            timeMoving = value;
        }

        public Lift(int floors)
        {
            Floors = floors;
            InitializeButtons();
        }

        public void Move()
        {
                IsMove = true;
                CurrentFloor++;
        }

        public void AddToQueue(Person person)
        {
            Queue.Add(person);
        }

        private void InitializeButtons()
        {
            for (int i = 1; i <= Floors; i++)
            {
                LiftButton lb = new LiftButton(i, false);
                Buttons.Add(lb);

            }
        }



        public void TimerUpdate()
        {
            CurrentSec++;
            if (CurrentSec > 60)
            {
                CurrentSec = 0;
                CurrentMin++;
            }
        }
    }
}
