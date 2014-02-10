using System;
using System.Collections.Generic;
using System.Text;
using Models.Core;

namespace Models.PMF.Functions.StructureFunctions
{
    [Serializable]
    [Description("Calculates the potential height increment and then multiplies it by the smallest of any childern functions (Child functions represent stress)")]
    public class HeightFunction : Function
    {
        [Link]
        Function PotentialHeight = null;
        double PotentialHeightYesterday = 0;
        double Height = 0;
        public List<Function> Children { get; set; }

        public double DeltaHeight = 0;
        public override void UpdateVariables(string initial)
        {
            double PotentialHeightIncrement = PotentialHeight.Value - PotentialHeightYesterday;
            double StressValue = 1.0;
            //This function is counting potential height as a stress.
            foreach (Function F in Children)
            {
                StressValue = Math.Min(StressValue, F.Value);
            }
            DeltaHeight = PotentialHeightIncrement * StressValue;
            PotentialHeightYesterday = PotentialHeight.Value;
            Height += DeltaHeight;
        }
        
        public override double Value
        {
            get
            {
                return Height;
            }
        }
    }
}
