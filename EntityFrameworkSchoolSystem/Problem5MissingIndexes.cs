﻿using System.Linq;
using EntityFrameworkSchoolSystem.Models;

namespace EntityFrameworkSchoolSystem
{
    public partial class DataLayer
    {
        //Retrieve pupil names in a city
        public string DoProblem5()
        {
            using (var db = new EFSchoolSystemContext())
            {
                db.Database.CommandTimeout = 300;
                string city = "New York";

                var pupils = db.Pupils
                    .Where(p => p.City == city)
                    .OrderBy(p => p.LastName)
                    .Select(x => new { x.FirstName, x.LastName })
                    .ToList();

                foreach (var pupil in pupils)
                {
                    _outputBuffer.Append($"{pupil.FirstName} {pupil.LastName}");
                }

                return _outputBuffer.ToString();
            }
        }
    }
}