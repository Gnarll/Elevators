using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftModel
{
    public class LiftButton
    {
        public int Number { get; set; }
        public bool IsActive { get; set; }

        internal LiftButton(int num, bool isActive)
        {
            Number = num;
            IsActive = isActive;
        }

        public void ChangeActivity(bool Value)
        {
            IsActive = Value;
        }
    }
}
