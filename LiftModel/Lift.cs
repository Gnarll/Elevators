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
        public List<LiftButton> Buttons { get; set; } = new List<LiftButton>();
        public int CurrentMin = 0;
        public int CurrentSec = 0;

        public Lift(int floors)
        {
            Floors = floors;
            InitializeButtons();
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
