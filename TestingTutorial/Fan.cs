using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTutorial
{
    /// <summary>
    /// Represents a fan with speeds from 0 - 5. The fan is initially off.
    /// If the fan is on, then the speed must be at least 1.
    /// If the fan is off, then the speed must be 0.
    /// User can only interact with the speed - fan should go off/on to match.
    /// </summary>
    /// 


    //NOTE: this implementation has errors that will be corrected with testing

    public class Fan
    {
        /// <summary>
        /// Whether this fan is on
        /// </summary>
        public bool FanOn { get; private set; } = false;

        private int _curSpeed = 0;

        /// <summary>
        /// The current speed of this fan
        /// </summary>
        public int CurSpeed
        {
            get => _curSpeed;
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _curSpeed = value;
                    FanOn = true;
                }
                else if (value == 0)
                {
                    _curSpeed = value;
                    FanOn = false;
                }
            }
        }

        /// <summary>
        /// The RPM of this fan at its current speed
        /// </summary>
        public int RPM
        {
            get
            {
                //rpm for speed 1 is 200, and each additional speed adds 50 more rpm
                if (CurSpeed == 0) return 0;

                return 150 + CurSpeed * 50;
            }
        } 
    }
}
