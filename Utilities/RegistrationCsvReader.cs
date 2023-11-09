using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskwyzeTestAutomation.Utilities
{
    public class RegistrationCsvReader
    {
        string _csvFile;
        List<string> _name = new List<string>()
        , _surname = new List<string>(),
         _phoneNumber = new List<string>(),
         _email = new List<string>(),
         _password = new List<string>();
        List<string> userString = new List<string>();

        CsvHelper.Configuration.CsvConfiguration myConfig =
            new CsvHelper.Configuration.CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", 
                HeaderValidated =null,
                MissingFieldFound = null } ;
        IEnumerable<LineInMyCsvFile> allRecords = null!;
        public RegistrationCsvReader(string csvFile)
        {
            _csvFile = csvFile;
        }

        public List<string> GetDataFromCsv()
        {
            int counter = 0;
            var data = RegistrationDetails();
            foreach (var item in data)
            {
                TestContext.Progress.WriteLine(item);
                switch (counter)
                {
                    case 0:

                        _name.Add(item);
                        break;
                    case 1:
                        _surname.Add(item);
                        break;
                    case 2:
                        _phoneNumber.Add(item);
                        break;
                    case 3:
                        _email.Add(item);
                        break;
                    case 4:
                        _password.Add(item);
                        break;
                }
                if (counter == 4)
                {
                    counter = -1;
                }

                counter++;
            }
            for (int i =7; i < _name.ToArray().Length; i++)
            {
                userString.Add(_name[i]);
                userString.Add(_surname[i]);
                userString.Add(_phoneNumber[i]);
                userString.Add(_email[i]);
                userString.Add(_password[i]);
            }
            /*TestContext.Progress.WriteLine(_name[0] + _surname[0] + _email[0] + _phoneNumber[0] + _password[0]);*/
            return userString;

        }

        public List<string> RegistrationDetails() 
        {
            
            List<string> csvData = new List<string>();

            using (var reader = File.OpenText(_csvFile))
            {
                var csvParser = new CsvParser(reader, myConfig);
               
                CsvReader r = new CsvReader(csvParser);
                
                allRecords = r.GetRecords<LineInMyCsvFile>().ToArray();
                foreach (var record in allRecords)
                {
                    csvData.Add(record.first_name);
                    csvData.Add(record.last_name);
                    csvData.Add(record.phone);
                    csvData.Add(record.email);
                    csvData.Add(record.password);
                }
                return csvData;

            }
        }

       
        struct LineInMyCsvFile
        {
            public string first_name {  get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string gender { get; set; }
            public string phone { get; set; }
        }

    }
}
