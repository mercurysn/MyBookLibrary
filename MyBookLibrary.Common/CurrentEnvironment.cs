using System;

namespace MyBookLibrary.Common
{
    public class CurrentEnvironment
    {
        public static bool IsLocal()
        {
            return Environment.MachineName == "DESKTOP-PDV4EN1" || Environment.MachineName == "R5001472";
        }
    }
}