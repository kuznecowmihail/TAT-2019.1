using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class returns value to enter.
    /// </summary>
    public abstract class BaseInformationCreater
    {
        /// <summary>
        /// The method returns int value.
        /// </summary>
        /// <returns></returns>
        public int GetIntValue()
        {
            int val = 0;
            bool existence = false;

            while (existence == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int i))
                {
                    val = i;
                    existence = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return val;
        }

        /// <summary>
        /// The method returns inexisting id.
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public int GetIntNewID(List<int> listID)
        {
            int val = 0;
            bool existence = false;

            while (existence == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int i))
                {
                    if (listID.Where(t => t == i).Count() == 0)
                    {
                        val = i;
                        existence = true;
                    }
                    else
                    {
                        Console.WriteLine("Try again! This id exist!");
                    }
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return val;
        }

        /// <summary>
        /// The method returns existing id.
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public int GetIntExistingID(List<int> listID)
        {
            int val = 0;
            bool existence = false;

            while (existence == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int i))
                {
                    if (listID.Where(t => t == i).Count() > 0)
                    {
                        val = i;
                        existence = true;
                    }
                    else
                    {
                        Console.WriteLine("Try again! This id don't exist!");
                    }
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return val;
        }

        /// <summary>
        /// The method returns string value.
        /// </summary>
        /// <returns></returns>
        public string GetStringValue()
        {
            string val = string.Empty;
            bool existence = false;

            while(existence == false)
            {
                if((val = Console.ReadLine()) != string.Empty)
                {
                    existence = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return val;
        }
    }
}
