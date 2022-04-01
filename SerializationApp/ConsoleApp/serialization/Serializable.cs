using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.serialization
{
    public interface Serializable
    {

        public string[] toCSV();

        public void fromCSV(string[] values);

    }
}
