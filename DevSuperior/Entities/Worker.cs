using System;
using System.Collections.Generic;
using System.Globalization;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Worker
    {
        public String? Name {get; set;}
        public WorkerLevel Level {get; set;}
        public Double BaseSalary {get; set;}

        public Worker() {}

    }
}