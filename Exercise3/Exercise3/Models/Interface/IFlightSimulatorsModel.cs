﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Exercise3.Models.Interface
{
    //A FlightSimulatorModel interface.
    
    public interface IFlightSimulatorsModel 
    {
        void Start(ITelnetClientFactory factory, int timeout);
        void Stop();
        
        Dictionary<string, double> GetData(string ip, int port, string[] vals);
        //for example: GetData(127.0.0.1, 5400, {"Lon", "Lat", "Alieron"});
        // and the output: [123.3838, 192.122, 0.8]
        Dictionary<string, double> SaveData(string ip, int port, string file, string[] vals);
        Dictionary<string, double>[] LoadData(string file, string[] vals);
    }
}
