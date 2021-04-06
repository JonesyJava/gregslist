using System.Collections.Generic;
using gregslist.Models;

namespace gregslist.db
{
    public class FakeDB
    {

        //NOTE make sure you instantiate your list before you try to access it.
        public static List<Car> Cars { get; set; } = new List<Car>();
    }
}