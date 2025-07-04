using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RFID2.Pages.Utils;
using System.Data;

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

            using var cmd = new SqlCommand("GIC_LOCATION_GET", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "GETALL");
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

        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(LocationName))
            {
                ModelState.AddModelError(string.Empty, "Location name is required");
                LoadLocations();
                return Page();
            }

            var newLoc = new LocationSaveDto
            {
                LocationName = LocationName,
                UserBy = 1 
            };

            SaveLocation(newLoc);

            return RedirectToPage(); // Refresh page to clear form and reload list
        }

        public void SaveLocation(LocationSaveDto newLoc)
        {
            using var conn = DbConnection.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand("GIC_LOCATION_TRANS", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "INSERT");
            cmd.Parameters.AddWithValue("@LocationName", newLoc.LocationName);
            cmd.Parameters.AddWithValue("@UserBy", newLoc.UserBy);
            cmd.Parameters.Add("@Key", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@Key"].Value = 0;

            cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@RowsAffected"].Value = 0;
            try
            {
                cmd.ExecuteNonQuery();
                TempData["SuccessMessage"] = "Location added successfully.";
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                TempData["ErrorMessage"] = "Location already exists.";
                LoadLocations();
                //return Page();
            }


        }
    }
}

