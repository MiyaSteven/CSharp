// using System;
// using System.Collections.Generic;

// namespace FullWebApp.Models
// {
//     public class Ninja : Person
//     {
//         public Ninja(string Name) : base(Name) { }

//         public Ninja(string Name, string Location, int Skills, int TotalExperience) : base(Name, Location, Skills, TotalExperience) { }

//         // call GainExp base level function below
//         public int Recon(Ninja target)
//         {
//             int ExpGain = TotalExperience;
//             if (Skills > target.Skills)
//             {
//                 Console.WriteLine($"{Name} successfully reported enemy skill levels exceeding {target.Skills}");
//                 ExpGain += target.Skills * 3;
//             }
//             else
//             {
//                 Console.WriteLine($"{Name} had a skill level of {Skills} and was only able to retrieve enemy data of Name: {target.Name}");
//                 ExpGain += target.Skills * 2;
//             }
//             return ExpGain;
//         }
//     }
// }