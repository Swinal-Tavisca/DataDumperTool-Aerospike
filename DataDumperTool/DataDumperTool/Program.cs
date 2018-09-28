using Aerospike.Client;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDumperTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "swinal";
                using (TextFieldParser field = new TextFieldParser("C:/Users/swinal/Desktop/2018-01-trump-twitter-wars-master/data/tweets/tweets1.csv"))
                {
                    field.SetDelimiters(",");
                    while (!field.EndOfData)
                    {
                        string[] fields = field.ReadFields();
                        var key = new Key(nameSpace, setName, fields[10]);
                        aerospikeClient.Put(new WritePolicy(), key, new Bin[] { new Bin("text", fields[0]), new Bin("favorited", fields[1]), new Bin("favoriteCount", fields[2]), new Bin("created", fields[3]), new Bin("truncated", fields[4]), new Bin("replyToSID", fields[5]), new Bin("replyToUID", fields[6]), new Bin("statusSource", fields[7]), new Bin("timestamp", fields[8]), new Bin("date", fields[9]) });
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("EXCEPTION !!!" + e);
            }      
        }
    }
}
