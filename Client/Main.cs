using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            RegisterCommand("semihabi", new Action(SemihAbi), false);
            RegisterCommand("mahmuthocam", new Action(GiveWeapon), false);
            RegisterCommand("marker", new Action(Marker), false);
            RegisterCommand("git", new Action(Go), false);
            RegisterCommand("clear", new Action(Clear), false);
        }

        private void Clear()
        {
            var ped = Game.PlayerPed;
            ped.Task.ClearAllImmediately();
        }

        private async void Go()
        {

            var ped = Game.PlayerPed;
            ped.Task.ClearAllImmediately();
            var hedef = GetBlipInfoIdCoord(GetFirstBlipInfoId(8));
            Debug.WriteLine(hedef.ToString());
            var car = new Model(VehicleHash.Adder);
            var createdCar = await World.CreateVehicle(car, new Vector3(ped.Position.X + 5f, ped.Position.Y + 5f, ped.Position.Z + 5f));
            Debug.WriteLine("car");
            await Delay(1000);
            ped.Task.DriveTo(createdCar, hedef, 5f, 50f, 1084);
        }

        private async Task OnTick()
        {
            var ped = Game.PlayerPed.Position;
            Debug.WriteLine(ped.ToString());
            DrawMarker(1, ped.X, ped.Y, ped.Z - 1, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 1f, 1f, 125, 125, 125, 255, false, false, 2, true, null, null, false);
        }

        private void Marker()
        {
            Tick += OnTick;
        }

        private void GiveWeapon()
        {
            GiveWeaponToPed(Game.PlayerPed.Handle, (uint)WeaponHash.APPistol, 1000, false, true);
        }

        private void SemihAbi()
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new int[] { 255, 255, 255 },
                multiline = true,
                args = new string[] { "xXX", "doğru" },
            });
        }
    }
}
