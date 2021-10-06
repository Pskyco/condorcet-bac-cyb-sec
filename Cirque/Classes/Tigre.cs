using System;

namespace Cirque.Classes
{
    public class Tigre : Animal
    {
        public override void UneFoisLesToursFinis()
        {
            Console.WriteLine("Le tigre rugit");
        }
        
        public override void UneFoisLesToursFinis2()
        {
            // base.UneFoisLesToursFinis2();
            // Console.WriteLine("Le tigre rugit");
        }
    }
}