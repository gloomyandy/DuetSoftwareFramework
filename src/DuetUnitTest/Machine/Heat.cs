﻿using DuetAPI.Machine;
using NUnit.Framework;

namespace DuetUnitTest.Machine
{
    [TestFixture]
    public class Heat
    {
        [Test]
        public void Clone()
        {
            MachineModel original = new MachineModel();

            BedOrChamber bed = new BedOrChamber
            {
                Active = new float[] { 123F },
                Standby = new float[] { 456F },
                Name = "Bed Name",
                Heaters = new int[] { 0 }
            };
            original.Heat.Beds.Add(null);
            original.Heat.Beds.Add(bed);

            BedOrChamber chamber = new BedOrChamber
            {
                Active = new float[] { 321F },
                Standby = new float[] { 654F },
                Name = "Chamber Name",
                Heaters = new int[] { 4, 6 }
            };
            original.Heat.Chambers.Add(null);
            original.Heat.Chambers.Add(chamber);

            original.Heat.ColdExtrudeTemperature = 678F;
            original.Heat.ColdRetractTemperature = 987F;

            ExtraHeater extraHeater = new ExtraHeater
            {
                Current = 123,
                Name = "Extra Heater",
                Sensor = 4,
                State = HeaterState.Tuning
            };
            original.Heat.Extra.Add(extraHeater);

            Heater heater = new Heater
            {
                Current = 567,
                Max = 578,
                Sensor = 6,
                State = HeaterState.Standby
            };
            heater.Model.DeadTime = 322;
            heater.Model.Gain = 673;
            heater.Model.MaxPwm = 0.45F;
            heater.Model.TimeConstant = 32;
            original.Heat.Heaters.Add(heater);

            MachineModel clone = (MachineModel)original.Clone();

            Assert.AreEqual(2, original.Heat.Beds.Count);
            Assert.AreEqual(original.Heat.Beds[0], null);
            Assert.AreEqual(original.Heat.Beds[1].Active, clone.Heat.Beds[1].Active);
            Assert.AreEqual(original.Heat.Beds[1].Standby, clone.Heat.Beds[1].Standby);
            Assert.AreEqual(original.Heat.Beds[1].Name, clone.Heat.Beds[1].Name);
            Assert.AreEqual(original.Heat.Beds[1].Heaters, clone.Heat.Beds[1].Heaters);

            Assert.AreEqual(2, original.Heat.Chambers.Count);
            Assert.AreEqual(original.Heat.Chambers[0], null);
            Assert.AreEqual(original.Heat.Chambers[1].Active, clone.Heat.Chambers[1].Active);
            Assert.AreEqual(original.Heat.Chambers[1].Standby, clone.Heat.Chambers[1].Standby);
            Assert.AreEqual(original.Heat.Chambers[1].Name, clone.Heat.Chambers[1].Name);
            Assert.AreEqual(original.Heat.Chambers[1].Heaters, clone.Heat.Chambers[1].Heaters);

            Assert.AreEqual(original.Heat.ColdExtrudeTemperature, clone.Heat.ColdExtrudeTemperature);
            Assert.AreEqual(original.Heat.ColdRetractTemperature, clone.Heat.ColdRetractTemperature);

            Assert.AreEqual(1, original.Heat.Extra.Count);
            Assert.AreEqual(original.Heat.Extra[0].Current, clone.Heat.Extra[0].Current);
            Assert.AreEqual(original.Heat.Extra[0].Name, clone.Heat.Extra[0].Name);
            Assert.AreEqual(original.Heat.Extra[0].Sensor, clone.Heat.Extra[0].Sensor);
            Assert.AreEqual(original.Heat.Extra[0].State, clone.Heat.Extra[0].State);

            Assert.AreEqual(1, original.Heat.Heaters.Count);
            Assert.AreEqual(original.Heat.Heaters[0].Current, clone.Heat.Heaters[0].Current);
            Assert.AreEqual(original.Heat.Heaters[0].Max, clone.Heat.Heaters[0].Max);
            Assert.AreEqual(original.Heat.Heaters[0].Sensor, clone.Heat.Heaters[0].Sensor);
            Assert.AreEqual(original.Heat.Heaters[0].State, clone.Heat.Heaters[0].State);
            Assert.AreEqual(original.Heat.Heaters[0].Model.DeadTime, clone.Heat.Heaters[0].Model.DeadTime);
            Assert.AreEqual(original.Heat.Heaters[0].Model.Gain, clone.Heat.Heaters[0].Model.Gain);
            Assert.AreEqual(original.Heat.Heaters[0].Model.MaxPwm, clone.Heat.Heaters[0].Model.MaxPwm);
            Assert.AreEqual(original.Heat.Heaters[0].Model.TimeConstant, clone.Heat.Heaters[0].Model.TimeConstant);
            
            Assert.AreNotSame(original.Heat.Beds[1].Active, clone.Heat.Beds[1].Active);
            Assert.AreNotSame(original.Heat.Beds[1].Standby, clone.Heat.Beds[1].Standby);
            Assert.AreNotSame(original.Heat.Beds[1].Name, clone.Heat.Beds[1].Name);
            Assert.AreNotSame(original.Heat.Beds[1].Heaters, clone.Heat.Beds[1].Heaters);

            Assert.AreNotSame(original.Heat.Chambers[1].Active, clone.Heat.Chambers[1].Active);
            Assert.AreNotSame(original.Heat.Chambers[1].Standby, clone.Heat.Chambers[1].Standby);
            Assert.AreNotSame(original.Heat.Chambers[1].Name, clone.Heat.Chambers[1].Name);
            Assert.AreNotSame(original.Heat.Chambers[1].Heaters, clone.Heat.Chambers[1].Heaters);

            Assert.AreNotSame(original.Heat.ColdExtrudeTemperature, clone.Heat.ColdExtrudeTemperature);
            Assert.AreNotSame(original.Heat.ColdRetractTemperature, clone.Heat.ColdRetractTemperature);

            Assert.AreNotSame(original.Heat.Extra[0].Current, clone.Heat.Extra[0].Current);
            Assert.AreNotSame(original.Heat.Extra[0].Name, clone.Heat.Extra[0].Name);
            Assert.AreNotSame(original.Heat.Extra[0].Sensor, clone.Heat.Extra[0].Sensor);
            Assert.AreNotSame(original.Heat.Extra[0].State, clone.Heat.Extra[0].State);

            Assert.AreNotSame(original.Heat.Heaters[0].Current, clone.Heat.Heaters[0].Current);
            Assert.AreNotSame(original.Heat.Heaters[0].Max, clone.Heat.Heaters[0].Max);
            Assert.AreNotSame(original.Heat.Heaters[0].Sensor, clone.Heat.Heaters[0].Sensor);
            Assert.AreNotSame(original.Heat.Heaters[0].State, clone.Heat.Heaters[0].State);
            Assert.AreNotSame(original.Heat.Heaters[0].Model.DeadTime, clone.Heat.Heaters[0].Model.DeadTime);
            Assert.AreNotSame(original.Heat.Heaters[0].Model.Gain, clone.Heat.Heaters[0].Model.Gain);
            Assert.AreNotSame(original.Heat.Heaters[0].Model.MaxPwm, clone.Heat.Heaters[0].Model.MaxPwm);
            Assert.AreNotSame(original.Heat.Heaters[0].Model.TimeConstant, clone.Heat.Heaters[0].Model.TimeConstant);
        }
    }
}