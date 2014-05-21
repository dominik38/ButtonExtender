using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.SchreiberDominik;

namespace TestApplication
{
    public partial class Program
    {
        ButtonExtender buttonExtender;  
        void ProgramStarted()
        {
            Debug.Print("Program Started");
            buttonExtender = new ButtonExtender(4);
            buttonExtender.ButtonPressed += buttonExtender_ButtonPressed;
            buttonExtender.ButtonReleased += buttonExtender_ButtonReleased;
            buttonExtender.PollTimerInterval = 10;  //default value is 25
            GT.Timer timer = new GT.Timer(1000); // every second (1000ms)
            timer.Tick += timer_Tick;
            timer.Start();            
        }

        void timer_Tick(GT.Timer timer)
        {
            if (buttonExtender.IsPressed(5))
                Debug.Print("Button5 is currently pressed!");
        }

        void buttonExtender_ButtonReleased(Int16 sender, ButtonExtender.ButtonState state)
        {
            Debug.Print("Button " + sender +" "+ state);
        }

        void buttonExtender_ButtonPressed(Int16 sender, ButtonExtender.ButtonState state)
        {
            Debug.Print("Button " + sender.ToString() + state.ToString());
        }
    }
}
