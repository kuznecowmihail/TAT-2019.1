using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class finds id.
    /// </summary>
    public class FinderID
    {
        public int FindID(List<int> listID)
        {
            int request = 0;

            do
            {
                Console.WriteLine("Enter existing ID:");
                Int32.TryParse(Console.ReadLine(), out request);
            } while (listID.Where(t => t == request).Count() == 0);//existenceID == false)

            return request;
        }
    }
}
