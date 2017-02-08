﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    class Car
    {
        public const int MaxSpeed = 100;

        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        private bool carIsDead;

        private Radio theMusicBox = new Radio();

        public Car()
        {

        }
        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        public void CrankTunes(bool state) {
            theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta) {
            if (delta < 0)
                throw new
                    ArgumentOutOfRangeException("delta", "Speed must be greater than zero");
            
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = 0;
                    carIsDead = true;
                    CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has over heated!", PetName),"You have a lead foot",DateTime.Now);
                    ex.HelpLink = "http://carsRus.com";
                    ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("cause", string.Format("You have a lead foot"));
                    throw ex;
                }
                else
                    Console.WriteLine("=> currentSpeed = {0}",CurrentSpeed);
            }
   
        }
    }
}
