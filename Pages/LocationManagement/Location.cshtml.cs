using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RFID2.Pages.Utils;

namespace RFID2.Pages.LocationManagement
{
    public class LocationModel : PageModel
    {
        public List<LocationDto> Locations { get; set; } = new();

   
        public class LocationDto
        {
            public string LocationName { get; set; }
        }
        public class LocationGetDto
        {
            public int LOCATION_ID { get; set; }
            public string LocationName { get; set; }

            public int CreatedBy { get; set; }
            public string CreatedOn { get; set; }
            public int LastUpdatedBy { get; set; }
            public string LastUpdatedOn { get; set; }


        }
        public class LocationSaveDto
        {
            public string LocationName { get; set; }
            public int UserBy { get; set; }
        }
        public class LocationReqDto
        {
            public int LOCATION_ID { get; set; }
        }
        public class EditReq
        {
            public int LOCATION_ID { get; set; }
            public string LocationName { get; set; }
            public int UserBy { get; set; }

        }
        private void LoadLocations()
        {
            Locations.Clear();
            using var conn = DbConnection.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand("SELECT LocationName FROM LocationTable", conn);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Locations.Add(new LocationDto
                {                                                                                                                                                                                   
                    LocationName = rdr["LocationName"].ToString()
                });
            }
              
        }

        [BindProperty]
        public string LocationName { get; set; }
            public void OnGet()
            {
            LoadLocations();
                //Locations = new List<LocationDto>
                //{
                //    new LocationDto { LocationName = "TPO" },
                //    new LocationDto { LocationName = "SPO" },
                //    new LocationDto { LocationName = "SG1" },
                //    new LocationDto { LocationName = "RDC-WEST" },
                //    new LocationDto { LocationName = "NORTH-ZONE" }
                //};

            }
       

    }
}

