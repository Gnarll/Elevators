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
        Direction LiftDirection = Direction.Up;
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
            if (ActiveUsers > 0)
            {
                IsMove = true;
                if (Pessengers.Count == 0)
                {
                    if (!IsEmpty)
                    {
                        IsEmpty = true;
                    }
                    SetDirectionIfEmpty();
                }
                else
                {
                    CheckState();
                }
                Transfer();
                if (Pessengers.Count > 0)
                {
                    IsEmpty = false;
                }
            }
            else
            {

                Wait();
            }
           
        }

        private void Wait()
        {

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

        private void Enter()
        {
            List<Person> CriticalPerson = new List<Person>();
            CriticalPerson = Queue.FindAll(item => item.StartFloor == CurrentFloor);
            Pessengers.AddRange(CriticalPerson);
            Queue.RemoveAll(item => item.StartFloor == CurrentFloor);

        }

        private void ExitFrom()
        {
            List<Person> CriticalPerson = new List<Person>();
            CriticalPerson = Pessengers.FindAll(item => item.TargetFloor == CurrentFloor);
            Pessengers.RemoveAll(item => item.TargetFloor == CurrentFloor);
        }

        private void Transfer()
        {

            if (Pessengers.FindAll(item => item.TargetFloor == CurrentFloor).Count + Queue.FindAll(item => item.StartFloor == CurrentFloor).Count > 0)
            {
                ExitFrom();
                Enter();

            }
            else
            {
                GoToNextFloor();
            }
        }

        private void GoToNextFloor()
        {
            if (Pessengers.Count > 5)
            {
                Pessengers.Remove(Pessengers.Last());
            }
            else
            {
                if (LiftDirection == Direction.Up)
                    CurrentFloor++;
                else CurrentFloor--;
            }
        }

        private void CheckState()
        {
            // будем менять направление движения?
            bool IsChangeDirection = true;

            foreach (Person pe in Pessengers)
            {
                // если текущее направление - вверх и есть пассажиры с целевым этажом больше текущего, то направление движения не меняем.
                if (LiftDirection == Direction.Up)
                {
                    if (pe.TargetFloor > CurrentFloor)
                        IsChangeDirection = false;
                }
                // если текущее направление -вниз и есть пассажиры с целевым этажом меньше текущего, то направление движения не меняем.
                else
                {
                    if (pe.TargetFloor < CurrentFloor)
                        IsChangeDirection = false;
                }
            }
            if (IsChangeDirection)
            {

                if (LiftDirection == Direction.Up)
                    LiftDirection = Direction.Down;
                else LiftDirection = Direction.Up;
            }
        }

        private void SetDirectionIfEmpty()
        {
            Person TargetPerson = null;
            int way = this.Floors + 1; 
            foreach (Person pe in Queue)
            {
                if (Math.Abs(pe.StartFloor - CurrentFloor) < way)
                {
                    way = Math.Abs(pe.StartFloor - CurrentFloor);
                    TargetPerson = pe;
                }
            }

            if (TargetPerson.StartFloor >= CurrentFloor)
            {
                LiftDirection = Direction.Up;
            }
            else
            {
                LiftDirection = Direction.Down;
            }
        }

        internal enum Direction
        {
            Up,
            Down
        }
    }
}
